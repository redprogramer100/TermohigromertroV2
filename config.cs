using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace termohigrometro_RTHP_V1
{
    public partial class config : Form
    {
        string carpetaConfig;
        string carpetaDatos;
        string rutaManual = Path.Combine(Application.StartupPath, "Manual", "M1.pdf");
        public config()
        {
            InitializeComponent();
            this.Size = new Size(870, 342);

            carpetaConfig = Path.Combine(Application.StartupPath, "config");
            carpetaDatos = Path.Combine(Application.StartupPath, "Datos");

            CargarPuertos();
            CargarBaurates();
        }
        // CARGAR EL FORMULARIO Y SUS COMPONENTES
        void CargarPuertos()
        {
            cbPuertos.Items.Clear();
            cbPuertos.Items.AddRange(SerialPort.GetPortNames());

            if (cbPuertos.Items.Count > 0)
                cbPuertos.SelectedIndex = 0;
        }
        void CargarBaurates()
        {
            cbBaurate.Items.Clear();
            cbBaurate.Items.AddRange(new object[]
            {
        "9600", "19200", "38400", "57600", "115200"
            });

            cbBaurate.SelectedIndex = 0;
        }
        private void VerConfig_Click(object sender, EventArgs e)
        {
            puertoConectado.Text = LeerOcrear("puerto.txt", "COM8");
            baurateContenido.Text = LeerOcrear("baurate.txt", "9600");
            ajuste.Text = LeerOcrear("ajusteDeParametros.txt", "0;0;0");
            rutaContenido.Text = LeerRutaDatos();
            IP.Text = LeerOcrear("ip.txt", "192.168.0.24");


            // Configurar tamaño y posición antes de mostrar
            PanelVerConfig.Location = new Point(220, 20);
            PanelVerConfig.Size = new Size(541, 155);
            PanelVerConfig.Visible = true;

            // Ocultar el otro panel
            PanelCambiarConfig.Visible = false;
        }

        // FUNCIÓN GENERAL PARA LEER O CREAR ARCHIVOS
        string LeerOcrear(string nombreArchivo, string valorDefecto)
        {
            if (!Directory.Exists(carpetaConfig))
                Directory.CreateDirectory(carpetaConfig);

            string rutaArchivo = Path.Combine(carpetaConfig, nombreArchivo);

            if (!File.Exists(rutaArchivo))
                File.WriteAllText(rutaArchivo, valorDefecto);

            return File.ReadAllText(rutaArchivo).Trim();
        }

        // FUNCIÓN ESPECIAL PARA LA RUTA DE DATOS
        string LeerRutaDatos()
        {
            if (!Directory.Exists(carpetaConfig))
                Directory.CreateDirectory(carpetaConfig);

            if (!Directory.Exists(carpetaDatos))
                Directory.CreateDirectory(carpetaDatos);

            string archivoRuta = Path.Combine(carpetaConfig, "ruta.txt");

            if (!File.Exists(archivoRuta))
                File.WriteAllText(archivoRuta, carpetaDatos);

            return File.ReadAllText(archivoRuta).Trim();
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
        private void CambiarConfig_Click(object sender, EventArgs e)
        {
            var ajustes = LeerAjustes();
            txtA1.Text = ajustes.tempAjuste.ToString();
            txtA2.Text = ajustes.humAjuste.ToString();
            txtA3.Text = ajustes.presAjuste.ToString();

            txtRuta.Text = LeerRutaDatos();
            CambiarIP.Text = LeerOcrear("ip.txt", "192.168.0.24");

            PanelCambiarConfig.Location = new Point(220, 20);
            PanelCambiarConfig.Size = new Size(528, 224);
            PanelCambiarConfig.Visible = true;

            // Ocultar el otro panel
            PanelVerConfig.Visible = false;
            CargarPuertos();
            CargarBaurates();
        }

        private void Manual_Click(object sender, EventArgs e)
        {
            string rutaManual = Path.Combine(Application.StartupPath, "Manual", "M1.pdf");

            if (File.Exists(rutaManual))
            {
                try
                {
                    // Abre con la aplicación predeterminada (Adobe Reader, Edge, Chrome, etc.)
                    Process.Start(new ProcessStartInfo(rutaManual) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el PDF: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo .pdf");
            }
        }

        private void config_Load(object sender, EventArgs e)
        {
            PanelVerConfig.Visible = false;
            PanelCambiarConfig.Visible = false;
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione carpeta de DATOS";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = fbd.SelectedPath;
                }
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(carpetaConfig))
                Directory.CreateDirectory(carpetaConfig);

            // PUERTO
            File.WriteAllText(
                Path.Combine(carpetaConfig, "puerto.txt"),
                cbPuertos.Text
            );

            // BAURATE
            File.WriteAllText(
                Path.Combine(carpetaConfig, "baurate.txt"),
                cbBaurate.Text
            );

            // RUTA
            if (!Directory.Exists(txtRuta.Text))
                Directory.CreateDirectory(txtRuta.Text);

            File.WriteAllText(
                Path.Combine(carpetaConfig, "ruta.txt"),
                txtRuta.Text
            );

            // AJUSTE DE PARÁMETROS
            string ajuste = $"{txtA1.Text};{txtA2.Text};{txtA3.Text}";

            File.WriteAllText(
                Path.Combine(carpetaConfig, "ajusteDeParametros.txt"),
                ajuste
            );

            MessageBox.Show("Configuración guardada correctamente",
                            "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rutaManual = Path.Combine(Application.StartupPath, "Manual", "M2.pdf");

            if (File.Exists(rutaManual))
            {
                try
                {
                    // Abre con la aplicación predeterminada (Adobe Reader, Edge, Chrome, etc.)
                    Process.Start(new ProcessStartInfo(rutaManual) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el PDF: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo .pdf");
            }
        }
    }
}
