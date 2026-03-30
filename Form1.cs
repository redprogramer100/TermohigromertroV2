using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace termohigrometro_RTHP_V1
{

    public partial class Form1 : Form
    {
        // Estado actual de los 6 datos
        double gTemp = 0;
        string gTempU = "";

        double gHum = 0;
        string gHumU = "";

        double gPres = 0;
        string gPresU = "";

        private const int MAX_FILAS = 10;
        SerialPort serial = new SerialPort();

        //variables dinamicas para el led
        bool ledEncendido = false;
        Color colorLed = Color.Green;     // Verde por defecto
        Color colorOriginal;

        //ventanas
        private config formConfiguaracion;
        private graf formGraficas;
        string datos_Serial;

        public Form1()
        {
            InitializeComponent();

            // Activar doble buffer para evitar parpadeo
            panelLed.Paint += panelLed_Paint;

            colorOriginal = Color.FromArgb(70, colorLed);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            IpConexion.Checked= true;
            btnConectar_Click(null, e);
        }

        private async void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialConexion.Checked)
                {
                    if (!serial.IsOpen)
                    {
                        // Leer configuración directamente desde los archivos
                        string puerto = LeerOcrear("puerto.txt", "COM8");
                        string baurateStr = LeerOcrear("baurate.txt", "9600");

                        int baurate;
                        if (!int.TryParse(baurateStr, out baurate))
                            baurate = 9600; // valor por defecto si hay error

                        // Configurar serial
                        serial.PortName = puerto;
                        serial.BaudRate = baurate;
                        serial.NewLine = "\r";
                        serial.DataReceived += Serial_DataReceived;
                        serial.Open();

                        timer3.Start();
                        timer3.Interval = 3000; // cada 2 segundos

                        btnConectar.Text = "CONECTADO";

                        AgregarLog("Conectado a " + " " + puerto + " " + baurateStr);
                    }
                    else
                    {
                        string puerto = LeerOcrear("puerto.txt", "COM8");
                        string baurateStr = LeerOcrear("baurate.txt", "9600");
                        serial.Close();
                        // Remover event handler al desconectar
                        serial.DataReceived -= Serial_DataReceived;
                        btnConectar.Text = "DESCONECTADO";
                        EncenderLed(Color.Yellow);

                        AgregarLog("Error al conectar: Su Pc no se conecta a " + " " + puerto + " " + baurateStr + " " + "Revice si los parametros de "
                            + "conexion son correctos");

                    }
                }
                else if (IpConexion.Checked)
                {
                    try
                    {
                        string ip = LeerIP();

                        var datos = await LeerESP32Async(ip);
                        AgregarLog("conexion IP"+ ip);

                        timer2.Start();
                    }
                    catch (Exception ex)
                    {
                        string ip = LeerIP();
                        AgregarLog("Error al conectarce a la " + ip);
                    }


                }
                else
                {
                    AgregarLog("No se pudo conectar a ningun puerto");
                }

            }
            catch (Exception ex)
            {
                AgregarLog("Error al conectar: " + ex.Message);
                EncenderLed(Color.Red);
            }
        }
        void AgregarLog(string mensaje)
        {
            int maxLineas = 100; // límite de líneas

            txtDatos.AppendText(mensaje + Environment.NewLine);

            if (txtDatos.Lines.Length > maxLineas)
            {
                txtDatos.Lines = txtDatos.Lines
                    .Skip(txtDatos.Lines.Length - maxLineas)
                    .ToArray();
            }
        }
        // Leer o crear archivo con valor por defecto
        string LeerOcrear(string nombreArchivo, string valorDefecto)
        {
            string rutaArchivo = Path.Combine(Application.StartupPath, "config", nombreArchivo);

            if (!File.Exists(rutaArchivo))
                File.WriteAllText(rutaArchivo, valorDefecto);

            return File.ReadAllText(rutaArchivo).Trim();
        }

        double gTemp1, gHum1, gPres1;

        public void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string linea = serial.ReadLine().Trim();
                Console.WriteLine($"Línea recibida: {linea}");

                // Validar formato
                if (!linea.StartsWith("#") || !linea.EndsWith("/V"))
                    return;

                // Quitar # y /V
                string datos = linea.Substring(1, linea.Length - 3);

                // Separar
                string[] partes = datos.Split('/');

                if (partes.Length != 3)
                    return;

                // Convertir (punto decimal SIEMPRE correcto)
                gTemp1 = double.Parse(partes[0], CultureInfo.InvariantCulture);
                gHum1 = double.Parse(partes[1], CultureInfo.InvariantCulture);
                gPres1 = double.Parse(partes[2], CultureInfo.InvariantCulture);

                Console.WriteLine($"Datos recibidos: Temp={gTemp1}, Hum={gHum1}, Pres={gPres1}");

                // 🔵 ACTUALIZAR UI (thread seguro)
                BeginInvoke(new Action(() =>
                {
                    gTemp = gTemp1;
                    gHum = gHum1;
                    gPres = gPres1;
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en recepción: {ex.Message}");
            }
        }

        (double tempAjuste, double humAjuste, double presAjuste) LeerAjustes()
        {
            string carpetaConfig = Path.Combine(Application.StartupPath, "config");
            string archivo = Path.Combine(carpetaConfig, "ajusteDeParametros.txt");

            // Crear carpeta si no existe
            if (!Directory.Exists(carpetaConfig))
                Directory.CreateDirectory(carpetaConfig);

            // Crear archivo con ceros si no existe
            if (!File.Exists(archivo))
                File.WriteAllText(archivo, "0;0;0");

            string contenido = File.ReadAllText(archivo).Trim();
            string[] partes = contenido.Split(';');

            double t = 0, h = 0, p = 0;

            if (partes.Length >= 3)
            {
                double.TryParse(partes[0], out t);
                double.TryParse(partes[1], out h);
                double.TryParse(partes[2], out p);
            }

            return (t, h, p);
        }



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //----------------CREAR EL DATAGREDVIEW

        private void ConfigurarDataGridView()
        {
            // Limpia por si ya tiene algo
            dataGridView1.Columns.Clear();

            // Diseño visual
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Crear las 6 columnas
            dataGridView1.Columns.Add("Fecha", "Fecha");
            dataGridView1.Columns.Add("Hora", "Hora");
            dataGridView1.Columns.Add("Temp", "Temperatura");
            dataGridView1.Columns.Add("TempU", "U");
            dataGridView1.Columns.Add("Hum", "Humedad");
            dataGridView1.Columns.Add("HumU", "U");
            dataGridView1.Columns.Add("Pres", "Presión");
            dataGridView1.Columns.Add("PresU", "U");

            // Opcional: color de encabezado
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
        private void AgregarDatos(
          string temp, string tempU,
          string hum, string humU,
          string pres, string presU)
        {
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            string hora = DateTime.Now.ToString("HH:mm:ss");

            dataGridView1.Rows.Add(
                fecha, hora,
                temp, tempU,
                hum, humU,
                pres, presU
            );

            // Si supera 50 filas, eliminar la más antigua
            if (dataGridView1.Rows.Count > MAX_FILAS)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
        }
        //
        string LeerRutaDatos()
        {
            string carpetaConfig = Path.Combine(Application.StartupPath, "config");
            string archivoRuta = Path.Combine(carpetaConfig, "ruta.txt");

            // Asegurar que exista la carpeta config
            if (!Directory.Exists(carpetaConfig))
                Directory.CreateDirectory(carpetaConfig);

            // Si no existe el archivo, lanzar error o crear uno vacío
            if (!File.Exists(archivoRuta))
                throw new Exception("No existe el archivo config\\ruta.txt");

            return File.ReadAllText(archivoRuta).Trim();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!serial.IsOpen)
            {
                serial.Close();
            }
            this.Close();  //cierra la ventana 
        }
        /// <summary>
        /// Abrir otros From para usarlos como otras funsiones
        ///        
        private Form AbrirFormEnPanel(Form formhija)
        {
            if (this.ventanas.Controls.Count > 0)
                this.ventanas.Controls.RemoveAt(0);

            formhija.TopLevel = false;
            formhija.Dock = DockStyle.Fill;
            this.ventanas.Controls.Add(formhija);
            this.ventanas.Tag = formhija;
            formhija.Show();

            return formhija; // ⬅️ devolvemos la referencia al hijo
        }




        //indicador de led
        void EncenderLed(Color color)
        {
            colorLed = color;
            colorOriginal = Color.FromArgb(70, color);

            ledEncendido = true;
            panelLed.Invalidate();

            timer1.Stop();
            timer1.Start();
        }
        private void panelLed_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                5,
                5,
                panelLed.Width - 10,
                panelLed.Height - 10
            );

            if (ledEncendido)
            {
                // COLOR PRINCIPAL (dinámico)
                using (Brush brush = new SolidBrush(colorLed))
                {
                    g.FillEllipse(brush, rect);
                }

                // BRILLO (mismo color pero más claro)
                using (Brush glow = new SolidBrush(Color.FromArgb(180, ControlPaint.Light(colorLed))))
                {
                    g.FillEllipse(glow,
                        rect.X + 6,
                        rect.Y + 6,
                        rect.Width - 12,
                        rect.Height - 12);
                }
            }
            else
            {
                // APAGADO (color oscuro del mismo tono)
                using (Brush brush = new SolidBrush(Color.FromArgb(70, colorLed)))
                {
                    g.FillEllipse(brush, rect);
                }
            }

            // BORDE
            using (Pen pen = new Pen(ControlPaint.Dark(colorLed), 2))
            {
                g.DrawEllipse(pen, rect);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            ledEncendido = false;
            panelLed.Invalidate();
            timer1.Stop();
        }


        private void configuracion_Click(object sender, EventArgs e)
        {
            EncenderLed(Color.Yellow);
            if (formConfiguaracion == null || formConfiguaracion.IsDisposed)
            {
                formConfiguaracion = new config();
               // this.ValoresActualizados += formGraficas.ActualizarValor;  //para pasar datos del from padre al hijo
            }
            AbrirFormEnPanel(formConfiguaracion);

        }

        private void Desconectar_Click(object sender, EventArgs e)
        {


            if (serialConexion.Checked)
            {
                serial.Close();
                EncenderLed(Color.Red);
                timer3.Stop();
                AgregarLog("Puerto Desconectado");
            }
            else if (IpConexion.Checked)
            {
                timer2.Stop();
                EncenderLed(Color.Orange);
                AgregarLog("Conexion IP desconectada");
            }


        }

        private void graficas_Click(object sender, EventArgs e)
        {
            if (formGraficas == null || formGraficas.IsDisposed)
            {
                formGraficas = new graf();
                // this.ValoresActualizados += formGraficas.ActualizarValor;  //para pasar datos del from padre al hijo
            }
            AbrirFormEnPanel(formGraficas);
        }

        //------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// CODIGO PARA LECTURA POR IP
        /// </summary>
        string LeerIP()
        {
            string ruta = Path.Combine(Application.StartupPath, "config", "ip.txt");

            if (!File.Exists(ruta))
                throw new Exception("No existe config\\ip.txt");

            return File.ReadAllText(ruta).Trim();
        }
        string FechaActual()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        string HoraActual()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        async Task<(double hum, double temp, double pres)> LeerESP32Async(string ip)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://{ip}/data";
                string raw = await client.GetStringAsync(url);

                // raw = "{45.23,23.11,1013.55}"
                raw = raw.Replace("{", "").Replace("}", "");

                var p = raw.Split(',');

                return (
                    double.Parse(p[0], CultureInfo.InvariantCulture),
                    double.Parse(p[1], CultureInfo.InvariantCulture),
                    double.Parse(p[2], CultureInfo.InvariantCulture)
                );
            }
        }

        void GuardarCSV(string fecha, string hora, double hum, double temp, double pres)
        {
            try
            {
                // 👈 RUTA LEÍDA DESDE config\ruta.txt
                string carpeta = LeerRutaDatos();

                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string archivo = Path.Combine(carpeta, "Datos_Ambientales_RTHP_V1.csv");

                bool existe = File.Exists(archivo);

                using (StreamWriter sw = new StreamWriter(archivo, true, Encoding.UTF8))
                {
                    if (!existe)
                    {
                        sw.WriteLine("Fecha;Hora;Temperatura;UnidadTemp;Humedad;UnidadHum;Presion;UnidadPres");
                    }

                    sw.WriteLine(
                        $"{fecha};{hora};" +
                        $"{temp.ToString("0.###", CultureInfo.InvariantCulture)};°C;" +
                        $"{hum.ToString("0.###", CultureInfo.InvariantCulture)};%RH;" +
                        $"{pres.ToString("0.###", CultureInfo.InvariantCulture)};hPa"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar CSV: " + ex.Message);
            }
        }


        private async void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                string ip = LeerIP();

                var datos = await LeerESP32Async(ip);

                string fecha = FechaActual();
                string hora = HoraActual();

                //varaibles
                var ajustes = LeerAjustes();
                double valor = 0;
                //humedad
                valor = datos.hum;
                valor += ajustes.humAjuste;
                hum.Text = valor.ToString("0.###");
                humU.Text = "%RH";
                gHum = valor;

                //temperatura   
                valor = datos.temp;
                valor += ajustes.tempAjuste;
                temp.Text = valor.ToString("0.###");
                tempU.Text = "°C";
                gTemp = valor;

                //presion
                valor = datos.pres;
                valor += ajustes.presAjuste;
                pres.Text = valor.ToString("0.###");
                presU.Text = "hPa";
                gPres = valor;

                GuardarCSV(fecha, hora, gHum, gTemp, gPres);
                AgregarDatos(
                                gTemp.ToString("0.###"), "°C",
                                gHum.ToString("0.###"), "%RH",
                                gPres.ToString("0.###"), "hPa"
                            );
                EncenderLed(Color.Green);
                AgregarLog("Datos guardados correctamente");
            }
            catch (Exception ex)
            {
                EncenderLed(Color.Red);
                AgregarLog("Error: " + ex.Message);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //varaibles
            var ajustes = LeerAjustes();
            double valor = 0;
            string fecha = FechaActual();
            string hora = HoraActual();
            //humedad
            valor = gHum;
            valor += ajustes.humAjuste;
            hum.Text = valor.ToString("0.###");
            humU.Text = "%RH";
            gHum = valor;

            //temperatura   
            valor = gTemp;
            valor += ajustes.tempAjuste;
            temp.Text = valor.ToString("0.###");
            tempU.Text = "°C";
            gTemp = valor;

            //presion
            valor = gPres;
            valor += ajustes.presAjuste;
            pres.Text = valor.ToString("0.###");
            presU.Text = "hPa";
            gPres = valor;

            GuardarCSV(fecha, hora, gHum, gTemp, gPres);
            AgregarDatos(
                            gTemp.ToString("0.###"), "°C",
                            gHum.ToString("0.###"), "%RH",
                            gPres.ToString("0.###"), "hPa"
                        );
            EncenderLed(Color.Blue);

        }
    }
}
