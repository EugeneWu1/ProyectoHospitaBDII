namespace ProyectoHospital.Modulos.ModuloMedicosPacientes
{
    partial class frmmPacienteConsultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmPacienteConsultar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.Label();
            this.telef = new System.Windows.Forms.Label();
            this.direc = new System.Windows.Forms.Label();
            this.sex = new System.Windows.Forms.Label();
            this.identidad = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.pacID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.TextBox();
            this.filter = new System.Windows.Forms.ComboBox();
            this.dgConPac = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConPac)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 65);
            this.panel1.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(808, 3);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(63, 59);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.TabStop = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(353, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pacientes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.fecha);
            this.panel2.Controls.Add(this.telef);
            this.panel2.Controls.Add(this.direc);
            this.panel2.Controls.Add(this.sex);
            this.panel2.Controls.Add(this.identidad);
            this.panel2.Controls.Add(this.name);
            this.panel2.Controls.Add(this.pacID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(133, 373);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 285);
            this.panel2.TabIndex = 230;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 25);
            this.label11.TabIndex = 219;
            this.label11.Text = "Datos del Paciente";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Location = new System.Drawing.Point(458, 132);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(16, 21);
            this.fecha.TabIndex = 216;
            this.fecha.Text = "-";
            // 
            // telef
            // 
            this.telef.AutoSize = true;
            this.telef.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telef.Location = new System.Drawing.Point(456, 69);
            this.telef.Name = "telef";
            this.telef.Size = new System.Drawing.Size(16, 21);
            this.telef.TabIndex = 215;
            this.telef.Text = "-";
            // 
            // direc
            // 
            this.direc.AutoSize = true;
            this.direc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direc.Location = new System.Drawing.Point(456, 190);
            this.direc.Name = "direc";
            this.direc.Size = new System.Drawing.Size(16, 21);
            this.direc.TabIndex = 214;
            this.direc.Text = "-";
            // 
            // sex
            // 
            this.sex.AutoSize = true;
            this.sex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sex.Location = new System.Drawing.Point(121, 190);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(16, 21);
            this.sex.TabIndex = 213;
            this.sex.Text = "-";
            // 
            // identidad
            // 
            this.identidad.AutoSize = true;
            this.identidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identidad.Location = new System.Drawing.Point(121, 149);
            this.identidad.Name = "identidad";
            this.identidad.Size = new System.Drawing.Size(16, 21);
            this.identidad.TabIndex = 212;
            this.identidad.Text = "-";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(123, 109);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(16, 21);
            this.name.TabIndex = 211;
            this.name.Text = "-";
            // 
            // pacID
            // 
            this.pacID.AutoSize = true;
            this.pacID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pacID.Location = new System.Drawing.Point(121, 69);
            this.pacID.Name = "pacID";
            this.pacID.Size = new System.Drawing.Size(16, 21);
            this.pacID.TabIndex = 210;
            this.pacID.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 209;
            this.label3.Text = "Teléfono: ";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(21, 149);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(92, 21);
            this.label.TabIndex = 208;
            this.label.Text = "Identidad: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 21);
            this.label6.TabIndex = 207;
            this.label6.Text = "Sexo: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(340, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 21);
            this.label8.TabIndex = 205;
            this.label8.Text = "Dirección: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 204;
            this.label7.Text = "Nombre: ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(338, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 49);
            this.label5.TabIndex = 202;
            this.label5.Text = "Fecha de Nacimiento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 21);
            this.label9.TabIndex = 201;
            this.label9.Text = "PacienteID: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(439, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 21);
            this.label12.TabIndex = 229;
            this.label12.Text = "Buscar";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(621, 84);
            this.search.Multiline = true;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(226, 27);
            this.search.TabIndex = 228;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // filter
            // 
            this.filter.FormattingEnabled = true;
            this.filter.Location = new System.Drawing.Point(505, 87);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(110, 21);
            this.filter.TabIndex = 227;
            this.filter.SelectedIndexChanged += new System.EventHandler(this.filter_SelectedIndexChanged);
            // 
            // dgConPac
            // 
            this.dgConPac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConPac.Location = new System.Drawing.Point(53, 121);
            this.dgConPac.Name = "dgConPac";
            this.dgConPac.Size = new System.Drawing.Size(794, 224);
            this.dgConPac.TabIndex = 226;
            this.dgConPac.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConPac_CellContentClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(326, 25);
            this.label13.TabIndex = 225;
            this.label13.Text = "Seleccione un Paciente a Consultar:";
            // 
            // frmmPacienteConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 692);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.search);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.dgConPac);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmmPacienteConsultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmmPacienteConsultar";
            this.Load += new System.EventHandler(this.frmmPacienteConsultar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConPac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label telef;
        private System.Windows.Forms.Label direc;
        private System.Windows.Forms.Label sex;
        private System.Windows.Forms.Label identidad;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label pacID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ComboBox filter;
        private System.Windows.Forms.DataGridView dgConPac;
        private System.Windows.Forms.Label label13;
    }
}