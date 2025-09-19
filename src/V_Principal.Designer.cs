namespace MiniPIM
{
    partial class V_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Principal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Dashboard = new System.Windows.Forms.Label();
            this.Products = new System.Windows.Forms.Label();
            this.Assets = new System.Windows.Forms.Label();
            this.Categories = new System.Windows.Forms.Label();
            this.Atributes = new System.Windows.Forms.Label();
            this.Relations = new System.Windows.Forms.Label();
            this.Account = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Account)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(45, 90);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 800);
            this.panel1.TabIndex = 7;
            // 
            // Dashboard
            // 
            this.Dashboard.AutoSize = true;
            this.Dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dashboard.Font = new System.Drawing.Font("Lexend", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.Dashboard.Location = new System.Drawing.Point(37, 42);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(170, 45);
            this.Dashboard.TabIndex = 8;
            this.Dashboard.Text = "Dashboard";
            this.Dashboard.Click += new System.EventHandler(this.Dashboard_Click);
            // 
            // Products
            // 
            this.Products.AutoSize = true;
            this.Products.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Products.Font = new System.Drawing.Font("Lexend", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Products.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(218)))));
            this.Products.Location = new System.Drawing.Point(213, 42);
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(140, 45);
            this.Products.TabIndex = 9;
            this.Products.Text = "Products";
            this.Products.Click += new System.EventHandler(this.Products_Click);
            // 
            // Assets
            // 
            this.Assets.AutoSize = true;
            this.Assets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Assets.Font = new System.Drawing.Font("Lexend", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(218)))));
            this.Assets.Location = new System.Drawing.Point(359, 42);
            this.Assets.Name = "Assets";
            this.Assets.Size = new System.Drawing.Size(111, 45);
            this.Assets.TabIndex = 10;
            this.Assets.Text = "Export";
            this.Assets.Click += new System.EventHandler(this.Assets_Click);
            // 
            // Categories
            // 
            this.Categories.AutoSize = true;
            this.Categories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Categories.Font = new System.Drawing.Font("Lexend", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(218)))));
            this.Categories.Location = new System.Drawing.Point(472, 42);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(167, 45);
            this.Categories.TabIndex = 11;
            this.Categories.Text = "Categories";
            this.Categories.Click += new System.EventHandler(this.Categories_Click);
            // 
            // Atributes
            // 
            this.Atributes.AutoSize = true;
            this.Atributes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Atributes.Font = new System.Drawing.Font("Lexend", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Atributes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(218)))));
            this.Atributes.Location = new System.Drawing.Point(645, 42);
            this.Atributes.Name = "Atributes";
            this.Atributes.Size = new System.Drawing.Size(156, 45);
            this.Atributes.TabIndex = 12;
            this.Atributes.Text = "Attributes";
            this.Atributes.Click += new System.EventHandler(this.Atributes_Click);
            // 
            // Relations
            // 
            this.Relations.AutoSize = true;
            this.Relations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Relations.Font = new System.Drawing.Font("Lexend", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Relations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(218)))));
            this.Relations.Location = new System.Drawing.Point(796, 42);
            this.Relations.Name = "Relations";
            this.Relations.Size = new System.Drawing.Size(145, 45);
            this.Relations.TabIndex = 13;
            this.Relations.Text = "Relations";
            this.Relations.Click += new System.EventHandler(this.Relations_Click);
            // 
            // Account
            // 
            this.Account.BackColor = System.Drawing.Color.Transparent;
            this.Account.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Account.Image = global::MiniPIM.Properties.Resources.ICONuser2;
            this.Account.Location = new System.Drawing.Point(1200, 26);
            this.Account.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(49, 48);
            this.Account.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Account.TabIndex = 14;
            this.Account.TabStop = false;
            this.Account.Click += new System.EventHandler(this.Account_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Lavender;
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox1.Font = new System.Drawing.Font("Lexend", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Items.AddRange(new object[] {
            "hola"});
            this.listBox1.Location = new System.Drawing.Point(971, 42);
            this.listBox1.Margin = new System.Windows.Forms.Padding(100, 10, 11, 10);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(256, 62);
            this.listBox1.TabIndex = 15;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // V_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1280, 949);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Account);
            this.Controls.Add(this.Relations);
            this.Controls.Add(this.Atributes);
            this.Controls.Add(this.Categories);
            this.Controls.Add(this.Assets);
            this.Controls.Add(this.Products);
            this.Controls.Add(this.Dashboard);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1298, 996);
            this.MinimumSize = new System.Drawing.Size(1298, 996);
            this.Name = "V_Principal";
            this.Text = "MiniPim";
            this.Load += new System.EventHandler(this.V_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Account)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Dashboard;
        private System.Windows.Forms.Label Products;
        private System.Windows.Forms.Label Assets;
        private System.Windows.Forms.Label Categories;
        private System.Windows.Forms.Label Atributes;
        private System.Windows.Forms.Label Relations;
        private System.Windows.Forms.PictureBox Account;
        private System.Windows.Forms.ListBox listBox1;
    }
}