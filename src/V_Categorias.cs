using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPIM
{
    public partial class V_Categorias : V_ListasPadre
    {
        private Cuenta cuenta;
        private V_Principal main;
        

        public V_Categorias(Cuenta cuenta, V_Principal main)
        {
            InitializeComponent();
            this.cuenta = cuenta;
            this.main = main;
        }

         private void V_Categorias_Load(object sender, EventArgs e)
         {
            dataGridView1.DataSource = null;
            CargarDataGrid();

         }
        public void CargarDataGrid ()
        {
            //Cargamos lista de productos de la cuenta -> DataGrid

            grupo21DBEntities bd = new grupo21DBEntities();


            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();


            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Product Cuantity", "Product Cuantity");

            //Añadimos columna de botones borrar/editar
            dataGridView1.Columns.Add("", "");

            //cargamos lista
            CategoriaP[] list = (from d in bd.CategoriaP where d.Cuenta1.ID.Equals(cuenta.ID) select d).ToArray();

            if (list.Length == 0)
            {
                labelNo.Visible = true;
                label3.Visible = true;
                pictureBox1.Visible = true;
            }
            else
            {
                labelNo.Visible = false;
                label3.Visible = false;
                pictureBox1.Visible = false;    
            }

            foreach (CategoriaP c in list)
            {
                //Button edit = new Button();
                //edit.Name = "Edit_" + p.SKU.ToString

                List<Object> parametros = new List<Object>();
                //parametros a mostrar en el datagrid

                parametros.Add(c.Nombre);

                int productos = 0;

                List<Producto> products = bd.Producto.ToList();

                productos = bd.Producto.Count(prod => prod.CategoriaP.Any(cat => cat.ID == c.ID));

                parametros.Add(productos);

                dataGridView1.Rows.Add(parametros.ToArray());

            }

            if (!dataGridView1.Columns.Contains("EditRowButton"))
            {
                DataGridViewImageColumn editC = new DataGridViewImageColumn
                {
                    Name = "editC",
                    HeaderText = "",
                    Image = Properties.Resources.ICONedit___copia,
                    Resizable = DataGridViewTriState.True,
                    Width = 50
                };
                //editC.ImageLayout = DataGridViewImageCellLayout;
                editC.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns.Add(editC);
            }

            if (!dataGridView1.Columns.Contains("borrarC"))
            {
                // Botón para editar columna
                DataGridViewImageColumn borrarC = new DataGridViewImageColumn
                {
                    Name = "borrarC",
                    HeaderText = "",
                    Image = Properties.Resources.ICONdelete___copia,
                    //ImageLayout=DataGridViewImageCellLayout.,
                    Width = 50
                };
                borrarC.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns.Add(borrarC);
            }

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.Columns[dataGridView1.Columns.Count - 2].DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.Columns[dataGridView1.Columns.Count - 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.ClearSelection();
        }
        



        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos si estamos en la columna de imágenes específica (por ejemplo, la columna 1)
            if (e.RowIndex != (-1) &&
                (e.ColumnIndex==3 || e.ColumnIndex==4)) 
            {
                dataGridView1.Cursor = Cursors.Hand;  // Cambiar el cursor a una mano
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Al salir de la celda, restauramos el cursor
            dataGridView1.Cursor = Cursors.Default;  // Restaurar al cursor por defecto
        }

        



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                
                string cell = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                main.Enabled = false;
                V_Categoria_CrearModificar popup = new V_Categoria_CrearModificar(main, this, cell);
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                int num = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                string cell = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (num <= 0)
                {
                    Eliminar(cell);
                } else {
                    main.Enabled = false;
                    VR_Eliminar popup = new VR_Eliminar(main, "Are you sure you want to delete the category: " + cell + "?", this, cell);
                    popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                    popup.StartPosition = FormStartPosition.Manual;
                    popup.Show();
                }
            }
        }

        public override void Eliminar(string id)
        {
           
            grupo21DBEntities bd = new grupo21DBEntities();
            var query1 = (from c in bd.CategoriaP
                          where c.Nombre == id
                          select c).ToList().FirstOrDefault();
            bd.CategoriaP.Remove(query1);
            bd.SaveChanges();
           
            CargarDataGrid();
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            grupo21DBEntities bd = new grupo21DBEntities();
            var query = (from p in bd.CategoriaP where p.Cuenta1.ID.Equals(main.Tienda.ID) select p).ToList();

            int num;
            if (query == null)
            {
                num = 0;
            }
            else
            {
                num = query.Count();
            }


            if (num < 3)
            {
                main.Enabled = false;
                V_Categoria_CrearModificar popup = new V_Categoria_CrearModificar(main, this);
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Show();
            }
            else
            {
                main.Enabled = false;
                VR_Alerta popup = new VR_Alerta("There are already 3 categories created", main);
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Show();
            }
        }
    }
}
