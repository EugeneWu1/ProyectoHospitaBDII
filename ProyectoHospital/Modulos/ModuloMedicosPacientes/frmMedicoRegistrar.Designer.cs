﻿namespace ProyectoHospital.Modulos.ModuloMedicosPacientes
{
    partial class frmMedicoRegistrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicoRegistrar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clsButton = new System.Windows.Forms.PictureBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sexCombo = new System.Windows.Forms.ComboBox();
            this.tipoCombo = new System.Windows.Forms.ComboBox();
            this.espeCombo = new System.Windows.Forms.ComboBox();
            this.consultID = new System.Windows.Forms.TextBox();
            this.direc = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.medID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(848, 67);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(341, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Médicos";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(777, 9);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(61, 53);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.TabStop = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // clsButton
            // 
            this.clsButton.Image = global::ProyectoHospital.Properties.Resources.Clear;
            this.clsButton.Location = new System.Drawing.Point(311, 412);
            this.clsButton.Name = "clsButton";
            this.clsButton.Size = new System.Drawing.Size(47, 44);
            this.clsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clsButton.TabIndex = 197;
            this.clsButton.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(681, 412);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 44);
            this.deleteButton.TabIndex = 196;
            this.deleteButton.Text = "ELIMINAR";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(174, 412);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(112, 44);
            this.updateButton.TabIndex = 195;
            this.updateButton.Text = "EDITAR";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // insertButton
            // 
            this.insertButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertButton.Location = new System.Drawing.Point(41, 412);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(112, 44);
            this.insertButton.TabIndex = 194;
            this.insertButton.Text = "AGREGAR";
            this.insertButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(311, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(482, 302);
            this.dataGridView1.TabIndex = 193;
            // 
            // sexCombo
            // 
            this.sexCombo.FormattingEnabled = true;
            this.sexCombo.Location = new System.Drawing.Point(174, 185);
            this.sexCombo.Name = "sexCombo";
            this.sexCombo.Size = new System.Drawing.Size(121, 21);
            this.sexCombo.TabIndex = 192;
            // 
            // tipoCombo
            // 
            this.tipoCombo.FormattingEnabled = true;
            this.tipoCombo.Location = new System.Drawing.Point(174, 316);
            this.tipoCombo.Name = "tipoCombo";
            this.tipoCombo.Size = new System.Drawing.Size(121, 21);
            this.tipoCombo.TabIndex = 191;
            // 
            // espeCombo
            // 
            this.espeCombo.FormattingEnabled = true;
            this.espeCombo.Location = new System.Drawing.Point(174, 270);
            this.espeCombo.Name = "espeCombo";
            this.espeCombo.Size = new System.Drawing.Size(121, 21);
            this.espeCombo.TabIndex = 190;
            // 
            // consultID
            // 
            this.consultID.Location = new System.Drawing.Point(174, 358);
            this.consultID.Multiline = true;
            this.consultID.Name = "consultID";
            this.consultID.Size = new System.Drawing.Size(121, 27);
            this.consultID.TabIndex = 189;
            // 
            // direc
            // 
            this.direc.Location = new System.Drawing.Point(174, 226);
            this.direc.Multiline = true;
            this.direc.Name = "direc";
            this.direc.Size = new System.Drawing.Size(121, 27);
            this.direc.TabIndex = 188;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(174, 144);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(121, 27);
            this.name.TabIndex = 187;
            // 
            // medID
            // 
            this.medID.Location = new System.Drawing.Point(174, 101);
            this.medID.Multiline = true;
            this.medID.Name = "medID";
            this.medID.Size = new System.Drawing.Size(121, 27);
            this.medID.TabIndex = 186;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 21);
            this.label6.TabIndex = 185;
            this.label6.Text = "Sexo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 21);
            this.label10.TabIndex = 184;
            this.label10.Text = "ConsultorioID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 21);
            this.label8.TabIndex = 183;
            this.label8.Text = "Dirección";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 182;
            this.label7.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 181;
            this.label4.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 180;
            this.label3.Text = "Especialidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 179;
            this.label5.Text = "MédicoID";
            // 
            // frmMedicoRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 485);
            this.Controls.Add(this.clsButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sexCombo);
            this.Controls.Add(this.tipoCombo);
            this.Controls.Add(this.espeCombo);
            this.Controls.Add(this.consultID);
            this.Controls.Add(this.direc);
            this.Controls.Add(this.name);
            this.Controls.Add(this.medID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMedicoRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medico";
            this.Load += new System.EventHandler(this.frmMedicoRegistrar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox clsButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox sexCombo;
        private System.Windows.Forms.ComboBox tipoCombo;
        private System.Windows.Forms.ComboBox espeCombo;
        private System.Windows.Forms.TextBox consultID;
        private System.Windows.Forms.TextBox direc;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox medID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}