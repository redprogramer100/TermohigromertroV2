/* Código unificado + WiFi/WebServer:
   - Menú OLED con ventanas (MEDIDAS, CALIBRACION)
   - BME280 (Temp, Hum, Pres)
   - RTC (DS1307)
   - SD (registro cada INTERVALO_GUARDADO)
   - EEPROM para coeficientes a,b,c,d,e,f
   - Navegación con 3 botones: UP, DOWN, SELECT
   - WiFi + endpoint /data -> devuelve JSON con temperatura, humedad, presion
   - Muestra estado WiFi e IP en la pantalla MEDIDAS
*/

#include <Wire.h>
#include <RTClib.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>
#include <SD.h>
#include <SPI.h>
#include <EEPROM.h>

#include <WiFi.h>
#include <WebServer.h>

// ----------------- Configuración WiFi (EDITA ESTO) -----------------
//const char* WIFI_SSID = "IBM175-PC 0302";         // <- cambia por tu SSID
//const char* WIFI_PASS = "12345678a";    // <- cambia por tu password
const char* WIFI_SSID = "Lab-Flujo";         // <- cambia por tu SSID
const char* WIFI_PASS = "Flujo*2025";    // <- cambia por tu password
//const char* WIFI_SSID = "grandesVolumenes";         // <- cambia por tu SSID
//const char* WIFI_PASS = "123456789a";    // <- cambia por tu password

WebServer server(80);
bool wifiConnected = false;
bool serverStarted = false;
String wifiIP = "---";
unsigned long lastWifiAttempt = 0;
const unsigned long WIFI_RECONNECT_INTERVAL = 10000; // ms

// ----------------- Configuración hardware -----------------
#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64
#define OLED_RESET -1
#define OLED_SDA 21
#define OLED_SCL 22
#define OLED_ADDR 0x3C

#define SEALEVELPRESSURE_HPA (1013.25)

// Pines SD (SPI)
#define SD_CS 5
#define SD_MOSI 23
#define SD_MISO 19
#define SD_SCK 18

// Pines botones (uso los tuyos del primer código)
const int BUTTON_UP = 34;
const int BUTTON_DOWN = 32;
const int BUTTON_SELECT = 14;

// EEPROM
#define EEPROM_SIZE 512
#define ADDR_HUMEDAD_A 0
#define ADDR_HUMEDAD_B 4
#define ADDR_PRESION_C 8
#define ADDR_PRESION_D 12
#define ADDR_TEMP_E 16
#define ADDR_TEMP_F 20

// Intervalos
#define INTERVALO_MUESTREO 1000    // ms para actualizar OLED
#define INTERVALO_GUARDADO 300000  // 5 minutos para SD

// ----------------- Objetos -----------------
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);
Adafruit_BME280 bme;
RTC_DS1307 rtc;
File dataFile;

// ----------------- Variables del menú y calibración -----------------
int currentMenu = 0;      // 0 = menú principal, 1 = MEDIDAS, 2 = CALIBRACION
int selectedItem = 0;
int maxMenuItems = 2;

int subMenuCalibracion = 0; // 0 = lista (CAL. HUM, CAL. PRES, CAL. TEMP, SALIR), 1..3 = submenus
int selectedSubItem = 0;
int maxSubMenuItems = 4;

// coeficientes (se cargan desde EEPROM)
float humedad_a = 1.0;
float humedad_b = 0.0;
float presion_c = 1.0;
float presion_d = 0.0;
float temperatura_e = 1.0;
float temperatura_f = 0.0;

// edición
int opcionHumedad = 0;
bool editandoHumedad = false;

int opcionPresion = 0;
bool editandoPresion = false;

int opcionTemperatura = 0;
bool editandoTemperatura = false;

// botones - debounce
bool lastUpState = LOW;
bool lastDownState = LOW;
bool lastSelectState = LOW;
unsigned long lastDebounceTime = 0;
unsigned long debounceDelay = 50;

// muestreo y guardado
unsigned long ultimoMuestreo = 0;
unsigned long ultimoGuardado = 0;

