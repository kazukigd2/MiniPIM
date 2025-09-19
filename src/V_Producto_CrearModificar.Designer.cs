namespace MiniPIM
{
    partial class V_Producto_CrearModificar
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
            this.titulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lThumbnail = new System.Windows.Forms.Label();
            this.Thumbnail = new System.Windows.Forms.PictureBox();
            this.listBox_NoAsociado = new System.Windows.Forms.ListBox();
            this.pThumbnail = new System.Windows.Forms.Panel();
            this.tGTIN = new System.Windows.Forms.TextBox();
            this.tSKU = new System.Windows.Forms.TextBox();
            this.tLabel = new System.Windows.Forms.TextBox();
            this.listBox_Asociado = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.commit = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.BackColor = System.Drawing.Color.Transparent;
            this.titulo.Font = new System.Drawing.Font("Lexend", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(110, 26);
            this.titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(164, 56);
            this.titulo.TabIndex = 4;
            this.titulo.Text = "TITULO";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lThumbnail);
            this.panel1.Controls.Add(this.Thumbnail);
            this.panel1.Controls.Add(this.listBox_NoAsociado);
            this.panel1.Controls.Add(this.pThumbnail);
            this.panel1.Controls.Add(this.tGTIN);
            this.panel1.Controls.Add(this.tSKU);
            this.panel1.Controls.Add(this.tLabel);
            this.panel1.Controls.Add(this.listBox_Asociado);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(58, 98);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 513);
            this.panel1.TabIndex = 5;
            // 
            // lThumbnail
            // 
            this.lThumbnail.AutoEllipsis = true;
            this.lThumbnail.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lThumbnail.Location = new System.Drawing.Point(153, 79);
            this.lThumbnail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lThumbnail.Name = "lThumbnail";
            this.lThumbnail.Size = new System.Drawing.Size(173, 24);
            this.lThumbnail.TabIndex = 16;
            this.lThumbnail.Text = "Upload new thumbnail";
            this.lThumbnail.Click += new System.EventHandler(this.subirThmumbnail);
            // 
            // Thumbnail
            // 
            this.Thumbnail.Image = global::MiniPIM.Properties.Resources.ICONdoc;
            this.Thumbnail.Location = new System.Drawing.Point(126, 79);
            this.Thumbnail.Margin = new System.Windows.Forms.Padding(2);
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.Size = new System.Drawing.Size(22, 24);
            this.Thumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Thumbnail.TabIndex = 15;
            this.Thumbnail.TabStop = false;
            this.Thumbnail.Click += new System.EventHandler(this.subirThmumbnail);
            // 
            // listBox_NoAsociado
            // 
            this.listBox_NoAsociado.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_NoAsociado.FormattingEnabled = true;
            this.listBox_NoAsociado.ItemHeight = 22;
            this.listBox_NoAsociado.Location = new System.Drawing.Point(180, 191);
            this.listBox_NoAsociado.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_NoAsociado.Name = "listBox_NoAsociado";
            this.listBox_NoAsociado.Size = new System.Drawing.Size(122, 48);
            this.listBox_NoAsociado.TabIndex = 15;
            this.listBox_NoAsociado.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // pThumbnail
            // 
            this.pThumbnail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pThumbnail.Location = new System.Drawing.Point(117, 79);
            this.pThumbnail.Margin = new System.Windows.Forms.Padding(2);
            this.pThumbnail.Name = "pThumbnail";
            this.pThumbnail.Size = new System.Drawing.Size(209, 28);
            this.pThumbnail.TabIndex = 14;
            this.pThumbnail.Click += new System.EventHandler(this.subirThmumbnail);
            // 
            // tGTIN
            // 
            this.tGTIN.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tGTIN.Location = new System.Drawing.Point(70, 158);
            this.tGTIN.Margin = new System.Windows.Forms.Padding(2);
            this.tGTIN.MaxLength = 250;
            this.tGTIN.Name = "tGTIN";
            this.tGTIN.Size = new System.Drawing.Size(256, 25);
            this.tGTIN.TabIndex = 13;
            // 
            // tSKU
            // 
            this.tSKU.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSKU.Location = new System.Drawing.Point(70, 117);
            this.tSKU.Margin = new System.Windows.Forms.Padding(2);
            this.tSKU.MaxLength = 250;
            this.tSKU.Name = "tSKU";
            this.tSKU.Size = new System.Drawing.Size(256, 25);
            this.tSKU.TabIndex = 12;
            // 
            // tLabel
            // 
            this.tLabel.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLabel.Location = new System.Drawing.Point(70, 36);
            this.tLabel.Margin = new System.Windows.Forms.Padding(2);
            this.tLabel.MaxLength = 250;
            this.tLabel.Name = "tLabel";
            this.tLabel.Size = new System.Drawing.Size(256, 25);
            this.tLabel.TabIndex = 11;
            // 
            // listBox_Asociado
            // 
            this.listBox_Asociado.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Asociado.FormattingEnabled = true;
            this.listBox_Asociado.ItemHeight = 22;
            this.listBox_Asociado.Location = new System.Drawing.Point(60, 246);
            this.listBox_Asociado.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_Asociado.Name = "listBox_Asociado";
            this.listBox_Asociado.Size = new System.Drawing.Size(248, 70);
            this.listBox_Asociado.TabIndex = 10;
            this.listBox_Asociado.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::MiniPIM.Properties.Resources.ICONnoimage;
            this.pictureBox2.Location = new System.Drawing.Point(138, 199);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MiniPIM.Properties.Resources.ICONadd;
            this.pictureBox1.Location = new System.Drawing.Point(104, 199);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Categories: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "GTIN: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "SKU:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thumbnail: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label: ";
            // 
            // commit
            // 
            this.commit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commit.Image = global::MiniPIM.Properties.Resources.ICONtick;
            this.commit.Location = new System.Drawing.Point(429, 652);
            this.commit.Margin = new System.Windows.Forms.Padding(2);
            this.commit.Name = "commit";
            this.commit.Size = new System.Drawing.Size(34, 37);
            this.commit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.commit.TabIndex = 6;
            this.commit.TabStop = false;
            this.commit.Click += new System.EventHandler(this.commit_Click);
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::MiniPIM.Properties.Resources.ICONback;
            this.back.Location = new System.Drawing.Point(26, 652);
            this.back.Margin = new System.Windows.Forms.Padding(2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(34, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back.TabIndex = 7;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // V_Producto_CrearModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(506, 708);
            this.Controls.Add(this.back);
            this.Controls.Add(this.commit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(-10000, 3000);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(506, 708);
            this.MinimumSize = new System.Drawing.Size(506, 708);
            this.Name = "V_Producto_CrearModificar";
            this.Text = "V_Producto_CrearModificar";
            this.Load += new System.EventHandler(this.V_Producto_CrearModificar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox commit;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox listBox_Asociado;
        private System.Windows.Forms.TextBox tLabel;
        private System.Windows.Forms.TextBox tGTIN;
        private System.Windows.Forms.TextBox tSKU;
        private System.Windows.Forms.Panel pThumbnail;
        private System.Windows.Forms.PictureBox Thumbnail;
        private System.Windows.Forms.Label lThumbnail;
        private System.Windows.Forms.ListBox listBox_NoAsociado;
    }
}