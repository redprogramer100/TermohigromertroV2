namespace termohigrometro_RTHP_V1
{
    partial class config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config));
            this.guardar = new System.Windows.Forms.Button();
            this.puertoConectado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VerConfig = new System.Windows.Forms.Button();
            this.CambiarConfig = new System.Windows.Forms.Button();
            this.Manual = new System.Windows.Forms.Button();
            this.PanelVerConfig = new System.Windows.Forms.Panel();
            this.ajuste = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rutaContenido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baurateContenido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelCambiarConfig = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtA3 = new System.Windows.Forms.TextBox();
            this.txtA2 = new System.Windows.Forms.TextBox();
            this.btnSeleccionarRuta = new System.Windows.Forms.Button();
            this.cbBaurate = new System.Windows.Forms.ComboBox();
            this.txtA1 = new System.Windows.Forms.TextBox();
            this.cbPuertos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.CambiarIP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.PanelVerConfig.SuspendLayout();
            this.PanelCambiarConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // guardar
            // 
            this.guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guardar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardar.ForeColor = System.Drawing.Color.White;
            this.guardar.Location = new System.Drawing.Point(330, 221);
            this.guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(185, 41);
            this.guardar.TabIndex = 7;
            this.guardar.Text = "GUARDAR CAMBIOS";
            this.guardar.UseVisualStyleBackColor = false;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // puertoConectado
            // 
            this.puertoConectado.Location = new System.Drawing.Point(141, 11);
            this.puertoConectado.Name = "puertoConectado";
            this.puertoConectado.Size = new System.Drawing.Size(379, 22);
            this.puertoConectado.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Puerto";
            // 
            // VerConfig
            // 
            this.VerConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.VerConfig.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerConfig.ForeColor = System.Drawing.Color.White;
            this.VerConfig.Location = new System.Drawing.Point(12, 11);
            this.VerConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VerConfig.Name = "VerConfig";
            this.VerConfig.Size = new System.Drawing.Size(276, 41);
            this.VerConfig.TabIndex = 10;
            this.VerConfig.Text = "Ver Configuracion";
            this.VerConfig.UseVisualStyleBackColor = false;
            this.VerConfig.Click += new System.EventHandler(this.VerConfig_Click);
            // 
            // CambiarConfig
            // 
            this.CambiarConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CambiarConfig.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CambiarConfig.ForeColor = System.Drawing.Color.White;
            this.CambiarConfig.Location = new System.Drawing.Point(12, 56);
            this.CambiarConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CambiarConfig.Name = "CambiarConfig";
            this.CambiarConfig.Size = new System.Drawing.Size(276, 41);
            this.CambiarConfig.TabIndex = 11;
            this.CambiarConfig.Text = "Cambiar Configuracion";
            this.CambiarConfig.UseVisualStyleBackColor = false;
            this.CambiarConfig.Click += new System.EventHandler(this.CambiarConfig_Click);
            // 
            // Manual
            // 
            this.Manual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Manual.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manual.ForeColor = System.Drawing.Color.White;
            this.Manual.Location = new System.Drawing.Point(15, 101);
            this.Manual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Manual.Name = "Manual";
            this.Manual.Size = new System.Drawing.Size(276, 41);
            this.Manual.TabIndex = 13;
            this.Manual.Text = "Manual de Usuario";
            this.Manual.UseVisualStyleBackColor = false;
            this.Manual.Click += new System.EventHandler(this.Manual_Click);
            // 
            // PanelVerConfig
            // 
            this.PanelVerConfig.Controls.Add(this.IP);
            this.PanelVerConfig.Controls.Add(this.label14);
            this.PanelVerConfig.Controls.Add(this.ajuste);
            this.PanelVerConfig.Controls.Add(this.label5);
            this.PanelVerConfig.Controls.Add(this.label4);
            this.PanelVerConfig.Controls.Add(this.rutaContenido);
            this.PanelVerConfig.Controls.Add(this.label3);
            this.PanelVerConfig.Controls.Add(this.baurateContenido);
            this.PanelVerConfig.Controls.Add(this.label2);
            this.PanelVerConfig.Controls.Add(this.puertoConectado);
            this.PanelVerConfig.Controls.Add(this.label1);
            this.PanelVerConfig.Location = new System.Drawing.Point(308, 11);
            this.PanelVerConfig.Name = "PanelVerConfig";
            this.PanelVerConfig.Size = new System.Drawing.Size(541, 193);
            this.PanelVerConfig.TabIndex = 14;
            // 
            // ajuste
            // 
            this.ajuste.Location = new System.Drawing.Point(141, 110);
            this.ajuste.Name = "ajuste";
            this.ajuste.Size = new System.Drawing.Size(379, 22);
            this.ajuste.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ajuste";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "ruta";
            // 
            // rutaContenido
            // 
            this.rutaContenido.Location = new System.Drawing.Point(141, 76);
            this.rutaContenido.Name = "rutaContenido";
            this.rutaContenido.Size = new System.Drawing.Size(379, 22);
            this.rutaContenido.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 23);
            this.label3.TabIndex = 13;
            // 
            // baurateContenido
            // 
            this.baurateContenido.Location = new System.Drawing.Point(141, 45);
            this.baurateContenido.Name = "baurateContenido";
            this.baurateContenido.Size = new System.Drawing.Size(379, 22);
            this.baurateContenido.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Velocidad";
            // 
            // PanelCambiarConfig
            // 
            this.PanelCambiarConfig.Controls.Add(this.CambiarIP);
            this.PanelCambiarConfig.Controls.Add(this.label15);
            this.PanelCambiarConfig.Controls.Add(this.label13);
            this.PanelCambiarConfig.Controls.Add(this.label12);
            this.PanelCambiarConfig.Controls.Add(this.label11);
            this.PanelCambiarConfig.Controls.Add(this.txtA3);
            this.PanelCambiarConfig.Controls.Add(this.txtA2);
            this.PanelCambiarConfig.Controls.Add(this.btnSeleccionarRuta);
            this.PanelCambiarConfig.Controls.Add(this.cbBaurate);
            this.PanelCambiarConfig.Controls.Add(this.txtA1);
            this.PanelCambiarConfig.Controls.Add(this.cbPuertos);
            this.PanelCambiarConfig.Controls.Add(this.label6);
            this.PanelCambiarConfig.Controls.Add(this.guardar);
            this.PanelCambiarConfig.Controls.Add(this.label7);
            this.PanelCambiarConfig.Controls.Add(this.txtRuta);
            this.PanelCambiarConfig.Controls.Add(this.label8);
            this.PanelCambiarConfig.Controls.Add(this.label9);
            this.PanelCambiarConfig.Controls.Add(this.label10);
            this.PanelCambiarConfig.Location = new System.Drawing.Point(166, 240);
            this.PanelCambiarConfig.Name = "PanelCambiarConfig";
            this.PanelCambiarConfig.Size = new System.Drawing.Size(528, 275);
            this.PanelCambiarConfig.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(326, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 23);
            this.label13.TabIndex = 23;
            this.label13.Text = "P[hpa]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(241, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "H[%]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(149, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "T[°C]";
            // 
            // txtA3
            // 
            this.txtA3.Location = new System.Drawing.Point(321, 144);
            this.txtA3.Name = "txtA3";
            this.txtA3.Size = new System.Drawing.Size(84, 22);
            this.txtA3.TabIndex = 20;
            // 
            // txtA2
            // 
            this.txtA2.Location = new System.Drawing.Point(231, 144);
            this.txtA2.Name = "txtA2";
            this.txtA2.Size = new System.Drawing.Size(84, 22);
            this.txtA2.TabIndex = 19;
            // 
            // btnSeleccionarRuta
            // 
            this.btnSeleccionarRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSeleccionarRuta.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarRuta.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarRuta.Location = new System.Drawing.Point(374, 70);
            this.btnSeleccionarRuta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeleccionarRuta.Name = "btnSeleccionarRuta";
            this.btnSeleccionarRuta.Size = new System.Drawing.Size(146, 31);
            this.btnSeleccionarRuta.TabIndex = 18;
            this.btnSeleccionarRuta.Text = "Sel. Ruta";
            this.btnSeleccionarRuta.UseVisualStyleBackColor = false;
            this.btnSeleccionarRuta.Click += new System.EventHandler(this.btnSeleccionarRuta_Click);
            // 
            // cbBaurate
            // 
            this.cbBaurate.FormattingEnabled = true;
            this.cbBaurate.Location = new System.Drawing.Point(141, 46);
            this.cbBaurate.Name = "cbBaurate";
            this.cbBaurate.Size = new System.Drawing.Size(379, 24);
            this.cbBaurate.TabIndex = 18;
            // 
            // txtA1
            // 
            this.txtA1.Location = new System.Drawing.Point(141, 144);
            this.txtA1.Name = "txtA1";
            this.txtA1.Size = new System.Drawing.Size(84, 22);
            this.txtA1.TabIndex = 16;
            // 
            // cbPuertos
            // 
            this.cbPuertos.FormattingEnabled = true;
            this.cbPuertos.Location = new System.Drawing.Point(141, 15);
            this.cbPuertos.Name = "cbPuertos";
            this.cbPuertos.Size = new System.Drawing.Size(379, 24);
            this.cbPuertos.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ajuste";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "ruta";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(141, 76);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(227, 22);
            this.txtRuta.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 23);
            this.label8.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(16, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 23);
            this.label9.TabIndex = 11;
            this.label9.Text = "Velocidad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(16, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Puerto";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(15, 146);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 41);
            this.button1.TabIndex = 18;
            this.button1.Text = "Manual de Instalacion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(16, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 23);
            this.label14.TabIndex = 17;
            this.label14.Text = "IP";
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(141, 144);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(379, 22);
            this.IP.TabIndex = 18;
            // 
            // CambiarIP
            // 
            this.CambiarIP.Location = new System.Drawing.Point(136, 182);
            this.CambiarIP.Name = "CambiarIP";
            this.CambiarIP.Size = new System.Drawing.Size(379, 22);
            this.CambiarIP.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(16, 180);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 23);
            this.label15.TabIndex = 19;
            this.label15.Text = "IP";
            // 
            // config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(870, 577);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PanelCambiarConfig);
            this.Controls.Add(this.PanelVerConfig);
            this.Controls.Add(this.Manual);
            this.Controls.Add(this.CambiarConfig);
            this.Controls.Add(this.VerConfig);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "config";
            this.Text = "config";
            this.Load += new System.EventHandler(this.config_Load);
            this.PanelVerConfig.ResumeLayout(false);
            this.PanelVerConfig.PerformLayout();
            this.PanelCambiarConfig.ResumeLayout(false);
            this.PanelCambiarConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.TextBox puertoConectado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VerConfig;
        private System.Windows.Forms.Button CambiarConfig;
        private System.Windows.Forms.Button Manual;
        private System.Windows.Forms.Panel PanelVerConfig;
        private System.Windows.Forms.TextBox rutaContenido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox baurateContenido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ajuste;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel PanelCambiarConfig;
        private System.Windows.Forms.TextBox txtA3;
        private System.Windows.Forms.TextBox txtA2;
        private System.Windows.Forms.Button btnSeleccionarRuta;
        private System.Windows.Forms.ComboBox cbBaurate;
        private System.Windows.Forms.ComboBox cbPuertos;
        private System.Windows.Forms.TextBox txtA1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox CambiarIP;
        private System.Windows.Forms.Label label15;
    }
}