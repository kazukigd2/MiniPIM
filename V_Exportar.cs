using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiniPIM
{
    public partial class V_Exportar : UserControl
    {
        private Cuenta tienda;
        private V_Principal main;
        private int FiltroSeleccionado = -1;
        private CategoriaP Categoria_seleccionada;
        private DateTime fecha_Seleccionada;
        private List<Producto> listaMostrar = new List<Producto>();
        public V_Exportar(Cuenta tienda, V_Principal main)
        {
            InitializeComponent();
            this.tienda = tienda;
            this.main = main;
        }

        private void V_Exportar_Load(object sender, EventArgs e)
        {
            grupo21DBEntities bd = new grupo21DBEntities();
            List<CategoriaP> c = (from x in bd.CategoriaP
                            where x.Cuenta.Equals(tienda.ID)
                            select x)
                        .ToList();
            CategoryList.DataSource = c;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            comboBox1.Items.Add("Without filter");
            comboBox1.Items.Add("Date");
            comboBox1.Items.Add("Category");
            comboBox1.Items.Add("Category and date");
            CanalVentaComboBox.Items.Add("Amazon");
            CanalVentaComboBox.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            emptyLabel.Visible = false;
            recargar_vista();
        }

        private void cargarProductosFiltrados() {
            grupo21DBEntities bd = new grupo21DBEntities();
            switch (FiltroSeleccionado)
            {
                case 0: //sin filtro
                    listaMostrar = (from x in bd.Producto
                                        where x.Cuenta==tienda.ID
                                        select x)
                        .ToList();
                    break;
                case 1: //por fecha
                    
                    listaMostrar = (from x in bd.Producto
                                    where (x.Cuenta == tienda.ID) && (x.FechaModificacion>=fecha_Seleccionada)
                                    select x)
                        .ToList();
                    break;
                case 2: //por categoria
                    int id = -1;
                    if (Categoria_seleccionada != null)
                    {
                        id = Categoria_seleccionada.ID;
                    }

                    listaMostrar = (from x in bd.Producto
                                    where (x.Cuenta == tienda.ID) && (x.CategoriaP.Any(c=>c.ID==id))
                                    select x)
                        .ToList();
                    break;
                case 3: //por categoria y fecha
                    int id2 = -1;
                    if (Categoria_seleccionada != null)
                    {
                        id2 = Categoria_seleccionada.ID;
                    }
                    listaMostrar = (from x in bd.Producto
                                    where (x.Cuenta == tienda.ID) && (x.CategoriaP.Any(c => c.ID == id2)) && (x.FechaModificacion >= fecha_Seleccionada)
                                    select x)
                        .ToList();
                    break;
                default:
                    break;
            }

            cargarProducto();

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
            Producto[] listaProd = listaMostrar.ToArray();

            //Si no hubiera productos mostramos las etiquetas de no productos y si no el grid
            if (listaProd.Length == 0)
            {
                emptyLabel.Visible=true;
                dataGridView1.Visible = false;
            }
            else
            {
                emptyLabel.Visible = false;
                dataGridView1.Visible = true;
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
            List<Producto> list = listaMostrar;

            //Creamos la fila con todos los datos del producto
            foreach (Producto p in list)
            {
                //Lista de prooductos que va en cada fila
                List<Object> parametros = new List<Object>();

                //Rellenamos columna de Thumbmail con foto si la hubiera y rellenamos la posicion 0
                if (p.Thumbnail != null)
                {
                    //parametros.Add();
                    parametros.Add(ResizeImage(Image.FromStream(new MemoryStream(p.Thumbnail)), 60, 60));
                }
                else
                {
                    parametros.Add(ResizeImage(Properties.Resources.ICONnoimage, 60, 60));
                }

                //Añadimos en la posicion 1 del array parametros el label
                parametros.Add(p.Label);
                //Añadimos en la posicion 2 del array parametros el SKU
                parametros.Add(p.SKU);



                //Cargamos todos los atributos de nuestro producto en una lista
                List<AtributoProducto> atributosProductoActual = p.AtributoProducto.ToList();

                //Bucle para añadir los 3 primeros atributos personalizados
                for (int i = 0; i < contador; i++)
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
                            if (atributoProducto.ContenidoBoolean == true)
                            {
                                parametros.Add("True");
                            }
                            else
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
            dataGridView1.ClearSelection();

            // Para cada columna, puedes ajustar su comportamiento
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False; // Evita los saltos de línea.
            }
        }

        private void recargar_vista() {

            switch (FiltroSeleccionado) {
                case 0: //sin filtro
                    monthCalendar1.Hide();
                    CategoryList.Hide();
                    cargarProductosFiltrados();
                    break;
                case 1: //por fecha
                    monthCalendar1.Show();
                    CategoryList.Hide();
                    break;
                case 2: //por categoria
                    monthCalendar1.Hide();
                    CategoryList.Show();
                    break;
                case 3: //por categoria y fecha
                    monthCalendar1.Show();
                    CategoryList.Show();
                    break;
                default:
                    monthCalendar1.Hide();
                    CategoryList.Hide();
                    break;
            }

            monthCalendar1.SelectionStart = DateTime.Now.Date;
            monthCalendar1.SelectionEnd = DateTime.Now;
            if (CategoryList.Items.Count != 0)
            {
                CategoryList.SelectedIndex = 0;
            }
            Categoria_seleccionada = (CategoriaP)CategoryList.SelectedItem;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltroSeleccionado = comboBox1.SelectedIndex;
            recargar_vista();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (FiltroSeleccionado == -1) return;
            fecha_Seleccionada = monthCalendar1.SelectionStart;
            cargarProductosFiltrados();
        }

        private void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroSeleccionado == -1) return;
            Categoria_seleccionada = (CategoriaP)CategoryList.SelectedItems[0];
            cargarProductosFiltrados();
        }

        private void CanalVentaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bool x = CanalVentaComboBox.SelectedIndex >= 0;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (listaMostrar.Count >= 1)
            {
                main.Enabled = false;
                Form exportarFiltrado = new V_Exportar_Filtrado(main, listaMostrar, tienda);
                exportarFiltrado.StartPosition = FormStartPosition.Manual;
                exportarFiltrado.Location = new Point(main.Location.X + (main.Width - exportarFiltrado.Width) / 2, main.Location.Y + (main.Height - exportarFiltrado.Height) / 2);
                exportarFiltrado.Show();
            }
            else {
                main.Enabled = false;
                Form alerta = new VR_Alerta("You need to have at least one item", main);
                alerta.StartPosition = FormStartPosition.Manual;
                alerta.Location = new Point(main.Location.X + (main.Width - alerta.Width) / 2, main.Location.Y + (main.Height - alerta.Height) / 2);
                alerta.Show();
            }
        }

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