// valores de sensores (crudos y calibrados)
float tempRaw = 0.0, humRaw = 0.0, presRaw = 0.0;
float tempCal = 0.0, humCal = 0.0, presCal = 0.0;

// ----------------- Prototipos -----------------
void cargarCalibracionDesdeEEPROM();
void guardarCalibracionEnEEPROM();

void iniciarOLED();
void iniciarBME280();
void iniciarSD();
void iniciarRTC();
void crearArchivoDatos();
void guardarEnSD(DateTime now, float t, float h, float p);

void leerBotones();
void manejarBotonUP();
void manejarBotonDOWN();
void manejarBotonSELECT();

void actualizarPantalla();
void mostrarMenuPrincipal();
void mostrarSubMenuCalibracion();
void mostrarCalibracionHumedad();
void mostrarCalibracionPresion();
void mostrarCalibracionTemperatura();
void mostrarPaginaMedidas();

void dibujarBoton(int x, int y, int ancho, int alto, String texto, bool seleccionado);
void dibujarItemMenu(int x, int y, String texto, bool seleccionado, bool editando);

void mostrarErrorOLED(const char* mensaje);

// WiFi / WebServer
void iniciarWiFi();
void checkWiFiReconnect();
void handleData();

// ----------------- Setup -----------------
void setup() {
  Serial.begin(9600);
  delay(100);

  // EEPROM
  EEPROM.begin(EEPROM_SIZE);
  cargarCalibracionDesdeEEPROM();

  // Botones (si no funcionan bien por pull interno, usar R externas)
  pinMode(BUTTON_UP, INPUT_PULLDOWN);
  pinMode(BUTTON_DOWN, INPUT_PULLDOWN);
  pinMode(BUTTON_SELECT, INPUT_PULLDOWN);

  // Iniciar periféricos
  iniciarOLED();
  iniciarBME280();
  iniciarSD();
  iniciarRTC();

  crearArchivoDatos();

  // Iniciar WiFi (intento inicial)
  iniciarWiFi();

  // registrar endpoint aunque el server pueda arrancar después
  server.on("/data", handleData);

  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(SSD1306_WHITE);
  display.setCursor(0,0);
  display.println("Sistema iniciado");
  display.display();
  delay(800);
}

// ----------------- Loop -----------------
void loop() {
  unsigned long ahora = millis();

  // manejar servidores / reconexión WiFi
  checkWiFiReconnect();
  if (serverStarted) server.handleClient();

  // Si estamos en menú de calibración (subMenu), no hacemos muestreo automático de pantalla en modo medidas
  leerBotones();

  // MUESTREO (lectura BME + actualizar pantalla cada INTERVALO_MUESTREO, solo si no estamos en el menu principal)
  if (ahora - ultimoMuestreo >= INTERVALO_MUESTREO) {
    ultimoMuestreo = ahora;
    // Leer crudos
    tempRaw = bme.readTemperature();
    humRaw  = bme.readHumidity();
    presRaw = bme.readPressure() / 100.0F;

    // Aplicar calibración
    tempCal = temperatura_e * tempRaw + temperatura_f;
    humCal  = humedad_a * humRaw + humedad_b;
    presCal = presion_c * presRaw + presion_d;
    Serial.print("#");
    Serial.print(tempCal, 2);
    Serial.print("/");
    Serial.print(humCal, 2);
    Serial.print("/");
    Serial.print(presCal, 2);
    Serial.println("/V");


    // Si estamos en la ventana MEDIDAS, mostramos; si no, actualizar pantalla según estado
    actualizarPantalla();
  }

  // GUARDADO en SD cada INTERVALO_GUARDADO (guardamos los valores calibrados actuales)
  if (ahora - ultimoGuardado >= INTERVALO_GUARDADO) {
    ultimoGuardado = ahora;
    DateTime now = rtc.now();
    guardarEnSD(now, tempCal, humCal, presCal);
  }

  delay(10);
}

