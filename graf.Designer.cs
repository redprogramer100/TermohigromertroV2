namespace termohigrometro_RTHP_V1
{
    partial class graf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.cmbVariable = new System.Windows.Forms.ComboBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportarPNG = new System.Windows.Forms.Button();
            this.ResetZoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtInicio
            // 
            this.dtInicio.Location = new System.Drawing.Point(12, 3);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(200, 22);
            this.dtInicio.TabIndex = 0;
            // 
            // dtFin
            // 
            this.dtFin.Location = new System.Drawing.Point(12, 31);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(200, 22);
            this.dtFin.TabIndex = 1;
            // 
            // cmbVariable
            // 
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Location = new System.Drawing.Point(231, 14);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(116, 24);
            this.cmbVariable.TabIndex = 2;
            // 
            // btnGraficar
            // 
            this.btnGraficar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGraficar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficar.ForeColor = System.Drawing.Color.White;
            this.btnGraficar.Location = new System.Drawing.Point(522, 3);
            this.btnGraficar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(128, 41);
            this.btnGraficar.TabIndex = 3;
            this.btnGraficar.Text = "GRAFICAR";
            this.btnGraficar.UseVisualStyleBackColor = false;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 58);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(846, 272);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // btnExportarPNG
            // 
            this.btnExportarPNG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExportarPNG.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPNG.ForeColor = System.Drawing.Color.White;
            this.btnExportarPNG.Location = new System.Drawing.Point(656, 3);
            this.btnExportarPNG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportarPNG.Name = "btnExportarPNG";
            this.btnExportarPNG.Size = new System.Drawing.Size(73, 41);
            this.btnExportarPNG.TabIndex = 5;
            this.btnExportarPNG.Text = "PNG";
            this.btnExportarPNG.UseVisualStyleBackColor = false;
            this.btnExportarPNG.Click += new System.EventHandler(this.btnExportarPNG_Click);
            // 
            // ResetZoom
            // 
            this.ResetZoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ResetZoom.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetZoom.ForeColor = System.Drawing.Color.White;
            this.ResetZoom.Location = new System.Drawing.Point(735, 3);
            this.ResetZoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetZoom.Name = "ResetZoom";
            this.ResetZoom.Size = new System.Drawing.Size(123, 41);
            this.ResetZoom.TabIndex = 6;
            this.ResetZoom.Text = "ResetZoom";
            this.ResetZoom.UseVisualStyleBackColor = false;
            this.ResetZoom.Click += new System.EventHandler(this.ResetZoom_Click);
            // 
            // graf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(870, 342);
            this.Controls.Add(this.ResetZoom);
            this.Controls.Add(this.btnExportarPNG);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.cmbVariable);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.dtInicio);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "graf";
            this.Text = "graf";
            this.Load += new System.EventHandler(this.graf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.ComboBox cmbVariable;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnExportarPNG;
        private System.Windows.Forms.Button ResetZoom;
    }
}