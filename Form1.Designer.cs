namespace termohigrometro_RTHP_V1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.temp = new System.Windows.Forms.TextBox();
            this.tempU = new System.Windows.Forms.TextBox();
            this.humU = new System.Windows.Forms.TextBox();
            this.hum = new System.Windows.Forms.TextBox();
            this.presU = new System.Windows.Forms.TextBox();
            this.pres = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Desconectar = new System.Windows.Forms.Button();
            this.configuracion = new System.Windows.Forms.Button();
            this.graficas = new System.Windows.Forms.Button();
            this.panelLed = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.ventanas = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.serialConexion = new System.Windows.Forms.RadioButton();
            this.IpConexion = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnConectar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConectar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.Location = new System.Drawing.Point(0, 0);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(185, 41);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "CONECTAR";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtDatos
            // 
            this.txtDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDatos.Location = new System.Drawing.Point(0, 0);
            this.txtDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatos.Multiline = true;
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.Size = new System.Drawing.Size(200, 399);
            this.txtDatos.TabIndex = 2;
            this.txtDatos.UseSystemPasswordChar = true;
            // 
            // temp
            // 
            this.temp.Location = new System.Drawing.Point(757, 54);
            this.temp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(81, 22);
            this.temp.TabIndex = 9;
            // 
            // tempU
            // 
            this.tempU.Location = new System.Drawing.Point(848, 54);
            this.tempU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tempU.Name = "tempU";
            this.tempU.Size = new System.Drawing.Size(63, 22);
            this.tempU.TabIndex = 10;
            // 
            // humU
            // 
            this.humU.Location = new System.Drawing.Point(1015, 53);
            this.humU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.humU.Name = "humU";
            this.humU.Size = new System.Drawing.Size(63, 22);
            this.humU.TabIndex = 12;
            // 
            // hum
            // 
            this.hum.Location = new System.Drawing.Point(927, 53);
            this.hum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hum.Name = "hum";
            this.hum.Size = new System.Drawing.Size(81, 22);
            this.hum.TabIndex = 11;
            // 
            // presU
            // 
            this.presU.Location = new System.Drawing.Point(1180, 54);
            this.presU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.presU.Name = "presU";
            this.presU.Size = new System.Drawing.Size(63, 22);
            this.presU.TabIndex = 14;
            // 
            // pres
            // 
            this.pres.Location = new System.Drawing.Point(1092, 54);
            this.pres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pres.Name = "pres";
            this.pres.Size = new System.Drawing.Size(81, 22);
            this.pres.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1255, 39);
            this.panel1.TabIndex = 15;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "TERMOHIGROMETRO DE LABORATORIO RTHP_V1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1187, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 39);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1216, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panelLed);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 653);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Desconectar);
            this.panel3.Controls.Add(this.configuracion);
            this.panel3.Controls.Add(this.graficas);
            this.panel3.Controls.Add(this.btnConectar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 311);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 330);
            this.panel3.TabIndex = 4;
            // 
            // Desconectar
            // 
            this.Desconectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Desconectar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Desconectar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desconectar.ForeColor = System.Drawing.Color.White;
            this.Desconectar.Location = new System.Drawing.Point(0, 123);
            this.Desconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(185, 41);
            this.Desconectar.TabIndex = 7;
            this.Desconectar.Text = "DESCONECTAR";
            this.Desconectar.UseVisualStyleBackColor = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // configuracion
            // 
            this.configuracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.configuracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.configuracion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configuracion.ForeColor = System.Drawing.Color.White;
            this.configuracion.Location = new System.Drawing.Point(0, 82);
            this.configuracion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.configuracion.Name = "configuracion";
            this.configuracion.Size = new System.Drawing.Size(185, 41);
            this.configuracion.TabIndex = 6;
            this.configuracion.Text = "CONFIGURACION";
            this.configuracion.UseVisualStyleBackColor = false;
            this.configuracion.Click += new System.EventHandler(this.configuracion_Click);
            // 
            // graficas
            // 
            this.graficas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.graficas.Dock = System.Windows.Forms.DockStyle.Top;
            this.graficas.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graficas.ForeColor = System.Drawing.Color.White;
            this.graficas.Location = new System.Drawing.Point(0, 41);
            this.graficas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graficas.Name = "graficas";
            this.graficas.Size = new System.Drawing.Size(185, 41);
            this.graficas.TabIndex = 4;
            this.graficas.Text = "GRAFICAR";
            this.graficas.UseVisualStyleBackColor = false;
            this.graficas.Click += new System.EventHandler(this.graficas_Click);
            // 
            // panelLed
            // 
            this.panelLed.BackColor = System.Drawing.Color.Transparent;
            this.panelLed.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLed.Location = new System.Drawing.Point(0, 151);
            this.panelLed.Name = "panelLed";
            this.panelLed.Size = new System.Drawing.Size(185, 160);
            this.panelLed.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.ErrorImage")));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(185, 151);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(185, 438);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1070, 254);
            this.dataGridView1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtDatos);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(185, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 399);
            this.panel5.TabIndex = 18;
            // 
            // ventanas
            // 
            this.ventanas.BackColor = System.Drawing.Color.Black;
            this.ventanas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ventanas.Location = new System.Drawing.Point(385, 96);
            this.ventanas.Name = "ventanas";
            this.ventanas.Size = new System.Drawing.Size(870, 342);
            this.ventanas.TabIndex = 19;
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // serialConexion
            // 
            this.serialConexion.AutoSize = true;
            this.serialConexion.Location = new System.Drawing.Point(391, 56);
            this.serialConexion.Name = "serialConexion";
            this.serialConexion.Size = new System.Drawing.Size(160, 20);
            this.serialConexion.TabIndex = 20;
            this.serialConexion.TabStop = true;
            this.serialConexion.Text = "Modo Conexion Serial";
            this.serialConexion.UseVisualStyleBackColor = true;
            // 
            // IpConexion
            // 
            this.IpConexion.AutoSize = true;
            this.IpConexion.Location = new System.Drawing.Point(602, 56);
            this.IpConexion.Name = "IpConexion";
            this.IpConexion.Size = new System.Drawing.Size(137, 20);
            this.IpConexion.TabIndex = 21;
            this.IpConexion.TabStop = true;
            this.IpConexion.Text = "Modo Conexion IP";
            this.IpConexion.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1255, 692);
            this.Controls.Add(this.IpConexion);
            this.Controls.Add(this.serialConexion);
            this.Controls.Add(this.ventanas);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.presU);
            this.Controls.Add(this.pres);
            this.Controls.Add(this.humU);
            this.Controls.Add(this.hum);
            this.Controls.Add(this.tempU);
            this.Controls.Add(this.temp);
            this.ForeColor = System.Drawing.Color.Brown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtDatos;
        private System.Windows.Forms.TextBox temp;
        private System.Windows.Forms.TextBox tempU;
        private System.Windows.Forms.TextBox humU;
        private System.Windows.Forms.TextBox hum;
        private System.Windows.Forms.TextBox presU;
        private System.Windows.Forms.TextBox pres;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelLed;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button graficas;
        private System.Windows.Forms.Button configuracion;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel ventanas;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.RadioButton serialConexion;
        private System.Windows.Forms.RadioButton IpConexion;
    }
}

