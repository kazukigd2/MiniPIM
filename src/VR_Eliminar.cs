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
    public partial class VR_Eliminar : Form
    {
        private V_ListasPadre papi;
        private V_Principal main;
        private string id;
        public VR_Eliminar(V_Principal v1, string alerta, V_ListasPadre v, string id)
        {
            InitializeComponent();
            labelEliminar.Text = alerta;
            papi = v;
            main = v1;
            this.id = id;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            main.Activate();
            this.Close();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            main.Enabled = true;   
            main.Activate();
            papi.Eliminar(id);
            this.Close();

        }
    }
}
