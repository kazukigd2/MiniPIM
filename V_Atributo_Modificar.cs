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
    public partial class V_Atributo_Modificar : Form
    {
        private V_Principal main;
        private V_Atributos atr;
        private string celda;

        public V_Atributo_Modificar(V_Principal main, V_Atributos a, string cell)
        {
            InitializeComponent();
            this.main = main;
            this.atr = a;
            this.celda = cell;  
        }

        private void Guardar()
        {
            string nombre = textBox1.Text.Trim();
            
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }
            grupo21DBEntities bd = new grupo21DBEntities();
            
            var query2 = (from p in bd.Atributo where p.Cuenta1.ID.Equals(main.Tienda.ID) select p).ToArray();
            
            for (int i = 0; i < query2.Length; i++)
            {
                if (query2[i].Nombre.Equals(nombre))
                {
                    MessageBox.Show("Duplicate name, please insert another name");
                    return;
                    
                }

            }
            var query = (from p in bd.Atributo where p.Nombre.Equals(celda) select p).FirstOrDefault();
            Atributo upd = (Atributo)query;
            upd.Nombre = nombre;
            bd.SaveChanges();
            atr.CargarDatosEnGrid();
            main.Enabled = true;
            main.Activate();
            this.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Enabled = true;
            main.Activate();
        }

        private void commit_Click(object sender, EventArgs e)
        {
            Guardar();
           
        }
    }
}
