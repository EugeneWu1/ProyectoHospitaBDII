namespace ProyectoHospital.Modulos.Servicios
{
    partial class frmCirugiaAgendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCirugiaAgendar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.clsButton = new System.Windows.Forms.PictureBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.dgScheduledSurgeries = new System.Windows.Forms.DataGridView();
            this.cbmedico = new System.Windows.Forms.ComboBox();
            this.description = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtpaciente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PatientId = new System.Windows.Forms.TextBox();
            this.dgPacients = new System.Windows.Forms.DataGridView();
            this.cbquirofano = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgScheduledSurgeries)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPacients)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 73);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(514, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agendar Cirugía";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(1061, 8);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(58, 58);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.TabStop = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 21);
            this.label10.TabIndex = 245;
            this.label10.Text = "Descripcion";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 24);
            this.label8.TabIndex = 244;
            this.label8.Text = "Fecha de uso";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 21);
            this.label11.TabIndex = 241;
            this.label11.Text = "Medico a cargo";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // clsButton
            // 
            this.clsButton.Image = global::ProyectoHospital.Properties.Resources.Clear;
            this.clsButton.Location = new System.Drawing.Point(300, 451);
            this.clsButton.Name = "clsButton";
            this.clsButton.Size = new System.Drawing.Size(47, 44);
            this.clsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clsButton.TabIndex = 239;
            this.clsButton.TabStop = false;
            this.clsButton.Click += new System.EventHandler(this.clsButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(670, 451);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 44);
            this.deleteButton.TabIndex = 238;
            this.deleteButton.Text = "ELIMINAR";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(163, 451);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(112, 44);
            this.updateButton.TabIndex = 237;
            this.updateButton.Text = "EDITAR";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertButton.Location = new System.Drawing.Point(30, 451);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(112, 44);
            this.insertButton.TabIndex = 236;
            this.insertButton.Text = "AGREGAR";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // dgScheduledSurgeries
            // 
            this.dgScheduledSurgeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScheduledSurgeries.Location = new System.Drawing.Point(361, 180);
            this.dgScheduledSurgeries.Name = "dgScheduledSurgeries";
            this.dgScheduledSurgeries.Size = new System.Drawing.Size(758, 250);
            this.dgScheduledSurgeries.TabIndex = 235;
            this.dgScheduledSurgeries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgScheduledSurgeries_CellClick);
            // 
            // cbmedico
            // 
            this.cbmedico.FormattingEnabled = true;
            this.cbmedico.Location = new System.Drawing.Point(21, 319);
            this.cbmedico.Name = "cbmedico";
            this.cbmedico.Size = new System.Drawing.Size(121, 21);
            this.cbmedico.TabIndex = 234;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(20, 201);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(275, 27);
            this.description.TabIndex = 229;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.LightGray;
            this.GroupBox1.Controls.Add(this.txtpaciente);
            this.GroupBox1.Controls.Add(this.btnBuscar);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.PatientId);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 110);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(343, 64);
            this.GroupBox1.TabIndex = 247;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Criterio de busqueda Paciente";
            // 
            // txtpaciente
            // 
            this.txtpaciente.BackColor = System.Drawing.Color.White;
            this.txtpaciente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpaciente.Location = new System.Drawing.Point(18, 32);
            this.txtpaciente.MaxLength = 20;
            this.txtpaciente.Name = "txtpaciente";
            this.txtpaciente.Size = new System.Drawing.Size(266, 22);
            this.txtpaciente.TabIndex = 1;
            this.txtpaciente.TextChanged += new System.EventHandler(this.txtpaciente_TextChanged);
            this.txtpaciente.Validated += new System.EventHandler(this.txtpaciente_Validated);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(290, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(43, 24);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre Paciente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PatientId
            // 
            this.PatientId.BackColor = System.Drawing.Color.White;
            this.PatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientId.Location = new System.Drawing.Point(290, 2);
            this.PatientId.MaxLength = 4;
            this.PatientId.Name = "PatientId";
            this.PatientId.ReadOnly = true;
            this.PatientId.Size = new System.Drawing.Size(32, 22);
            this.PatientId.TabIndex = 0;
            this.PatientId.Visible = false;
            // 
            // dgPacients
            // 
            this.dgPacients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPacients.Location = new System.Drawing.Point(361, 110);
            this.dgPacients.Name = "dgPacients";
            this.dgPacients.Size = new System.Drawing.Size(421, 149);
            this.dgPacients.TabIndex = 235;
            this.dgPacients.Visible = false;
            this.dgPacients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPacients_CellClick);
            // 
            // cbquirofano
            // 
            this.cbquirofano.FormattingEnabled = true;
            this.cbquirofano.Location = new System.Drawing.Point(21, 380);
            this.cbquirofano.Name = "cbquirofano";
            this.cbquirofano.Size = new System.Drawing.Size(121, 21);
            this.cbquirofano.TabIndex = 234;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 21);
            this.label4.TabIndex = 241;
            this.label4.Text = "Quirofanos disponibles";
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(20, 263);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(210, 20);
            this.Date.TabIndex = 248;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(224, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 59);
            this.button1.TabIndex = 249;
            this.button1.Text = "Liberar Quirofano";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCirugiaAgendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 520);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.clsButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.dgPacients);
            this.Controls.Add(this.cbquirofano);
            this.Controls.Add(this.dgScheduledSurgeries);
            this.Controls.Add(this.cbmedico);
            this.Controls.Add(this.description);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCirugiaAgendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cirugia";
            this.Load += new System.EventHandler(this.frmCirugiaAgendar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgScheduledSurgeries)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPacients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox clsButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.DataGridView dgScheduledSurgeries;
        private System.Windows.Forms.ComboBox cbmedico;
        private System.Windows.Forms.TextBox description;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtpaciente;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgPacients;
        private System.Windows.Forms.ComboBox cbquirofano;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox PatientId;
        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.Button button1;
    }
}