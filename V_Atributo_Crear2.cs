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
    public partial class V_Atributo_Crear2 : UserControl
    {
        public V_Atributo_Crear2()
        {
            InitializeComponent();
        }

        private void V_Atributo_Crear_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//volver
        {
            this.Parent.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e)//aceptar
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
