﻿namespace ProyectoHospital.Modulos.ModuloMedicosPacientes
{
    partial class frmPacienteRegistrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacienteRegistrar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.telef = new System.Windows.Forms.TextBox();
            this.direc = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.clsButton = new System.Windows.Forms.PictureBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.dgRegPac = new System.Windows.Forms.DataGridView();
            this.sexCombo = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.TextBox();
            this.identidad = new System.Windows.Forms.TextBox();
            this.pacID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.iddd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pacienteID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegPac)).BeginInit();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 80);
            this.panel1.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(1025, 4);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(84, 73);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.TabStop = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 73);
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
            this.label1.Location = new System.Drawing.Point(445, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pacientes";
            // 
            // telef
            // 
            this.telef.Location = new System.Drawing.Point(229, 434);
            this.telef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.telef.Multiline = true;
            this.telef.Name = "telef";
            this.telef.Size = new System.Drawing.Size(160, 32);
            this.telef.TabIndex = 219;
            // 
            // direc
            // 
            this.direc.Location = new System.Drawing.Point(229, 384);
            this.direc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.direc.Multiline = true;
            this.direc.Name = "direc";
            this.direc.Size = new System.Drawing.Size(160, 32);
            this.direc.TabIndex = 218;
            // 
            // fecha
            // 
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha.Location = new System.Drawing.Point(229, 283);
            this.fecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(160, 22);
            this.fecha.TabIndex = 217;
            this.fecha.Value = new System.DateTime(2024, 11, 23, 0, 0, 0, 0);
            // 
            // clsButton
            // 
            this.clsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clsButton.Image = global::ProyectoHospital.Properties.Resources.Clear;
            this.clsButton.Location = new System.Drawing.Point(412, 503);
            this.clsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clsButton.Name = "clsButton";
            this.clsButton.Size = new System.Drawing.Size(63, 54);
            this.clsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clsButton.TabIndex = 216;
            this.clsButton.TabStop = false;
            this.clsButton.Click += new System.EventHandler(this.clsButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(905, 503);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(149, 54);
            this.deleteButton.TabIndex = 215;
            this.deleteButton.Text = "ELIMINAR";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(229, 503);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(149, 54);
            this.updateButton.TabIndex = 214;
            this.updateButton.Text = "EDITAR";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertButton.Location = new System.Drawing.Point(52, 503);
            this.insertButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(149, 54);
            this.insertButton.TabIndex = 213;
            this.insertButton.Text = "AGREGAR";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // dgRegPac
            // 
            this.dgRegPac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRegPac.Location = new System.Drawing.Point(412, 106);
            this.dgRegPac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgRegPac.Name = "dgRegPac";
            this.dgRegPac.RowHeadersWidth = 51;
            this.dgRegPac.Size = new System.Drawing.Size(643, 372);
            this.dgRegPac.TabIndex = 212;
            this.dgRegPac.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRegPac_CellClick);
            // 
            // sexCombo
            // 
            this.sexCombo.FormattingEnabled = true;
            this.sexCombo.Location = new System.Drawing.Point(229, 340);
            this.sexCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sexCombo.Name = "sexCombo";
            this.sexCombo.Size = new System.Drawing.Size(160, 24);
            this.sexCombo.TabIndex = 211;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(229, 174);
            this.name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(160, 32);
            this.name.TabIndex = 210;
            // 
            // identidad
            // 
            this.identidad.Location = new System.Drawing.Point(229, 228);
            this.identidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.identidad.Multiline = true;
            this.identidad.Name = "identidad";
            this.identidad.Size = new System.Drawing.Size(160, 32);
            this.identidad.TabIndex = 209;
            // 
            // pacID
            // 
            this.pacID.Location = new System.Drawing.Point(229, 121);
            this.pacID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pacID.Multiline = true;
            this.pacID.Name = "pacID";
            this.pacID.Size = new System.Drawing.Size(160, 32);
            this.pacID.TabIndex = 208;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 340);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 28);
            this.label6.TabIndex = 207;
            this.label6.Text = "Sexo";
            // 
            // iddd
            // 
            this.iddd.AutoSize = true;
            this.iddd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iddd.Location = new System.Drawing.Point(47, 228);
            this.iddd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iddd.Name = "iddd";
            this.iddd.Size = new System.Drawing.Size(102, 28);
            this.iddd.TabIndex = 206;
            this.iddd.Text = "Identidad";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 270);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 70);
            this.label8.TabIndex = 205;
            this.label8.Text = "Fecha de Nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 174);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 28);
            this.label7.TabIndex = 204;
            this.label7.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 384);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 28);
            this.label4.TabIndex = 203;
            this.label4.Text = "Dirección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 434);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 202;
            this.label3.Text = "Teléfono";
            // 
            // pacienteID
            // 
            this.pacienteID.AutoSize = true;
            this.pacienteID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pacienteID.Location = new System.Drawing.Point(47, 121);
            this.pacienteID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pacienteID.Name = "pacienteID";
            this.pacienteID.Size = new System.Drawing.Size(114, 28);
            this.pacienteID.TabIndex = 201;
            this.pacienteID.Text = "PacienteID";
            // 
            // frmPacienteRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 609);
            this.Controls.Add(this.telef);
            this.Controls.Add(this.direc);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.clsButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.dgRegPac);
            this.Controls.Add(this.sexCombo);
            this.Controls.Add(this.name);
            this.Controls.Add(this.identidad);
            this.Controls.Add(this.pacID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.iddd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pacienteID);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPacienteRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paciente";
            this.Load += new System.EventHandler(this.frmPacienteRegistrar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegPac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox telef;
        private System.Windows.Forms.TextBox direc;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.PictureBox clsButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.DataGridView dgRegPac;
        private System.Windows.Forms.ComboBox sexCombo;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox identidad;
        private System.Windows.Forms.TextBox pacID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label iddd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pacienteID;
    }
}