// ----------------- WiFi / WebServer -----------------
void iniciarWiFi() {
  wifiConnected = false;
  serverStarted = false;
  wifiIP = "---";
  Serial.printf("Intentando conectar WiFi '%s'...\n", WIFI_SSID);
  WiFi.mode(WIFI_STA);
  WiFi.begin(WIFI_SSID, WIFI_PASS);
  lastWifiAttempt = millis();
}

void checkWiFiReconnect() {
  unsigned long now = millis();

  if (WiFi.status() == WL_CONNECTED) {
    if (!wifiConnected) {
      wifiConnected = true;
      wifiIP = WiFi.localIP().toString();
      Serial.print("WiFi conectado, IP: ");
      Serial.println(wifiIP);
      // arrancar servidor solo una vez
      if (!serverStarted) {
        server.begin();
        serverStarted = true;
        Serial.println("WebServer iniciado");
      }
    } else {
      // ya conectado: actualizar IP por si cambia (raro)
      wifiIP = WiFi.localIP().toString();
    }
  } else {
    if (wifiConnected) {
      // Cambio: se desconectó
      wifiConnected = false;
      serverStarted = false;
      wifiIP = "---";
      Serial.println("WiFi desconectado");
    }
    // Intentar reconectar periódicamente
    if (now - lastWifiAttempt >= WIFI_RECONNECT_INTERVAL) {
      Serial.println("Reintentando conectar WiFi...");
      WiFi.disconnect();
      WiFi.begin(WIFI_SSID, WIFI_PASS);
      lastWifiAttempt = now;
    }
  }
}

void handleData() {
  // Prepara JSON con valores calibrados (2 decimales)
  String json = "{";
  json += String(humCal, 2) + ",";
  json += String(tempCal, 2) + ",";
  json += String(presCal, 2);
  json += "}";

  server.send(200, "application/json", json);
}


// ----------------- Inicializaciones -----------------
void iniciarOLED() {
  Wire.begin(OLED_SDA, OLED_SCL);
  if (!display.begin(SSD1306_SWITCHCAPVCC, OLED_ADDR)) {
    Serial.println("Error en OLED");
    while (1) delay(10);
  }
  display.clearDisplay();
}

void iniciarBME280() {
  // cambia 0x76 por 0x77 si tu módulo usa esa dirección
  if (!bme.begin(0x76)) {
    Serial.println("Error BME280");
    mostrarErrorOLED("Error BME280");
    while(1) delay(10);
  }
}

void iniciarSD() {
  SPI.begin(SD_SCK, SD_MISO, SD_MOSI, SD_CS);
  if (!SD.begin(SD_CS)) {
    Serial.println("Error SD");
    mostrarErrorOLED("Error SD");
    // No bloqueamos; SD es opcional a la lectura
  } else {
    Serial.println("SD iniciada");
  }
}

void iniciarRTC() {
  if (!rtc.begin()) {
    Serial.println("Error RTC");
    mostrarErrorOLED("Error RTC");
    while(1) delay(10);
  }
  if (!rtc.isrunning()) {
    Serial.println("RTC no está funcionando - configurando con la hora de compilación");
    rtc.adjust(DateTime(F(__DATE__), F(__TIME__)));
  }
}

// ----------------- EEPROM -----------------
void cargarCalibracionDesdeEEPROM() {
  EEPROM.get(ADDR_HUMEDAD_A, humedad_a);
  EEPROM.get(ADDR_HUMEDAD_B, humedad_b);
  EEPROM.get(ADDR_PRESION_C, presion_c);
  EEPROM.get(ADDR_PRESION_D, presion_d);
  EEPROM.get(ADDR_TEMP_E, temperatura_e);
  EEPROM.get(ADDR_TEMP_F, temperatura_f);

  // Si EEPROM no tenía nada válido, poner valores por defecto
  if (isnan(humedad_a) || humidity_too_small(humedad_a)) humedad_a = 1.0;
  if (isnan(humedad_b)) humedad_b = 0.0;
  if (isnan(presion_c) || humidity_too_small(presion_c)) presion_c = 1.0;
  if (isnan(presion_d)) presion_d = 0.0;
  if (isnan(temperatura_e) || humidity_too_small(temperatura_e)) temperatura_e = 1.0;
  if (isnan(temperatura_f)) temperatura_f = 0.0;

  Serial.println("Calibracion cargada de EEPROM:");
  Serial.printf("a=%.4f b=%.4f c=%.4f d=%.4f e=%.4f f=%.4f\n",
                humedad_a, humedad_b, presion_c, presion_d, temperatura_e, temperatura_f);
}

