using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using File = System.IO.File;

namespace MiniPIM
{
    public partial class V_ProductoIndividual : V_ListasPadre
    {
        WebBrowser webBrowser;
        private Producto producto;
        private V_Principal main;
        List<string> tmppaths = new List<string>();
        public int idVideo;

        public Producto Producto { get => producto; set => producto = value; }

        public V_ProductoIndividual(Producto producto, V_Principal main)
        {
            InitializeComponent();

            this.Producto = producto;
            this.main = main;
            Random random = new Random();
            idVideo = random.Next(0, 100000); ;
        }

  

        private void abrirArchivo(object sender, EventArgs e)
        {
            //lo puede llamar el panel, el picturebox y el label
            //bytes -> nombre de panel (ATRIBUTO)
            grupo21DBEntities bd = new grupo21DBEntities();

            Panel p;
            if (sender.GetType().Equals(new PictureBox().GetType()))
            {
                //lo llama la imagen
                PictureBox pb = (PictureBox)sender;
                p = pb.Parent as Panel;  
            }
            else if (sender.GetType().Equals(panel1.GetType()))
            {
                //lo llama el panel
                p = (Panel)sender;
            }
            else
            {
                Label l = (Label)sender;
                p = l.Parent as Panel;
            }
            string[] split = p.Name.Split('_');
            string nombre = split[1];

            AtributoProducto a = (from x in bd.AtributoProducto where x.Atributo1.Nombre.Equals(nombre) && x.Producto.Equals(Producto.ID) select x).FirstOrDefault();
            byte[] b = a.ContenidoBinario;
            


            using (MemoryStream ms = new MemoryStream(b))
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "temp.pdf");
                tmppaths.Add(tempPath);
                File.WriteAllBytes(tempPath, ms.ToArray());  // Guarda temporalmente el archivo para visualizarlo
                Process.Start(new ProcessStartInfo(tempPath));  // Muestra el PDF en el WebBrowser
            }

        }


        private Control cargarContenidoAtributo(Atributo a)
        {

            grupo21DBEntities bd = new grupo21DBEntities();


            List<AtributoProducto> query = (from x in bd.AtributoProducto where x.Atributo1.ID.Equals(a.ID) && x.Producto1.ID.Equals(Producto.ID) select x).ToList();

            if (query.Count > 0)
            {
                AtributoProducto contenido = query.First();

                if (a.Tipo == "String")
                {
                    Label label = new Label()
                    {
                        Font = new Font("Lexend Light", 11), //Lexend Light; 10,8pt
                    };
                    label.Text = contenido.ContenidoTexto;

                    //propiedades

                    label.Name = "C_" + a.Nombre;
                    label.Width = panel1.Width - 20;
                    label.AutoSize = false;
                    label.MaximumSize = new Size(panel1.Width - 80, 10000);

                    using (Graphics g = label.CreateGraphics())
                    {
                        SizeF size = g.MeasureString(label.Text, label.Font, label.MaximumSize.Width);
                        label.Height = (int)Math.Ceiling(size.Height);
                    }

                    return label;
                }
                else if (a.Tipo == "Int")
                {
                    int n = (int)contenido.ContenidoEntero;
                    Label label = new Label()
                    {
                        Font = new Font("Lexend Light", 11), //Lexend Light; 10,8pt
                    };
                    label.Text = n.ToString();

                    //propiedades

                    label.Name = "C_" + a.Nombre;
                    label.Width = panel1.Width - 20;
                    label.AutoSize = false;
                    label.MaximumSize = new Size(panel1.Width - 80, 10000);

                    using (Graphics g = label.CreateGraphics())
                    {
                        SizeF size = g.MeasureString(label.Text, label.Font, label.MaximumSize.Width);
                        label.Height = (int)Math.Ceiling(size.Height);
                    }

                    return label;
                }
                else if (a.Tipo == "Real")
                {
                    float n = (float)contenido.ContenidoReal;
                    Label label = new Label()
                    {
                        Font = new Font("Lexend Light", 11), //Lexend Light; 10,8pt
                    };
                    label.Text = n.ToString();

                    //propiedades

                    label.Name = "C_" + a.Nombre;
                    label.Width = panel1.Width - 20;
                    label.AutoSize = false;
                    label.MaximumSize = new Size(panel1.Width - 80, 10000);

                    using (Graphics g = label.CreateGraphics())
                    {
                        SizeF size = g.MeasureString(label.Text, label.Font, label.MaximumSize.Width);
                        label.Height = (int)Math.Ceiling(size.Height);
                    }

                    return label;
                }
                else if (a.Tipo == "Boolean")
                {
                     //propiedades

                    bool isChecked = contenido.ContenidoBoolean == true; // O usa la lógica necesaria para convertir el valor de tu base de datos a bool

                    CheckBox checkBox = new CheckBox()
                    {
                        Font = new Font("Lexend Light", 14), // Lexend Light; 10,8pt
                        Text = string.Empty, // Sin texto al lado del checkbox
                        Checked = isChecked, // Valor del checkbox
                        Enabled = false, // No editable
                        AutoSize = true,
                        Name = "C_" + a.Nombre,
                        Location = new Point(10, 10), // Cambia la posición según sea necesario
                        
                    };

                    return checkBox;
                }
                else
                {
                    //archivo binario
                    //!!!

                    byte[] x = contenido.ContenidoBinario;
                    if (x != null)
                    {
                        if (a.Tipo.Equals("Image"))
                        {
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Name = "C_" + a.Nombre;

                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                            using (MemoryStream ms = new MemoryStream(x))
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                                // Calculamos la nueva altura manteniendo la proporción
                                float aspectRatio = (float)image.Width / image.Height;
                                int newWidth = panel1.Width-75; // Ancho del panel
                                int newHeight = (int)(newWidth / aspectRatio); // Altura proporcional

                                // Redimensionamos el PictureBox según el cálculo
                                pictureBox.Size = new Size(newWidth, newHeight);

                                // Asignamos la imagen redimensionada al PictureBox
                                pictureBox.Image = image;
                            }
                            return pictureBox;
                        }
                        else if (a.Tipo.Equals("Video"))
                        {
                            webBrowser = new WebBrowser();
                            string tempVideoPath = Path.Combine(Path.GetTempPath(), idVideo + "tempVideo.mp4" );

                            File.WriteAllBytes(tempVideoPath, x);

                            string videoHtml = $@"
                        <html>
                        <body style='margin:0; padding:0; overflow:hidden;'>
                            <embed src='file:///{tempVideoPath.Replace("\\", "/")}' type='video/mp4'width='100%' height='100%' controls>
                                <source src='file:///{tempVideoPath.Replace("\\", "/")}' type='video/mp4'>
                                Your browser does not support the video tag.
                            </embed>
                        </body>
                        </html>";
                            float aspectRatio = (float)webBrowser.Width / webBrowser.Height;
                            int newWidth = panel1.Width-75; // Ancho del panel
                            int newHeight = (int)(newWidth / aspectRatio); // Altura proporcional
                            webBrowser.DocumentText = videoHtml;
                            webBrowser.Width = newWidth;
                            webBrowser.Height = newHeight;
                            webBrowser.ScrollBarsEnabled = false;
                            webBrowser.Name = "C_" + a.Nombre;


                            tmppaths.Add(tempVideoPath);
                            return webBrowser;
                        }
                        else if (a.Tipo.Equals("PDF"))
                        {
                            Panel gb = new Panel();
                            PictureBox pb = new PictureBox();
                            pb.Image = Properties.Resources.ICONdoc;
                            pb.Width = 50;
                            Label label = new Label()
                            {
                                Text = "Click to open",
                                Font = new Font("Lexend Light", 10), //Lexend Light; 10,8pt
                                AutoSize = true,
                                Name = "label"
                            };
                            label.Click += new EventHandler(abrirArchivo);
                            pb.Click += new EventHandler(abrirArchivo);


                            gb.Controls.Add(pb);
                            gb.Controls.Add(label);
                            gb.Name = "C_" + a.Nombre;
                            gb.Controls["label"].Location = new Point(50, 15);
                            gb.Width = 160;
                            gb.Cursor = Cursors.Hand;

                            gb.Click += new EventHandler(abrirArchivo);


                            return gb;
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
            return null;


        }

        private void cargarPanel()
        {
            grupo21DBEntities bd = new grupo21DBEntities();
            Label l = label1;
            panel1.Controls.Clear();
            panel1.Controls.Add(l);
            panel1.AutoScroll = true;


            //Cargamos atributos
            List<Atributo> list = (from a in bd.Atributo where a.Cuenta1.ID.Equals(main.Tienda.ID) select a).ToList();

            //llevar la cuenta
            
            Point point = new Point(10,100);

            foreach(Atributo a in list)
            {
                //Atributo at = (from x in bd.Atributo where x.Nombre.Equals(a.Atributo) select x).ToList().First();

                Label label = new Label()
                {
                    Font = new Font("Lexend SemiBold", 12, FontStyle.Bold), //"Lexend SemiBold; 10,8pt; style=Bold"
                    Text = a.Nombre,
                    Name = a.Nombre,
                    AutoSize = true
                };

                
                panel1.Controls.Add(label);
                panel1.Controls[label.Name].Location = new Point(point.X, point.Y);
               
                Control nuevo = cargarContenidoAtributo(a);
                
                if(nuevo != null)
                {
                    panel1.Controls.Add(nuevo);
                    panel1.Controls["C_" + a.Nombre].Location = new Point(point.X + 20, point.Y + 40);
                    point.Y += nuevo.Height + 60;
                }
                else
                {
                    point.Y += 60;
                }

                //calculamos cuando termina -> Nuevo Y
            }
            cargarRelaciones(point);
            Panel espacioBlanco = new Panel
            {
                Height = 30, // Altura del espacio en píxeles
                Dock = DockStyle.Bottom, // Posición al final del panel principal
                BackColor = Color.Transparent // Transparente para que parezca vacío
            };

            // Agregar al Panel principal
            panel1.Controls.Add(espacioBlanco);

        }

        private void cargarRelaciones(Point point)
        {
            grupo21DBEntities bd = new grupo21DBEntities();

            // Obtener el producto seleccionado en listBox_A
            Producto productoSeleccionadoA = producto;

            // Obtener las relaciones donde el producto seleccionado es origen
            var relacionesProducto = (from r in bd.Relaciones
                                      join pr in bd.Relaciones_Productos
                                      on r.ID equals pr.RelacionID
                                      where pr.ProductoOrigenID == productoSeleccionadoA.ID
                                      select r).Distinct().ToList();

            // Crear un DataGridView por cada relación
            foreach (var relacion in relacionesProducto)
            {
                // Crear una etiqueta para la relación
                Label relacionesLabel = new Label()
                {
                    Font = new Font("Lexend SemiBold", 12, FontStyle.Bold),
                    Text = relacion.Nombre,
                    Name = relacion.Nombre + "Label",
                    AutoSize = true
                };
                panel1.Controls.Add(relacionesLabel);
                relacionesLabel.Location = new Point(point.X, point.Y); // Ajustar la posición de la etiqueta "Relaciones"
                point.Y += relacionesLabel.Height + 20; // Ajustar el espacio después de la etiqueta

                // Crear DataGridView para esta relación
                DataGridView dataGrid = new DataGridView()
                {
                    Name = "DataGrid_" + relacion.Nombre,
                    Width = panel1.Width - 40, // Ajustar el ancho al panel
                    Height = 400, // Ajustar la altura del DataGrid
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false, // Evitar la adición manual de filas
                    ReadOnly = true, // Solo lectura para visualización
                    BackgroundColor = Color.White,
                    BorderStyle = BorderStyle.Fixed3D,
                    CellBorderStyle = DataGridViewCellBorderStyle.None,
                    AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells,
                    RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                    RowHeadersVisible = false,
                    ScrollBars = ScrollBars.None,
                    MultiSelect = false,
                    Font = new Font("Lexend", 11),
                    ColumnHeadersBorderStyle=DataGridViewHeaderBorderStyle.None,
                    DefaultCellStyle = new DataGridViewCellStyle() {

                        BackColor = SystemColors.Window, // Color de fondo
                        ForeColor = Color.Indigo, // Color del texto
                        SelectionBackColor = Color.BlueViolet, // Color de fondo al seleccionar
                        SelectionForeColor = Color.GhostWhite, // Color del texto al seleccionar
                        Font = new Font("Lexend", 10, FontStyle.Regular), // Fuente personalizada
                        WrapMode = DataGridViewTriState.True, // Ajuste de texto
                        Alignment = DataGridViewContentAlignment.MiddleCenter, // Alineación del contenido
                        Padding = new Padding(10, 5, 5, 10), // Espaciado interno
                    },
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                    ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = Color.FromArgb(255, 248, 238, 255), // Color de fondo ARGB
                        ForeColor = SystemColors.WindowText, // Color del texto predeterminado del sistema
                        SelectionBackColor = Color.FromArgb(255, 145, 24, 218), // Color de fondo al seleccionar (ARGB)
                        SelectionForeColor = SystemColors.HighlightText, // Color del texto al seleccionar
                        Font = new Font("Lexend", 10, FontStyle.Bold), // Fuente personalizada
                        WrapMode = DataGridViewTriState.False, // No ajustar el texto
                        Alignment = DataGridViewContentAlignment.MiddleCenter // Alineación del contenido
                    },
                    EnableHeadersVisualStyles = false,


                };
                dataGrid.DefaultCellStyle.SelectionForeColor = Color.Indigo;
                dataGrid.DefaultCellStyle.SelectionBackColor = Color.White;

                // Obtener los productos relacionados directamente con el producto seleccionado
                var productosRelacionados = (from pr in bd.Relaciones_Productos
                                             join p in bd.Producto on pr.ProductoDestinoID equals p.ID
                                             where pr.RelacionID == relacion.ID
                                                   && pr.ProductoOrigenID == productoSeleccionadoA.ID // Producto seleccionado como origen
                                                   && p.ID != productoSeleccionadoA.ID // Excluir el producto seleccionado
                                             select new
                                             {
                                                 p.Label,
                                                 p.SKU,
                                                 p.GTIN
                                             }).Distinct().ToList();

                // Configurar las columnas del DataGrid
                dataGrid.DataSource = productosRelacionados;

                // Limpiar la selección (si es necesario)
                dataGrid.ClearSelection();
                dataGrid.Enabled = false;

                
                // Agregar el DataGridView al panel
                panel1.Controls.Add(dataGrid);
                dataGrid.Location = new Point(point.X, point.Y);
                int alturaTotal = dataGrid.ColumnHeadersVisible ? dataGrid.ColumnHeadersHeight : 0;

                foreach (DataGridViewRow fila in dataGrid.Rows)
                {
                    alturaTotal += fila.Height;
                }
                dataGrid.Height = alturaTotal;
                point.Y += dataGrid.Height + 50; // Ajustar el espacio después de cada DataGridView
                
            }
        }

        private void V_ProductoIndividual_Load(object sender, EventArgs e)
        {
            cargarProducto();
            
        }

        public void cargarProducto()
        {
            cerrarVideo();
            grupo21DBEntities bd = new grupo21DBEntities();
            //ATRIBUTOS DE SISTEMA

            if (Producto.Thumbnail != null)
            {
                using (MemoryStream ms = new MemoryStream(Producto.Thumbnail))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                    // Muestra la imagen en un PictureBox o guárdala en disco
                    thumbnail.Image = image;
                }
            }

            if (Producto.Label != null)
            {
                Label.Text = Producto.Label;
            }

            fSKU.Text = Producto.SKU;
            fGTIN.Text = Producto.GTIN;
            fCreacion.Text = Producto.FechaCreacion.ToString();

            if (Producto.FechaModificacion != null)
            {
                fMod.Text = Producto.FechaModificacion.ToString();
            }

            List<CategoriaP> categorias = (from c in bd.CategoriaP
                                       where c.Producto.Any(p => p.ID == producto.ID) // Obtener categorías asociadas al producto
                                       select c).ToList();
            if (categorias.Count > 0)
            {
                listBox1.DataSource = categorias;
            } else
            {
                 listBox1.DataSource = new List<CategoriaP>();
            }
            


            //ATRIBUTOS DE USUARIO (PANEL)

            cargarPanel();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //volver a lista de productos
            cerrarVideo();
            main.cambiarVista(new V_Productos(Producto.Cuenta1, main)); 
        }

        public void cerrarVideo()
        {
            if (webBrowser != null)
            {
                webBrowser.Stop();
            }
           /*
            foreach (string p in tmppaths)
            {
                File.Exists(p);
                File.Delete(p);
            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //ABRIR CREAR/MODIFICAR
            main.Enabled = false;
            V_Producto_CrearModificar popup = new V_Producto_CrearModificar(false, Producto, main.Tienda, main, this, null);

            popup.StartPosition = FormStartPosition.Manual;
            popup.Location= new Point(main.Location.X + (main.Width -popup.Width)/2, main.Location.Y +( main.Height - popup.Height)/2);
            popup.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Borrar
            string cell = fSKU.Text;
            main.Enabled = false;
            VR_Eliminar popup = new VR_Eliminar(main, "Are you sure you want to delete this product " + cell + "?", this, cell);
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

            main.cambiarVista(new V_Productos(main.Tienda, main));
        }
    }
}
