namespace ProyectoHospital.Modulos.ModuloPagos
{
    partial class frmFacturaRegistrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturaRegistrar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboxServicios = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxNoFactura = new System.Windows.Forms.TextBox();
            this.tboxNombrePaciente = new System.Windows.Forms.TextBox();
            this.tboxISV = new System.Windows.Forms.TextBox();
            this.tboxTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxSubtotal = new System.Windows.Forms.TextBox();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.tbnAyuda = new System.Windows.Forms.Button();
            this.tboxIdentidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tboxInsumo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tboxCantidadInsumo = new System.Windows.Forms.TextBox();
            this.btnGuardarTbox = new System.Windows.Forms.Button();
            this.dgFactura = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.tboxDescripcion = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 67);
            this.panel1.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(1054, 8);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(65, 57);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.TabStop = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 61);
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
            this.label1.Location = new System.Drawing.Point(445, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Facturas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del Paciente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Servicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(456, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Facturación";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(607, 124);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(242, 23);
            this.dtpFecha.TabIndex = 6;
            // 
            // cboxServicios
            // 
            this.cboxServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxServicios.FormattingEnabled = true;
            this.cboxServicios.Location = new System.Drawing.Point(195, 239);
            this.cboxServicios.Name = "cboxServicios";
            this.cboxServicios.Size = new System.Drawing.Size(213, 24);
            this.cboxServicios.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(928, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "ISV";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(917, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(326, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Número de Factura";
            // 
            // tboxNoFactura
            // 
            this.tboxNoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNoFactura.Location = new System.Drawing.Point(462, 84);
            this.tboxNoFactura.Name = "tboxNoFactura";
            this.tboxNoFactura.ReadOnly = true;
            this.tboxNoFactura.Size = new System.Drawing.Size(100, 23);
            this.tboxNoFactura.TabIndex = 13;
            this.tboxNoFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tboxNombrePaciente
            // 
            this.tboxNombrePaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxNombrePaciente.Location = new System.Drawing.Point(195, 133);
            this.tboxNombrePaciente.Name = "tboxNombrePaciente";
            this.tboxNombrePaciente.Size = new System.Drawing.Size(213, 23);
            this.tboxNombrePaciente.TabIndex = 14;
            // 
            // tboxISV
            // 
            this.tboxISV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxISV.Location = new System.Drawing.Point(963, 166);
            this.tboxISV.Name = "tboxISV";
            this.tboxISV.ReadOnly = true;
            this.tboxISV.Size = new System.Drawing.Size(140, 23);
            this.tboxISV.TabIndex = 15;
            this.tboxISV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tboxTotal
            // 
            this.tboxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxTotal.Location = new System.Drawing.Point(963, 211);
            this.tboxTotal.Name = "tboxTotal";
            this.tboxTotal.ReadOnly = true;
            this.tboxTotal.Size = new System.Drawing.Size(140, 23);
            this.tboxTotal.TabIndex = 16;
            this.tboxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(897, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Subtotal";
            // 
            // tboxSubtotal
            // 
            this.tboxSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSubtotal.Location = new System.Drawing.Point(963, 118);
            this.tboxSubtotal.Name = "tboxSubtotal";
            this.tboxSubtotal.ReadOnly = true;
            this.tboxSubtotal.Size = new System.Drawing.Size(140, 23);
            this.tboxSubtotal.TabIndex = 18;
            this.tboxSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerarFactura.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFactura.ForeColor = System.Drawing.Color.White;
            this.btnGenerarFactura.Location = new System.Drawing.Point(947, 556);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(172, 58);
            this.btnGenerarFactura.TabIndex = 20;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = false;
            // 
            // tbnAyuda
            // 
            this.tbnAyuda.BackColor = System.Drawing.Color.RoyalBlue;
            this.tbnAyuda.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnAyuda.ForeColor = System.Drawing.Color.White;
            this.tbnAyuda.Location = new System.Drawing.Point(21, 556);
            this.tbnAyuda.Name = "tbnAyuda";
            this.tbnAyuda.Size = new System.Drawing.Size(76, 27);
            this.tbnAyuda.TabIndex = 21;
            this.tbnAyuda.Text = "Ayuda";
            this.tbnAyuda.UseVisualStyleBackColor = false;
            // 
            // tboxIdentidad
            // 
            this.tboxIdentidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxIdentidad.Location = new System.Drawing.Point(195, 188);
            this.tboxIdentidad.Name = "tboxIdentidad";
            this.tboxIdentidad.Size = new System.Drawing.Size(213, 23);
            this.tboxIdentidad.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Identificacion del Paciente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(456, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Insumo usado";
            // 
            // tboxInsumo
            // 
            this.tboxInsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxInsumo.Location = new System.Drawing.Point(549, 169);
            this.tboxInsumo.Name = "tboxInsumo";
            this.tboxInsumo.Size = new System.Drawing.Size(174, 23);
            this.tboxInsumo.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(729, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "Cantidad";
            // 
            // tboxCantidadInsumo
            // 
            this.tboxCantidadInsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxCantidadInsumo.Location = new System.Drawing.Point(799, 169);
            this.tboxCantidadInsumo.Name = "tboxCantidadInsumo";
            this.tboxCantidadInsumo.Size = new System.Drawing.Size(49, 23);
            this.tboxCantidadInsumo.TabIndex = 27;
            // 
            // btnGuardarTbox
            // 
            this.btnGuardarTbox.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGuardarTbox.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTbox.ForeColor = System.Drawing.Color.White;
            this.btnGuardarTbox.Location = new System.Drawing.Point(1004, 262);
            this.btnGuardarTbox.Name = "btnGuardarTbox";
            this.btnGuardarTbox.Size = new System.Drawing.Size(99, 36);
            this.btnGuardarTbox.TabIndex = 28;
            this.btnGuardarTbox.Text = "Insertar";
            this.btnGuardarTbox.UseVisualStyleBackColor = false;
            this.btnGuardarTbox.Click += new System.EventHandler(this.btnGuardarTbox_Click);
            // 
            // dgFactura
            // 
            this.dgFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFactura.Location = new System.Drawing.Point(9, 308);
            this.dgFactura.Name = "dgFactura";
            this.dgFactura.RowHeadersVisible = false;
            this.dgFactura.Size = new System.Drawing.Size(1110, 235);
            this.dgFactura.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(456, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "Descripción";
            // 
            // tboxDescripcion
            // 
            this.tboxDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDescripcion.Location = new System.Drawing.Point(548, 219);
            this.tboxDescripcion.Multiline = true;
            this.tboxDescripcion.Name = "tboxDescripcion";
            this.tboxDescripcion.Size = new System.Drawing.Size(300, 78);
            this.tboxDescripcion.TabIndex = 31;
            // 
            // frmFacturaRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 626);
            this.Controls.Add(this.tboxDescripcion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgFactura);
            this.Controls.Add(this.btnGuardarTbox);
            this.Controls.Add(this.tboxCantidadInsumo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tboxInsumo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tboxIdentidad);
            this.Controls.Add(this.tbnAyuda);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.tboxSubtotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tboxTotal);
            this.Controls.Add(this.tboxISV);
            this.Controls.Add(this.tboxNombrePaciente);
            this.Controls.Add(this.tboxNoFactura);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboxServicios);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFacturaRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnVolver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboxServicios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxNoFactura;
        private System.Windows.Forms.TextBox tboxNombrePaciente;
        private System.Windows.Forms.TextBox tboxISV;
        private System.Windows.Forms.TextBox tboxTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxSubtotal;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.Button tbnAyuda;
        private System.Windows.Forms.TextBox tboxIdentidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tboxInsumo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tboxCantidadInsumo;
        private System.Windows.Forms.Button btnGuardarTbox;
        private System.Windows.Forms.DataGridView dgFactura;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tboxDescripcion;
    }
}