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
    public partial class V_Atributo_Crear : Form
    {
        private V_Principal main;
        private V_Atributos atr;
        public V_Atributo_Crear(V_Principal main, V_Atributos a)
        {
            InitializeComponent();
            this.main = main;
            this.atr = a;
        }


        private void V_Atributo_Crear_Load(object sender, EventArgs e)
        {
            List<string> tipos = new List<string> { "String", "Int", "Real", "Boolean", "Image", "Video", "PDF", "Others" };
            comboBoxTipo.DataSource = tipos;
        }

        private void Guardar()
        {
            string nombre = textBoxNombre.Text.Trim();
            string tipoDato = comboBoxTipo.SelectedItem.ToString();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipoDato))
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
            Atributo nuevo = new Atributo();
            nuevo.Tipo = tipoDato;
            nuevo.Nombre = nombre;
            nuevo.Cuenta = main.Tienda.ID;
            bd.Atributo.Add(nuevo);

            if(tipoDato.Equals("Boolean"))
            {
                var productos = (from p in bd.Producto where p.Cuenta1.ID.Equals(main.Tienda.ID) select p).ToArray();

                foreach (Producto prod in productos)
                {
                    AtributoProducto a = new AtributoProducto
                    {
                        Producto = prod.ID,
                        Atributo = nuevo.ID,
                        ContenidoBoolean = false
                    };
                    bd.AtributoProducto.Add(a);
                }
            }

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
