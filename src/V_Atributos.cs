using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPIM
{
    public partial class V_Atributos : V_ListasPadre
    {

        private Cuenta tienda;
        private V_Principal main;
        public V_Atributos(Cuenta tienda, V_Principal main)
        {
            
            InitializeComponent();
            this.tienda = tienda;
            this.main = main;
        }

        public void CargarDatosEnGrid()
        {
            grupo21DBEntities bd = new grupo21DBEntities();


            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();


            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("", "");

            //cargamos lista
            Atributo[] list = (from d in bd.Atributo where d.Cuenta1.ID.Equals(tienda.ID) select d).ToArray();

            if (list.Length == 0)
            {
                labelNo.Visible = true;
                label3.Visible = true;
                pictureBox1.Visible = true;
            } else
            {
                labelNo.Visible = false;
                label3.Visible = false;
                pictureBox1.Visible = false;
            }

            foreach (Atributo a in list)
            {
                //Button edit = new Button();
                //edit.Name = "Edit_" + p.SKU.ToString

                List<Object> parametros = new List<Object>();
                //parametros a mostrar en el datagrid

                parametros.Add(a.Tipo);
                parametros.Add(a.Nombre);

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
        private void V_Atributos_Load(object sender, EventArgs e)
        {
            CargarDatosEnGrid();    
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos si estamos en la columna de imágenes específica (por ejemplo, la columna 1)
            if (e.RowIndex != (-1) &&
                (e.ColumnIndex == dataGridView1.Columns.Count - 1 ||
                e.ColumnIndex == dataGridView1.Columns.Count - 2 ||
                e.ColumnIndex < 3))  // Suponiendo que la columna 1 es la de las imágenes
            {
                dataGridView1.Cursor = Cursors.Hand;  // Cambiar el cursor a una mano
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Al salir de la celda, restauramos el cursor
            dataGridView1.Cursor = Cursors.Default;  // Restaurar al cursor por defecto
        }

        // Evento para manejar los clics en los botones
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // Verificar que el clic sea en una celda válida
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                string cell = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                main.Enabled = false;
                V_Atributo_Modificar popup = new V_Atributo_Modificar(main, this, cell);
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                // borrar
                grupo21DBEntities bd = new grupo21DBEntities();
                string cell = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                var query = (from p in bd.Atributo where p.Nombre.Equals(cell) select p).FirstOrDefault();
                Atributo a = (Atributo)query;
                main.Enabled = false;
                VR_Eliminar popup = new VR_Eliminar(main, "Are you sure you want to remove the attribute: " + cell + "?", this, cell);
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Show();
                
            }
        }

        public override void Eliminar(string id)
        {

            grupo21DBEntities bd = new grupo21DBEntities();
            var query1 = (from c in bd.Atributo
                where c.Nombre == id
                select c).ToList().FirstOrDefault();
            bd.Atributo.Remove(query1);
            bd.SaveChanges();
            CargarDatosEnGrid();
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            grupo21DBEntities bd = new grupo21DBEntities();
            var query = (from p in bd.Atributo where p.Cuenta1.ID.Equals(main.Tienda.ID) select p).ToList();

            int num;
            if (query == null)
            {
                num = 0;
            } else
            {
                num = query.Count();    
            }

            
            if (num < 5)
            {
                main.Enabled = false;
                V_Atributo_Crear popup = new V_Atributo_Crear(main, this);
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Show();  
            } else
            {
                main.Enabled = false;
                VR_Alerta popup = new VR_Alerta("There are already 5 attributes created", main);
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Show();  
            }
            

        }
    }
}