// pequeña función para prevenir valores absurdos leídos desde EEPROM
bool humidity_too_small(float v) {
  // si es extremadamente grande o 0/NaN: tratar como inválido
  if (isnan(v)) return true;
  if (abs(v) > 1e6) return true;
  return false;
}

void guardarCalibracionEnEEPROM() {
  EEPROM.put(ADDR_HUMEDAD_A, humedad_a);
  EEPROM.put(ADDR_HUMEDAD_B, humedad_b);
  EEPROM.put(ADDR_PRESION_C, presion_c);
  EEPROM.put(ADDR_PRESION_D, presion_d);
  EEPROM.put(ADDR_TEMP_E, temperatura_e);
  EEPROM.put(ADDR_TEMP_F, temperatura_f);
  EEPROM.commit();
  Serial.println("✓ Valores guardados en EEPROM");
}

// ----------------- SD -----------------
void crearArchivoDatos() {
  if (!SD.begin(SD_CS)) return; // si SD no está disponible no hacemos nada
  if (!SD.exists("/datos.csv")) {
    dataFile = SD.open("/datos.csv", FILE_WRITE);
    if (dataFile) {
      dataFile.println("Fecha,Hora,Temperatura[C],Humedad[%],Presion[hPa]");
      dataFile.close();
      Serial.println("Archivo datos.csv creado");
    }
  }
}

void guardarEnSD(DateTime now, float t, float h, float p) {
  if (!SD.begin(SD_CS)) return;
  dataFile = SD.open("/datos.csv", FILE_APPEND);
  if (dataFile) {
    char buf[128];
    sprintf(buf, "%04d-%02d-%02d,%02d:%02d:%02d,%.2f,%.2f,%.2f",
            now.year(), now.month(), now.day(),
            now.hour(), now.minute(), now.second(),
            t, h, p);
    dataFile.println(buf);
    dataFile.close();

    Serial.println("Datos guardados en SD");
  } else {
    Serial.println("Error al abrir datos.csv");
  }
}

// ----------------- Lectura botones y manejo menú -----------------
void leerBotones() {
  unsigned long currentTime = millis();

  if (currentTime - lastDebounceTime > debounceDelay) {

    bool currentUpState = digitalRead(BUTTON_UP);
    bool currentDownState = digitalRead(BUTTON_DOWN);
    bool currentSelectState = digitalRead(BUTTON_SELECT);

    // UP
    if (currentUpState == HIGH && lastUpState == LOW) {
      if (currentMenu == 0) {
        selectedItem--;
        if (selectedItem < 0) selectedItem = maxMenuItems - 1;
      } 
      else if (currentMenu == 2 && subMenuCalibracion == 0) {
        selectedSubItem--;
        if (selectedSubItem < 0) selectedSubItem = maxSubMenuItems - 1;
      }
      else if (currentMenu == 2 && subMenuCalibracion > 0) {
        manejarBotonUP();
      }
      lastDebounceTime = currentTime;
    }

    // DOWN
    if (currentDownState == HIGH && lastDownState == LOW) {
      if (currentMenu == 0) {
        selectedItem++;
        if (selectedItem >= maxMenuItems) selectedItem = 0;
      } 
      else if (currentMenu == 2 && subMenuCalibracion == 0) {
        selectedSubItem++;
        if (selectedSubItem >= maxSubMenuItems) selectedSubItem = 0;
      }
      else if (currentMenu == 2 && subMenuCalibracion > 0) {
        manejarBotonDOWN();
      }
      lastDebounceTime = currentTime;
    }

    // SELECT
    if (currentSelectState == HIGH && lastSelectState == LOW) {
      if (currentMenu == 0) {
        // entrar a la página seleccionada: MEDIDAS = 1, CALIBRACION = 2
        currentMenu = selectedItem + 1;
        if (currentMenu == 2) {
          subMenuCalibracion = 0;
          selectedSubItem = 0;
        }
      } 
      else if (currentMenu == 2 && subMenuCalibracion == 0) {
        if (selectedSubItem == 3) {
          currentMenu = 0; // SALIR
        } else {
          subMenuCalibracion = selectedSubItem + 1;
          // reset opciones al entrar
          opcionHumedad = 0; opcionPresion = 0; opcionTemperatura = 0;
          editandoHumedad = false; editandoPresion = false; editandoTemperatura = false;
        }
      }
      else if (currentMenu == 2 && subMenuCalibracion > 0) {
        manejarBotonSELECT();
      }
      else {
        currentMenu = 0;
      }
      lastDebounceTime = currentTime;
    }

    lastUpState = currentUpState;
    lastDownState = currentDownState;
    lastSelectState = currentSelectState;
  }
}

