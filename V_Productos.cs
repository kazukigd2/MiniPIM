using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPIM
{
    public partial class V_Productos : V_ListasPadre
    {

        private Cuenta tienda;
        private V_Principal main;

        public V_Productos(Cuenta tienda, V_Principal main)
        {
            InitializeComponent();
            this.tienda = tienda;
            this.main = main;
        }

       

        public class PanelCell : DataGridViewCell
        {

            public PanelCell()
            {
                this.ValueType = typeof(string); // O cualquier otro tipo apropiado
                //this.FormattedValueType = typeof(string); // Necesario para evitar el error
            }
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

                // Crear un panel y botón al pintar la celda
                Panel panel = new Panel
                {
                    BackColor = Color.LightGray,
                    Size = new Size(cellBounds.Width - 4, cellBounds.Height - 4),
                    Location = new Point(cellBounds.Left + 2, cellBounds.Top + 2)
                    

                };

                Button button = new Button
                {
                    Text = "Primer",
                    Size = new Size(20, 30),
                    Location = new Point(5, 5)
                };

                Button button2 = new Button
                {
                    Text = "Segundo",
                    Size = new Size(20, 30),
                    Location = new Point(5, 5)
                };

                button.Click += (s, e) =>
                {
                    MessageBox.Show($"Button in row {rowIndex + 1} clicked!");
                };

                // Añadir el panel al DataGridView
                DataGridView grid = this.DataGridView;
                grid.Controls.Add(panel);
                panel.Anchor = AnchorStyles.Left;
                panel.Controls.Add(button);
                panel.Controls.Add(button2);
            }
        }

        public void cargarProducto()
        {
            //Conexion a la base de datos
            grupo21DBEntities bd = new grupo21DBEntities();
            
            //Limpiamos el grid que hubiera
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            

            //Creamos la columna Thumbnail
            DataGridViewImageColumn thumb = new DataGridViewImageColumn
            {
                Name = "thumb",
                HeaderText = "Thumbnail",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
            };
            dataGridView1.Columns.Insert(0, thumb);

            //Creamos las columnas Label y SKU
            dataGridView1.Columns.Add("Label", "Label");
            dataGridView1.Columns.Add("SKU", "SKU");

            //Cargamos la lista completa de productos de la cuenta
            Producto[] listaProd = (from d in bd.Producto where d.Cuenta1.ID.Equals(tienda.ID) select d).ToArray();

            //Si no hubiera productos mostramos las etiquetas de no productos y si no el grid
            if (listaProd.Length == 0)
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

            // Creamos la lista de atributos reales que tiene nuestra cuenta
            List<Atributo> atributosReales = (from a in bd.Atributo
                                              where tienda.Nombre.Equals(a.Cuenta1.Nombre)
                                              select a).ToList();

            //Si no tuviera atributos inicializamos la lista vacia
            if (atributosReales == null)
            {
                atributosReales = new List<Atributo>();
            }

            //Creamos un contador para como maximo mostrar 3 atributos en la lista
            int contador = atributosReales.Count;
            if (contador > 3)
            {
                contador = 3;
            }

            //Creamos las columnas de atributos hasta un maximo de 3
            for (int i = 0; i < contador; i++)
            {
                dataGridView1.Columns.Add(atributosReales[i].Nombre, atributosReales[i].Nombre);
            }


            //cargamos lista de productos de la tienda
            var query = (from d in bd.Producto where d.Cuenta1.ID.Equals(tienda.ID) select d).ToList();
            List<Producto> list = query.ToList();

            //Creamos la fila con todos los datos del producto
            foreach (Producto p in list)
            {
                //Lista de prooductos que va en cada fila
                List<Object> parametros = new List<Object>();

                //Rellenamos columna de Thumbmail con foto si la hubiera y rellenamos la posicion 0
                if (p.Thumbnail != null)
                {
                    parametros.Add(Image.FromStream(new MemoryStream(p.Thumbnail)));
                }
                else
                {
                    parametros.Add(ResizeImage(Properties.Resources.ICONnoimage, 128, 128));
                }
                
                //Añadimos en la posicion 1 del array parametros el label
                parametros.Add(p.Label);
                //Añadimos en la posicion 2 del array parametros el SKU
                parametros.Add(p.SKU);



                //Cargamos todos los atributos de nuestro producto en una lista
                List<AtributoProducto> atributosProductoActual = p.AtributoProducto.ToList();

                //Bucle para añadir los 3 primeros atributos personalizados
                for (int i= 0; i< contador; i++)
                {
                    //Buscamos si nuestro atributo coincide con el de la lista para mostrarlo
                    AtributoProducto atributoProducto = atributosProductoActual.FirstOrDefault(ap => ap.Atributo1.ID == atributosReales[i].ID);

                    //Mostramos en caso que no sea null el atributo con el formato que queremos
                    if (atributoProducto != null)
                    {
                        if (atributoProducto.ContenidoBinario != null)
                        {
                            parametros.Add(atributoProducto.Atributo1.Tipo);
                        }
                        else if (atributoProducto.ContenidoEntero != null)
                        {
                            parametros.Add(atributoProducto.ContenidoEntero.ToString());
                        }
                        else if (atributoProducto.ContenidoReal != null)
                        {
                            parametros.Add(atributoProducto.ContenidoReal.ToString());
                        }
                        else if (atributoProducto.ContenidoBoolean != null)
                        {
                            if(atributoProducto.ContenidoBoolean == true)
                            {
                                parametros.Add("True");
                            } else
                            {
                                parametros.Add("False");
                            }                         
                        }
                        else
                        {
                            parametros.Add(atributoProducto.ContenidoTexto);
                        }
                    }
                    else
                    {
                        // Si no hay valor para este atributo, agrega una celda vacía
                        parametros.Add(null);
                    }
                }


                   //Añadimos todas las columnas creadas personalizadas
                   dataGridView1.Rows.Add(parametros.ToArray());

                }

                //Añadimos boton editar en la posicion del array -2
                if (!dataGridView1.Columns.Contains("EditRowButton"))
                {
                    // Botón para editar columna
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

                //Añadimos boton borrar en la posicion del array -1
                if (!dataGridView1.Columns.Contains("borrarC"))
                {
                    // Botón para borrar columna
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


                //Formato de las columnas de los botones
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataGridView1.Columns[dataGridView1.Columns.Count - 2].DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView1.Columns[dataGridView1.Columns.Count - 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.ClearSelection();

                // Para cada columna, puedes ajustar su comportamiento
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                     column.DefaultCellStyle.WrapMode = DataGridViewTriState.False; // Evita los saltos de línea.
                }
        }

        private void V_Productos_Load(object sender, EventArgs e)
        {
            cargarProducto();
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos si estamos en la columna de imágenes específica (por ejemplo, la columna 1)
            if (e.RowIndex!=(-1) && 
                (e.ColumnIndex == dataGridView1.Columns.Count-1 || 
                e.ColumnIndex == dataGridView1.Columns.Count - 2 ||
                e.ColumnIndex <3))  // Suponiendo que la columna 1 es la de las imágenes
            {
                dataGridView1.Cursor = Cursors.Hand;  // Cambiar el cursor a una mano
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Al salir de la celda, restauramos el cursor
            dataGridView1.Cursor = Cursors.Default;  // Restaurar al cursor por defecto
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grupo21DBEntities bd = new grupo21DBEntities();
            if (e.RowIndex>=0&& e.ColumnIndex < 3)
            {
                //estamos en una fila válida de productos, en las columnas, thumbnail, SKU o label
                //hay que cambiar el panel, como???
                
                string sku = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                Producto p = (from pr in bd.Producto where pr.SKU.Equals(sku) select pr).ToList().First();

                main.cambiarVista(new V_ProductoIndividual(p, main));


                

            }else if(e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                //editar
                main.Enabled = false;
                string sku = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                Producto p = (from pr in bd.Producto where pr.SKU.Equals(sku) select pr).ToList().First();
                V_Producto_CrearModificar popup= new V_Producto_CrearModificar(false, p, main.Tienda, main, null, this);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.Show();


            }
            else if(e.RowIndex>=0 && e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                string cell = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                main.Enabled = false;
                VR_Eliminar popup = new VR_Eliminar(main, "Are you sure you want to delete this product " + cell + "?", this, cell);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
                popup.Show();
            }
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            main.Enabled = false;
            V_Producto_CrearModificar popup =new V_Producto_CrearModificar(true, null, main.Tienda, main, null, this);
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(main.Location.X + (main.Width - popup.Width) / 2, main.Location.Y + (main.Height - popup.Height) / 2);
            popup.Show();

        }

        public override void Eliminar(string id)
        {

            grupo21DBEntities bd = new grupo21DBEntities();
            var query1 = (from c in bd.Producto
                          where c.SKU.Equals(id)
                          select c).ToList().FirstOrDefault();
            bd.Producto.Remove(query1);
            bd.SaveChanges();

            cargarProducto();
        }

        // Función para redimensionar la imagen a un tamaño específico
        private Image ResizeImage(Image img, int width, int height)
        {
            // Crear un nuevo Bitmap con las dimensiones deseadas
            Bitmap resizedBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                // Configurar la calidad de la imagen
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height); // Redimensionar la imagen
            }

            return resizedBitmap;
        }

    }
}
