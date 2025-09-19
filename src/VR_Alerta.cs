using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPIM
{
    public partial class VR_Alerta : Form
    {
        private V_Principal main;
        public VR_Alerta(string alerta, V_Principal v1)
        {
            InitializeComponent();
            labelAlerta.Text = alerta;
            main = v1;
        }

        private void back_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            main.Activate();
            this.Close();
        }
    }
}