void manejarBotonUP() {
  switch(subMenuCalibracion) {
    case 1: // Humedad
      if (editandoHumedad) {
        if (opcionHumedad == 0) humedad_a += 0.01;
        else if (opcionHumedad == 1) humedad_b += 0.01;
      } else {
        opcionHumedad--;
        if (opcionHumedad < 0) opcionHumedad = 3;
      }
      break;

    case 2: // Presión
      if (editandoPresion) {
        if (opcionPresion == 0) presion_c += 0.01;
        else if (opcionPresion == 1) presion_d += 0.01;
      } else {
        opcionPresion--;
        if (opcionPresion < 0) opcionPresion = 3;
      }
      break;

    case 3: // Temperatura
      if (editandoTemperatura) {
        if (opcionTemperatura == 0) temperatura_e += 0.01;
        else if (opcionTemperatura == 1) temperatura_f += 0.01;
      } else {
        opcionTemperatura--;
        if (opcionTemperatura < 0) opcionTemperatura = 3;
      }
      break;
  }
}

void manejarBotonDOWN() {
  switch(subMenuCalibracion) {
    case 1: // Humedad
      if (editandoHumedad) {
        if (opcionHumedad == 0) humedad_a -= 0.01;
        else if (opcionHumedad == 1) humedad_b -= 0.01;
      } else {
        opcionHumedad++;
        if (opcionHumedad > 3) opcionHumedad = 0;
      }
      break;

    case 2: // Presión
      if (editandoPresion) {
        if (opcionPresion == 0) presion_c -= 0.01;
        else if (opcionPresion == 1) presion_d -= 0.01;
      } else {
        opcionPresion++;
        if (opcionPresion > 3) opcionPresion = 0;
      }
      break;

    case 3: // Temperatura
      if (editandoTemperatura) {
        if (opcionTemperatura == 0) temperatura_e -= 0.01;
        else if (opcionTemperatura == 1) temperatura_f -= 0.01;
      } else {
        opcionTemperatura++;
        if (opcionTemperatura > 3) opcionTemperatura = 0;
      }
      break;
  }
}

void manejarBotonSELECT() {
  switch(subMenuCalibracion) {
    case 1: // Humedad
      if (opcionHumedad == 2) { // GUARDAR
        guardarCalibracionEnEEPROM();
        subMenuCalibracion = 0;
      } else if (opcionHumedad == 3) { // SALIR
        subMenuCalibracion = 0;
      } else { // Ajustar a (0) o b (1)
        editandoHumedad = !editandoHumedad;
      }
      break;

    case 2: // Presión
      if (opcionPresion == 2) { // GUARDAR
        guardarCalibracionEnEEPROM();
        subMenuCalibracion = 0;
      } else if (opcionPresion == 3) { // SALIR
        subMenuCalibracion = 0;
      } else { // Ajustar c (0) o d (1)
        editandoPresion = !editandoPresion;
      }
      break;

    case 3: // Temperatura
      if (opcionTemperatura == 2) { // GUARDAR
        guardarCalibracionEnEEPROM();
        subMenuCalibracion = 0;
      } else if (opcionTemperatura == 3) { // SALIR
        subMenuCalibracion = 0;
      } else { // Ajustar e (0) o f (1)
        editandoTemperatura = !editandoTemperatura;
      }
      break;
  }
}

