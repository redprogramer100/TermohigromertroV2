using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace termohigrometro_RTHP_V1
{
    public partial class graf : Form
    {
        public graf()
        {
            InitializeComponent();
            this.Size = new Size(870, 342);
        }

        private void graf_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            // Configuración básica de ChartArea
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM HH:mm";
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            // Activar zoom y scroll
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            // Configurar ComboBox
            cmbVariable.Items.AddRange(new string[] { "Temperatura", "Humedad", "Presion" });
            cmbVariable.SelectedIndex = 0;

        }

        List<(DateTime fechaHora, double valor)> LeerDatosCSV(
       DateTime inicio,
       DateTime fin,
       string variable)
        {
            List<(DateTime, double)> lista = new List<(DateTime, double)>();

            string carpeta = LeerRutaDatos();
            string archivo = Path.Combine(carpeta, "Datos_Ambientales_RTHP_V1.csv");

            if (!File.Exists(archivo))
                return lista;

            int colValor = -1;

            switch (variable)
            {
                case "Temperatura": colValor = 2; break;
                case "Humedad": colValor = 4; break;
                case "Presion": colValor = 6; break;
                default: return lista;
            }

            var lineas = File.ReadAllLines(archivo).Skip(1);

            foreach (var linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                // 👇 SOPORTA TAB O ;
                string[] p = linea.Contains(";")
                    ? linea.Split(';')
                    : linea.Split('\t');

                if (p.Length <= colValor)
                    continue;

                if (!DateTime.TryParseExact(
                        p[0] + " " + p[1],
                        "dd/MM/yyyy HH:mm:ss",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime fechaHora))
                    continue;

                if (fechaHora < inicio || fechaHora > fin)
                    continue;

                if (double.TryParse(
                        p[colValor],
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out double valor))
                {
                    lista.Add((fechaHora, valor));
                }
            }

            return lista;
        }

        string LeerRutaDatos()
        {
            string carpetaConfig = Path.Combine(Application.StartupPath, "config");
            string archivoRuta = Path.Combine(carpetaConfig, "ruta.txt");

            if (!Directory.Exists(carpetaConfig))
                Directory.CreateDirectory(carpetaConfig);

            if (!File.Exists(archivoRuta))
                throw new Exception("No existe el archivo config\\ruta.txt");

            return File.ReadAllText(archivoRuta).Trim();
        }
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            string variable = cmbVariable.SelectedItem.ToString();
            DateTime inicio = dtInicio.Value.Date;
            DateTime fin = dtFin.Value.Date.AddDays(1).AddSeconds(-1);

            var datos = LeerDatosCSV(inicio, fin, variable);
            if (datos.Count == 0)
            {
                MessageBox.Show("No hay datos en el rango seleccionado");
                return;
            }

            Series serie = new Series(variable)
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle, // o Square, Diamond...
                MarkerSize = 7,
                MarkerColor = Color.Red
            };

            foreach (var d in datos)
                serie.Points.AddXY(d.fechaHora, d.valor);

            chart1.Series.Add(serie);

            // Configurar ejes para zoom interactivo
            chart1.ChartAreas[0].AxisX.Minimum = datos.Min(d => d.fechaHora).ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = datos.Max(d => d.fechaHora).ToOADate();
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(datos.Min(d => d.fechaHora).ToOADate(), datos.Max(d => d.fechaHora).ToOADate());

            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void btnExportarPNG_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    // Generar nombre automáticamente: Variable_FechaHora.png
                    string variable = cmbVariable.SelectedItem.ToString();
                    string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // formato seguro para archivos
                    sfd.FileName = $"{variable}_{fechaHora}.png";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                        MessageBox.Show("Gráfica guardada correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar PNG: " + ex.Message);
            }
        }

        private void ResetZoom_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        }
    }
}
