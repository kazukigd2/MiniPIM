namespace MiniPIM
{
    partial class V_ProductoIndividual
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
            this.Label = new System.Windows.Forms.Label();
            this.creado = new System.Windows.Forms.Label();
            this.mod = new System.Windows.Forms.Label();
            this.sku = new System.Windows.Forms.Label();
            this.gtin = new System.Windows.Forms.Label();
            this.cat = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.thumbnail = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.fCreacion = new System.Windows.Forms.Label();
            this.fMod = new System.Windows.Forms.Label();
            this.fSKU = new System.Windows.Forms.Label();
            this.fGTIN = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Lexend", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(32, 43);
            this.Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(185, 56);
            this.Label.TabIndex = 3;
            this.Label.Text = "Producto";
            // 
            // creado
            // 
            this.creado.AutoSize = true;
            this.creado.Font = new System.Drawing.Font("Lexend SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creado.Location = new System.Drawing.Point(46, 332);
            this.creado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.creado.Name = "creado";
            this.creado.Size = new System.Drawing.Size(80, 24);
            this.creado.TabIndex = 4;
            this.creado.Text = "Created: ";
            // 
            // mod
            // 
            this.mod.AutoSize = true;
            this.mod.Font = new System.Drawing.Font("Lexend SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod.Location = new System.Drawing.Point(46, 355);
            this.mod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mod.Name = "mod";
            this.mod.Size = new System.Drawing.Size(80, 24);
            this.mod.TabIndex = 5;
            this.mod.Text = "Modified:";
            // 
            // sku
            // 
            this.sku.AutoSize = true;
            this.sku.Font = new System.Drawing.Font("Lexend SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sku.Location = new System.Drawing.Point(46, 379);
            this.sku.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sku.Name = "sku";
            this.sku.Size = new System.Drawing.Size(50, 24);
            this.sku.TabIndex = 6;
            this.sku.Text = "SKU: ";
            // 
            // gtin
            // 
            this.gtin.AutoSize = true;
            this.gtin.Font = new System.Drawing.Font("Lexend SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtin.Location = new System.Drawing.Point(46, 402);
            this.gtin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gtin.Name = "gtin";
            this.gtin.Size = new System.Drawing.Size(60, 24);
            this.gtin.TabIndex = 7;
            this.gtin.Text = "GTIN: ";
            // 
            // cat
            // 
            this.cat.AutoSize = true;
            this.cat.Font = new System.Drawing.Font("Lexend SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cat.Location = new System.Drawing.Point(30, 450);
            this.cat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cat.Name = "cat";
            this.cat.Size = new System.Drawing.Size(92, 24);
            this.cat.TabIndex = 8;
            this.cat.Text = "Categories";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Lexend Light", 10.8F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(60, 496);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(301, 70);
            this.listBox1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(447, 51);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 564);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lexend", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "ATTRIBUTES";
            // 
            // thumbnail
            // 
            this.thumbnail.Image = global::MiniPIM.Properties.Resources.ICONnoimageG;
            this.thumbnail.InitialImage = global::MiniPIM.Properties.Resources.ICONnoimage;
            this.thumbnail.Location = new System.Drawing.Point(41, 102);
            this.thumbnail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.thumbnail.MaximumSize = new System.Drawing.Size(188, 203);
            this.thumbnail.Name = "thumbnail";
            this.thumbnail.Size = new System.Drawing.Size(188, 203);
            this.thumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail.TabIndex = 2;
            this.thumbnail.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::MiniPIM.Properties.Resources.ICONback;
            this.pictureBox2.Location = new System.Drawing.Point(2, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MiniPIM.Properties.Resources.ICONedit;
            this.pictureBox1.Location = new System.Drawing.Point(23, 618);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::MiniPIM.Properties.Resources.ICONdelete;
            this.pictureBox3.Location = new System.Drawing.Point(60, 618);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // fCreacion
            // 
            this.fCreacion.AutoSize = true;
            this.fCreacion.Font = new System.Drawing.Font("Lexend Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fCreacion.Location = new System.Drawing.Point(123, 332);
            this.fCreacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fCreacion.Name = "fCreacion";
            this.fCreacion.Size = new System.Drawing.Size(0, 24);
            this.fCreacion.TabIndex = 4;
            // 
            // fMod
            // 
            this.fMod.AutoSize = true;
            this.fMod.Font = new System.Drawing.Font("Lexend Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fMod.Location = new System.Drawing.Point(124, 355);
            this.fMod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fMod.Name = "fMod";
            this.fMod.Size = new System.Drawing.Size(77, 24);
            this.fMod.TabIndex = 5;
            this.fMod.Text = "None yet.";
            // 
            // fSKU
            // 
            this.fSKU.AutoSize = true;
            this.fSKU.Font = new System.Drawing.Font("Lexend Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fSKU.Location = new System.Drawing.Point(97, 379);
            this.fSKU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fSKU.Name = "fSKU";
            this.fSKU.Size = new System.Drawing.Size(0, 24);
            this.fSKU.TabIndex = 6;
            // 
            // fGTIN
            // 
            this.fGTIN.AutoSize = true;
            this.fGTIN.Font = new System.Drawing.Font("Lexend Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGTIN.Location = new System.Drawing.Point(105, 402);
            this.fGTIN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fGTIN.Name = "fGTIN";
            this.fGTIN.Size = new System.Drawing.Size(0, 24);
            this.fGTIN.TabIndex = 7;
            // 
            // V_ProductoIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cat);
            this.Controls.Add(this.fGTIN);
            this.Controls.Add(this.gtin);
            this.Controls.Add(this.fSKU);
            this.Controls.Add(this.fMod);
            this.Controls.Add(this.sku);
            this.Controls.Add(this.fCreacion);
            this.Controls.Add(this.mod);
            this.Controls.Add(this.creado);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.thumbnail);
            this.Controls.Add(this.panel1);
            this.Name = "V_ProductoIndividual";
            this.Size = new System.Drawing.Size(900, 650);
            this.Load += new System.EventHandler(this.V_ProductoIndividual_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox thumbnail;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label creado;
        private System.Windows.Forms.Label mod;
        private System.Windows.Forms.Label sku;
        private System.Windows.Forms.Label gtin;
        private System.Windows.Forms.Label cat;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label fCreacion;
        private System.Windows.Forms.Label fMod;
        private System.Windows.Forms.Label fSKU;
        private System.Windows.Forms.Label fGTIN;
        private System.Windows.Forms.Label label1;
    }
}
