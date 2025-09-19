namespace MiniPIM
{
    partial class V_Exportar_Filtrado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.back = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ComboBoxAccount = new System.Windows.Forms.ComboBox();
            this.comboBoxLabel = new System.Windows.Forms.ComboBox();
            this.comboBoxSKU = new System.Windows.Forms.ComboBox();
            this.comboBoxPrecio = new System.Windows.Forms.ComboBox();
            this.comboBoxOfferPrime = new System.Windows.Forms.ComboBox();
            this.comboBoxOtros1 = new System.Windows.Forms.ComboBox();
            this.comboBoxOtros2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGTIN = new System.Windows.Forms.ComboBox();
            this.ExportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::MiniPIM.Properties.Resources.ICONback;
            this.back.Location = new System.Drawing.Point(10, 660);
            this.back.Margin = new System.Windows.Forms.Padding(2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(34, 37);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back.TabIndex = 9;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(10, 108);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(598, 518);
            this.dataGridView1.TabIndex = 12;
            // 
            // ComboBoxAccount
            // 
            this.ComboBoxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAccount.Enabled = false;
            this.ComboBoxAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ComboBoxAccount.Items.AddRange(new object[] {
            "Fulfilled By"});
            this.ComboBoxAccount.Location = new System.Drawing.Point(162, 73);
            this.ComboBoxAccount.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxAccount.Name = "ComboBoxAccount";
            this.ComboBoxAccount.Size = new System.Drawing.Size(70, 21);
            this.ComboBoxAccount.TabIndex = 20;
            this.ComboBoxAccount.Tag = "Fulfilled By";
            // 
            // comboBoxLabel
            // 
            this.comboBoxLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLabel.Enabled = false;
            this.comboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.comboBoxLabel.Items.AddRange(new object[] {
            "Title"});
            this.comboBoxLabel.Location = new System.Drawing.Point(86, 73);
            this.comboBoxLabel.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxLabel.Name = "comboBoxLabel";
            this.comboBoxLabel.Size = new System.Drawing.Size(70, 21);
            this.comboBoxLabel.TabIndex = 21;
            this.comboBoxLabel.Tag = "Title";
            // 
            // comboBoxSKU
            // 
            this.comboBoxSKU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSKU.Enabled = false;
            this.comboBoxSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.comboBoxSKU.Items.AddRange(new object[] {
            "SKU"});
            this.comboBoxSKU.Location = new System.Drawing.Point(10, 73);
            this.comboBoxSKU.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSKU.Name = "comboBoxSKU";
            this.comboBoxSKU.Size = new System.Drawing.Size(70, 21);
            this.comboBoxSKU.TabIndex = 22;
            this.comboBoxSKU.Tag = "SKU";
            // 
            // comboBoxPrecio
            // 
            this.comboBoxPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.comboBoxPrecio.Location = new System.Drawing.Point(310, 73);
            this.comboBoxPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPrecio.Name = "comboBoxPrecio";
            this.comboBoxPrecio.Size = new System.Drawing.Size(70, 21);
            this.comboBoxPrecio.TabIndex = 23;
            this.comboBoxPrecio.Tag = "Price";
            this.comboBoxPrecio.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrecio_SelectedIndexChanged);
            // 
            // comboBoxOfferPrime
            // 
            this.comboBoxOfferPrime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOfferPrime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.comboBoxOfferPrime.Location = new System.Drawing.Point(385, 73);
            this.comboBoxOfferPrime.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOfferPrime.Name = "comboBoxOfferPrime";
            this.comboBoxOfferPrime.Size = new System.Drawing.Size(70, 21);
            this.comboBoxOfferPrime.TabIndex = 24;
            this.comboBoxOfferPrime.Tag = "Offer Prime";
            this.comboBoxOfferPrime.SelectedIndexChanged += new System.EventHandler(this.comboBoxOfferPrime_SelectedIndexChanged);
            // 
            // comboBoxOtros1
            // 
            this.comboBoxOtros1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOtros1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.comboBoxOtros1.Location = new System.Drawing.Point(463, 73);
            this.comboBoxOtros1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOtros1.Name = "comboBoxOtros1";
            this.comboBoxOtros1.Size = new System.Drawing.Size(70, 21);
            this.comboBoxOtros1.TabIndex = 25;
            this.comboBoxOtros1.Tag = "Optional1";
            this.comboBoxOtros1.SelectedIndexChanged += new System.EventHandler(this.comboBoxOtros1_SelectedIndexChanged);
            // 
            // comboBoxOtros2
            // 
            this.comboBoxOtros2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOtros2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.comboBoxOtros2.Location = new System.Drawing.Point(539, 73);
            this.comboBoxOtros2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOtros2.Name = "comboBoxOtros2";
            this.comboBoxOtros2.Size = new System.Drawing.Size(70, 21);
            this.comboBoxOtros2.TabIndex = 26;
            this.comboBoxOtros2.Tag = "Optional2";
            this.comboBoxOtros2.SelectedIndexChanged += new System.EventHandler(this.comboBoxOtros2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 39);
            this.label1.TabIndex = 27;
            this.label1.Text = "Export to Amazon";
            // 
            // comboBoxGTIN
            // 
            this.comboBoxGTIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGTIN.Enabled = false;
            this.comboBoxGTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.comboBoxGTIN.Items.AddRange(new object[] {
            "Amazon_SKU"});
            this.comboBoxGTIN.Location = new System.Drawing.Point(236, 73);
            this.comboBoxGTIN.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGTIN.Name = "comboBoxGTIN";
            this.comboBoxGTIN.Size = new System.Drawing.Size(70, 21);
            this.comboBoxGTIN.TabIndex = 28;
            this.comboBoxGTIN.Tag = "Amazon SKU";
            // 
            // ExportButton
            // 
            this.ExportButton.BackColor = System.Drawing.Color.GhostWhite;
            this.ExportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.ExportButton.ForeColor = System.Drawing.Color.Indigo;
            this.ExportButton.Location = new System.Drawing.Point(411, 660);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(197, 32);
            this.ExportButton.TabIndex = 29;
            this.ExportButton.Text = "Export to CSV";
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // V_Exportar_Filtrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 708);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.comboBoxGTIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOtros2);
            this.Controls.Add(this.comboBoxOtros1);
            this.Controls.Add(this.comboBoxOfferPrime);
            this.Controls.Add(this.comboBoxPrecio);
            this.Controls.Add(this.comboBoxSKU);
            this.Controls.Add(this.comboBoxLabel);
            this.Controls.Add(this.ComboBoxAccount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 708);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 708);
            this.Name = "V_Exportar_Filtrado";
            this.Text = "V_Exportar_Filtrado";
            this.Load += new System.EventHandler(this.V_Exportar_Filtrado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox ComboBoxAccount;
        private System.Windows.Forms.ComboBox comboBoxLabel;
        private System.Windows.Forms.ComboBox comboBoxSKU;
        private System.Windows.Forms.ComboBox comboBoxPrecio;
        private System.Windows.Forms.ComboBox comboBoxOfferPrime;
        private System.Windows.Forms.ComboBox comboBoxOtros1;
        private System.Windows.Forms.ComboBox comboBoxOtros2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGTIN;
        private System.Windows.Forms.Button ExportButton;
    }
}