// ----------------- Dibujo en OLED -----------------
void dibujarBoton(int x, int y, int ancho, int alto, String texto, bool seleccionado) {
  if (seleccionado) {
    display.fillRoundRect(x, y, ancho, alto, 5, SSD1306_WHITE);
    display.setTextColor(SSD1306_BLACK, SSD1306_WHITE);
  } else {
    display.drawRoundRect(x, y, ancho, alto, 5, SSD1306_WHITE);
    display.setTextColor(SSD1306_WHITE);
  }

  int16_t x1, y1;
  uint16_t w, h;
  display.getTextBounds(texto, 0, 0, &x1, &y1, &w, &h);
  int textoX = x + (ancho - w) / 2;
  int textoY = y + (alto - h) / 2;

  display.setCursor(textoX, textoY);
  display.println(texto);
  display.setTextColor(SSD1306_WHITE);
}

void dibujarItemMenu(int x, int y, String texto, bool seleccionado, bool editando) {
  display.setCursor(x, y);
  if (seleccionado) {
    if (editando) {
      // Modo edición: mostrar con indicador <*>
      display.print("> ");
      display.print(texto);
      display.print(" *");
    } else {
      display.print("> ");
      display.print(texto);
    }
  } else {
    display.print("  ");
    display.print(texto);
  }
}

// ----------------- Páginas -----------------
void mostrarMenuPrincipal() {
  display.clearDisplay();

  int botonAncho = 110;
  int botonAlto = 22;
  int espacioEntreBotones = 6;

  int totalAltura = (botonAlto * 2) + espacioEntreBotones;
  int inicioY = (SCREEN_HEIGHT - totalAltura) / 2;

  dibujarBoton((SCREEN_WIDTH - botonAncho) / 2, inicioY, botonAncho, botonAlto, "MEDIDAS", selectedItem == 0);
  dibujarBoton((SCREEN_WIDTH - botonAncho) / 2, inicioY + botonAlto + espacioEntreBotones, botonAncho, botonAlto, "CALIBRACION", selectedItem == 1);
}

void mostrarSubMenuCalibracion() {
  display.clearDisplay();
  display.setTextSize(1);
  display.setCursor(0, 0);
  display.println("CALIBRACION");
  display.println("");

  String opciones[] = {"CAL. HUM", "CAL. PRES", "CAL. TEMP", "SALIR"};
  for (int i = 0; i < maxSubMenuItems; i++) {
    dibujarItemMenu(8, 20 + (i * 10), opciones[i], i == selectedSubItem, false);
    display.println();
  }
  display.display();
}

void mostrarCalibracionHumedad() {
  display.clearDisplay();
  display.setCursor(0,0);
  display.println("HUM: H*a + b");
  display.println("");

  dibujarItemMenu(8, 15, "Ajustar a = " + String(humedad_a, 2), opcionHumedad == 0, editandoHumedad && opcionHumedad == 0);
  display.println();
  dibujarItemMenu(8, 25, "Ajustar b = " + String(humedad_b, 2), opcionHumedad == 1, editandoHumedad && opcionHumedad == 1);
  display.println();
  dibujarItemMenu(8, 35, "GUARDAR", opcionHumedad == 2, false);
  display.println();
  dibujarItemMenu(8, 45, "SALIR", opcionHumedad == 3, false);

  display.setCursor(0, 56);
  if (editandoHumedad) display.println("B1: Terminar");
  else display.println("B1: Selec");

  display.display();
}

