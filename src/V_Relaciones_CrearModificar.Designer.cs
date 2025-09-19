namespace MiniPIM
{
    partial class V_Relaciones_CrearModificar
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
            this.back = new System.Windows.Forms.PictureBox();
            this.commit = new System.Windows.Forms.PictureBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_A = new System.Windows.Forms.ListBox();
            this.listBox_B = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commit)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::MiniPIM.Properties.Resources.ICONback;
            this.back.Location = new System.Drawing.Point(41, 433);
            this.back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(45, 46);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back.TabIndex = 20;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // commit
            // 
            this.commit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commit.Image = global::MiniPIM.Properties.Resources.ICONtick;
            this.commit.Location = new System.Drawing.Point(410, 433);
            this.commit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commit.Name = "commit";
            this.commit.Size = new System.Drawing.Size(45, 46);
            this.commit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.commit.TabIndex = 19;
            this.commit.TabStop = false;
            this.commit.Click += new System.EventHandler(this.commit_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Lexend", 10.8F);
            this.textBoxNombre.Location = new System.Drawing.Point(212, 131);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNombre.MaxLength = 250;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(235, 30);
            this.textBoxNombre.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(24, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Relation\'s Name";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lexend", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(411, 90);
            this.label1.TabIndex = 16;
            this.label1.Text = "NEW RELATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_A
            // 
            this.listBox_A.BackColor = System.Drawing.Color.GhostWhite;
            this.listBox_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_A.Font = new System.Drawing.Font("Lexend", 10.8F);
            this.listBox_A.ForeColor = System.Drawing.Color.Indigo;
            this.listBox_A.FormattingEnabled = true;
            this.listBox_A.ItemHeight = 29;
            this.listBox_A.Location = new System.Drawing.Point(41, 202);
            this.listBox_A.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_A.Name = "listBox_A";
            this.listBox_A.Size = new System.Drawing.Size(185, 176);
            this.listBox_A.TabIndex = 21;
            this.listBox_A.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_A_MouseClick);
            // 
            // listBox_B
            // 
            this.listBox_B.BackColor = System.Drawing.Color.GhostWhite;
            this.listBox_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_B.Font = new System.Drawing.Font("Lexend", 10.8F);
            this.listBox_B.ForeColor = System.Drawing.Color.Indigo;
            this.listBox_B.FormattingEnabled = true;
            this.listBox_B.ItemHeight = 29;
            this.listBox_B.Location = new System.Drawing.Point(269, 202);
            this.listBox_B.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_B.Name = "listBox_B";
            this.listBox_B.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_B.Size = new System.Drawing.Size(185, 176);
            this.listBox_B.TabIndex = 22;
            this.listBox_B.TabStop = false;
            this.listBox_B.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_B_MouseClick);
            // 
            // V_Relaciones_CrearModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 503);
            this.Controls.Add(this.listBox_B);
            this.Controls.Add(this.listBox_A);
            this.Controls.Add(this.back);
            this.Controls.Add(this.commit);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(499, 503);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(499, 503);
            this.Name = "V_Relaciones_CrearModificar";
            this.Text = "V_Relaciones_CrearModificar";
            this.Load += new System.EventHandler(this.V_Relaciones_CrearModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.PictureBox commit;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_A;
        private System.Windows.Forms.ListBox listBox_B;
    }
}