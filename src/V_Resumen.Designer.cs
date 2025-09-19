namespace MiniPIM
{
    partial class V_Resumen
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.thumbnail = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label_nRelaciones = new System.Windows.Forms.Label();
            this.label_nCategorias = new System.Windows.Forms.Label();
            this.label_nAtributos = new System.Windows.Forms.Label();
            this.label_nProductos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label_NombreCuenta = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_FechaCreacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbnail
            // 
            this.thumbnail.Image = global::MiniPIM.Properties.Resources.ICONnoimageG;
            this.thumbnail.InitialImage = global::MiniPIM.Properties.Resources.ICONnoimage;
            this.thumbnail.Location = new System.Drawing.Point(44, 118);
            this.thumbnail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.thumbnail.MaximumSize = new System.Drawing.Size(300, 300);
            this.thumbnail.Name = "thumbnail";
            this.thumbnail.Size = new System.Drawing.Size(270, 280);
            this.thumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail.TabIndex = 5;
            this.thumbnail.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(383, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 564);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(56, 473);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 43);
            this.panel4.TabIndex = 10;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lexend", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(98, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 30);
            this.label6.TabIndex = 10;
            this.label6.Text = "Export Account Data";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lexend", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "STATISTICS";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.label_nRelaciones);
            this.panel2.Controls.Add(this.label_nCategorias);
            this.panel2.Controls.Add(this.label_nAtributos);
            this.panel2.Controls.Add(this.label_nProductos);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(36, 121);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(423, 318);
            this.panel2.TabIndex = 7;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MiniPIM.Properties.Resources.ICONproduct;
            this.pictureBox4.InitialImage = global::MiniPIM.Properties.Resources.ICONnoimage;
            this.pictureBox4.Location = new System.Drawing.Point(84, 27);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.MaximumSize = new System.Drawing.Size(188, 203);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // label_nRelaciones
            // 
            this.label_nRelaciones.BackColor = System.Drawing.Color.Transparent;
            this.label_nRelaciones.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nRelaciones.Location = new System.Drawing.Point(253, 250);
            this.label_nRelaciones.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nRelaciones.Name = "label_nRelaciones";
            this.label_nRelaciones.Size = new System.Drawing.Size(113, 25);
            this.label_nRelaciones.TabIndex = 12;
            this.label_nRelaciones.Text = "0";
            this.label_nRelaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_nCategorias
            // 
            this.label_nCategorias.BackColor = System.Drawing.Color.Transparent;
            this.label_nCategorias.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nCategorias.Location = new System.Drawing.Point(253, 105);
            this.label_nCategorias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nCategorias.Name = "label_nCategorias";
            this.label_nCategorias.Size = new System.Drawing.Size(113, 25);
            this.label_nCategorias.TabIndex = 12;
            this.label_nCategorias.Text = "0";
            this.label_nCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_nCategorias.Click += new System.EventHandler(this.label_nCategorias_Click);
            // 
            // label_nAtributos
            // 
            this.label_nAtributos.BackColor = System.Drawing.Color.Transparent;
            this.label_nAtributos.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nAtributos.Location = new System.Drawing.Point(75, 250);
            this.label_nAtributos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nAtributos.Name = "label_nAtributos";
            this.label_nAtributos.Size = new System.Drawing.Size(102, 25);
            this.label_nAtributos.TabIndex = 8;
            this.label_nAtributos.Text = "0";
            this.label_nAtributos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_nProductos
            // 
            this.label_nProductos.BackColor = System.Drawing.Color.Transparent;
            this.label_nProductos.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nProductos.Location = new System.Drawing.Point(70, 105);
            this.label_nProductos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nProductos.Name = "label_nProductos";
            this.label_nProductos.Size = new System.Drawing.Size(107, 25);
            this.label_nProductos.TabIndex = 8;
            this.label_nProductos.Text = "0";
            this.label_nProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(255, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Nº Relations";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(248, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nº Categories";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(65, 224);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Nº Attributes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lexend", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nº Products";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MiniPIM.Properties.Resources.ICONrelation;
            this.pictureBox2.InitialImage = global::MiniPIM.Properties.Resources.ICONnoimage;
            this.pictureBox2.Location = new System.Drawing.Point(269, 172);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(188, 203);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MiniPIM.Properties.Resources.ICONtag;
            this.pictureBox1.InitialImage = global::MiniPIM.Properties.Resources.ICONnoimage;
            this.pictureBox1.Location = new System.Drawing.Point(269, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(188, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MiniPIM.Properties.Resources.ICONattribute;
            this.pictureBox3.InitialImage = global::MiniPIM.Properties.Resources.ICONnoimage;
            this.pictureBox3.Location = new System.Drawing.Point(84, 172);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(188, 203);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // label_NombreCuenta
            // 
            this.label_NombreCuenta.AutoSize = true;
            this.label_NombreCuenta.BackColor = System.Drawing.Color.Transparent;
            this.label_NombreCuenta.Font = new System.Drawing.Font("Lexend", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NombreCuenta.Location = new System.Drawing.Point(41, 400);
            this.label_NombreCuenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_NombreCuenta.Name = "label_NombreCuenta";
            this.label_NombreCuenta.Size = new System.Drawing.Size(291, 50);
            this.label_NombreCuenta.TabIndex = 7;
            this.label_NombreCuenta.Text = "ACCOUNT NAME";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Lexend", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(46, 452);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 22);
            this.label11.TabIndex = 8;
            this.label11.Text = "Created: ";
            // 
            // label_FechaCreacion
            // 
            this.label_FechaCreacion.AutoSize = true;
            this.label_FechaCreacion.BackColor = System.Drawing.Color.Transparent;
            this.label_FechaCreacion.Font = new System.Drawing.Font("Lexend", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FechaCreacion.Location = new System.Drawing.Point(111, 452);
            this.label_FechaCreacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FechaCreacion.Name = "label_FechaCreacion";
            this.label_FechaCreacion.Size = new System.Drawing.Size(162, 22);
            this.label_FechaCreacion.TabIndex = 9;
            this.label_FechaCreacion.Text = " 00 / 00 / 0000 00:00";
            // 
            // V_Resumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_FechaCreacion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_NombreCuenta);
            this.Controls.Add(this.thumbnail);
            this.Controls.Add(this.panel1);
            this.Name = "V_Resumen";
            this.Size = new System.Drawing.Size(900, 650);
            this.Load += new System.EventHandler(this.V_Resumen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox thumbnail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_nCategorias;
        private System.Windows.Forms.Label label_nProductos;
        private System.Windows.Forms.Label label_nRelaciones;
        private System.Windows.Forms.Label label_nAtributos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label_NombreCuenta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_FechaCreacion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