void mostrarCalibracionPresion() {
  display.clearDisplay();
  display.setCursor(0,0);
  display.println("PRES: P*c + d");
  display.println("");
 //   display.setCursor(15, 1);
  dibujarItemMenu(8, 15, "Ajustar c = " + String(presion_c, 2), opcionPresion == 0, editandoPresion && opcionPresion == 0);
  display.println();
  dibujarItemMenu(8, 25, "Ajustar d = " + String(presion_d, 2), opcionPresion == 1, editandoPresion && opcionPresion == 1);
  display.println();
  dibujarItemMenu(8, 35, "GUARDAR", opcionPresion == 2, false);
  display.println();
  dibujarItemMenu(8, 45, "SALIR", opcionPresion == 3, false);

  display.setCursor(0, 56);
  if (editandoPresion) display.println("B1: Terminar");
  else display.println("B1: Selec");

  display.display();
}

void mostrarCalibracionTemperatura() {
  display.clearDisplay();
  display.setCursor(0,0);
  display.println("TEMp:T*e + f");
//display.setCursor(15, 10);
  display.println("");

  dibujarItemMenu(8, 15, "Ajustar e = " + String(temperatura_e, 2), opcionTemperatura == 0, editandoTemperatura && opcionTemperatura == 0);
  display.println();
  dibujarItemMenu(8, 25, "Ajustar f = " + String(temperatura_f, 2), opcionTemperatura == 1, editandoTemperatura && opcionTemperatura == 1);
  display.println();
  dibujarItemMenu(8, 35, "GUARDAR", opcionTemperatura == 2, false);
  display.println();
  dibujarItemMenu(8, 45, "SALIR", opcionTemperatura == 3, false);

  display.setCursor(0, 56);
  if (editandoTemperatura) display.println("B1: Terminar");
  else display.println("B1: Selec");

  display.display();
}

void mostrarPaginaMedidas() {
  display.clearDisplay();
  display.setTextSize(1);
  display.setCursor(0,0);

  DateTime now = rtc.now();
  // Fecha y hora
  const char* diasSemana[] = {"Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"};
  display.printf("%s %02d/%02d %02d:%02d:%02d",
                diasSemana[now.dayOfTheWeek()],
                now.day(), now.month(),
                now.hour(), now.minute(), now.second());

  // Sensores calibrados
  display.setCursor(0,20);
  display.printf("H: %.2f %%", humCal);
  display.setCursor(0,30);
  display.printf("P: %.2f hPa", presCal);
  display.setCursor(0,40);
  display.printf("T: %.2f C", tempCal);

  // Estado WiFi + IP en una sola línea (o DESCONECTADO)
  display.setCursor(0,48);
  if (wifiConnected) {
    display.printf("C. IP:%s", wifiIP.c_str());
  } else {
    display.printf("D. IP:%s", wifiIP.c_str());
  }

  display.setCursor(0,56);
  display.println("B1: Volver");
  display.display();
}

void mostrarPagina(int pagina) {
  // Llamado por actualizarPantalla
  switch (pagina) {
    case 1:
      mostrarPaginaMedidas();
      return;
    case 2:
      if (subMenuCalibracion == 0) mostrarSubMenuCalibracion();
      else if (subMenuCalibracion == 1) mostrarCalibracionHumedad();
      else if (subMenuCalibracion == 2) mostrarCalibracionPresion();
      else if (subMenuCalibracion == 3) mostrarCalibracionTemperatura();
      return;
  }
}

// ----------------- Actualización de pantalla -----------------
void actualizarPantalla() {
  display.clearDisplay();
  if (currentMenu == 0) {
    mostrarMenuPrincipal();
  } else {
    mostrarPagina(currentMenu);
  }
  // Si estamos en calibración y editando, mostrar la pantalla correspondiente ya hace display.display()
  // pero aquí hacemos display.display() al final por seguridad (salvo que ya lo haya hecho)
  if (!(currentMenu == 2 && subMenuCalibracion != 0)) display.display();
}

// ----------------- Mensajes de error en OLED -----------------
void mostrarErrorOLED(const char* mensaje) {
  display.clearDisplay();
  display.setCursor(0,0);
  display.println("ERROR:");
  display.println(mensaje);
  display.display();
}

// ------------------------------------------------------------------
// FIN del sketch
// ------------------------------------------------------------------
