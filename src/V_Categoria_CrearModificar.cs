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
    public partial class V_Categoria_CrearModificar : Form
    {
        private V_Principal main;
        private V_Categorias cat;
        private String celda;
        private bool modificar = false;
        private string nombreACambiar = null;

        public V_Categoria_CrearModificar(V_Principal main, V_Categorias cat)
        {
            InitializeComponent();
            this.main = main;
            this.cat = cat;
            label1.Text = "NEW CATEGORY";
        }

        public V_Categoria_CrearModificar(V_Principal main, V_Categorias cat, String nombre)
        {
            this.main = main;  
            this.cat = cat;
            this.celda = nombre;
            InitializeComponent();
            label1.Text = "MODIFY";
            cargarNombre(nombre);
            modificar = true;
            nombreACambiar = nombre; 
        }

        private void cargarNombre(String nombre)
        {
            textBoxNombre.Text = nombre;
        }

        private void commit_Click(object sender, EventArgs e)
        {
            guardarNuevaCategoria();
        }

        private void guardarNuevaCategoria()
        {
            string nombre = textBoxNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Please enter a name for the category.");
                return;
            }
            grupo21DBEntities bd = new grupo21DBEntities();

            if (modificar)
            {
                var query2 = (from p in bd.CategoriaP where p.Cuenta1.ID.Equals(main.Tienda.ID) select p).ToArray();
                for (int i = 0; i < query2.Length; i++)
                {
                    if (query2[i].Nombre.Equals(nombre))
                    {
                        MessageBox.Show("Duplicate name, please insert another name");
                        return;

                    }

                }
                var categoriaModi = (from c in bd.CategoriaP where c.Nombre.Equals(nombreACambiar) select c).FirstOrDefault();
                CategoriaP modi = (CategoriaP) categoriaModi;
                modi.Nombre = nombre;
                
                bd.SaveChanges();
                cat.CargarDataGrid();
                main.Enabled = true;
                main.Activate();
                this.Close();
            }
            else
            {
                var query2 = (from p in bd.CategoriaP where p.Cuenta1.ID.Equals(main.Tienda.ID) select p).ToArray();

                for (int i = 0; i < query2.Length; i++)
                {
                    if (query2[i].Nombre.Equals(nombre))
                    {
                        MessageBox.Show("Duplicate name, please insert another name");
                        return;

                    }

                }
                CategoriaP nuevo = new CategoriaP();

                nuevo.Nombre = nombre;
                nuevo.Cuenta = main.Tienda.ID;
                bd.CategoriaP.Add(nuevo);
                bd.SaveChanges();
                cat.CargarDataGrid();
                main.Enabled = true;
                main.Activate();
                this.Close();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Enabled = true;
            main.Activate();
        }
    }
}
