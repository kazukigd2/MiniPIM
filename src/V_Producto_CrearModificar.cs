using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Remoting.Contexts;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace MiniPIM
{
    public partial class V_Producto_CrearModificar : Form
    {
        grupo21DBEntities bd;
        List<AtributoProducto> atributosProducto;
        bool seleccionoCategoria = false;
        bool crear = false;
        Producto producto;
        Cuenta cuenta;
        V_Principal main;
        V_ProductoIndividual productoIndividual;
        V_Productos productosLista;
        BindingList<CategoriaP> categoriasAsociadas;
        BindingList<CategoriaP> categoriasNoAsociadas;

        public V_Producto_CrearModificar(bool crear, Producto producto, Cuenta cuenta, V_Principal main, V_ProductoIndividual productIndividual, V_Productos productos)
        {
            bd = new grupo21DBEntities();
            this.crear = crear;
            this.main = main;
            this.productoIndividual = productIndividual;
            this.productosLista = productos;
            InitializeComponent();
            
            if (producto == null)
            {
                this.producto=new Producto();
                Cuenta c = (from x in bd.Cuenta 
                            where x.ID.Equals(cuenta.ID) 
                            select x)
                            .ToList().FirstOrDefault();
                this.producto.Cuenta=c.ID;
                crear = true;
            }
            else
            {
                this.producto = (from p in bd.Producto 
                                 where p.ID.Equals(producto.ID) 
                                 select p)
                                 .Include(c => c.CategoriaP)
                                 .Include(a => a.AtributoProducto)
                                 .ToList().First();
            }
            this.cuenta = cuenta;
            bd.Entry(this.producto).State = crear ? EntityState.Added : EntityState.Modified;
        }

        public static bool ValidarGTIN14(string codigo)
        {    
            // Asegúrate de que tiene exactamente 14 dígitos
            if (string.IsNullOrEmpty(codigo) || codigo.Length != 14)
                return false;

            // Verificar que sea numérico
            if (!long.TryParse(codigo, out _))
                return false;

            // Validar checksum usando el algoritmo de GTIN
            int suma = 0;
            for (int i = 0; i < 13; i++) // Solo los primeros 13 dígitos
            {
                int digito = int.Parse(codigo[i].ToString());
                suma += (i % 2 == 0) ? digito * 3 : digito; // Alternar peso: 3 y 1
            }

            int checksumCalculado = (10 - (suma % 10)) % 10; // Calcular dígito de control
            int checksumReal = int.Parse(codigo[13].ToString()); // Dígito 14

            return checksumCalculado == checksumReal;
        }

        private void commit_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas()) return;

            ActualizarProducto();
            try
            {
                if (!crear)
                {
                    Random random = new Random();
                    int randomNumero = random.Next(1000, 9999);
                    producto.Label = tLabel.Text + randomNumero.ToString();
                    bd.SaveChanges();
                    producto.Label = tLabel.Text;
                }

                bd.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}");
                return;
            }
            CerrarInterfaz();

        }

        private void ActualizarProducto()
        {
            if (crear)
            {
                producto.FechaCreacion = DateTime.Now;
            }

            producto.FechaModificacion = DateTime.Now;
            producto.Label = tLabel.Text;
            producto.SKU = tSKU.Text;
            producto.GTIN = tGTIN.Text;

            // Bloqueo para asegurar que estas asignaciones se hagan secuenciales
            producto.CategoriaP = categoriasAsociadas;
            producto.AtributoProducto = atributosProducto;
        }


        private bool ValidarEntradas()
        {
            if (string.IsNullOrEmpty(tGTIN.Text) || !ValidarGTIN14(tGTIN.Text))
            {
                MessageBox.Show("GTIN is not valid");
                return false;
            }

            if (string.IsNullOrEmpty(tSKU.Text))
            {
                MessageBox.Show("SKU is blank");
                return false;
            }
           
           bool falloSKU = false;
           falloSKU = string.IsNullOrEmpty(tSKU.Text) ||
           bd.Producto.Any(prod => prod.ID != producto.ID &&
                                   prod.Cuenta1.Nombre.Equals(cuenta.Nombre) &&
                                   prod.SKU.Equals(tSKU.Text));
            if (falloSKU)
            {
                MessageBox.Show("SKU is repeated");
                return false;
            }


            return true;
        }

        private void CerrarInterfaz()
        {
            this.Close();
            if (productoIndividual == null)
            {
                productosLista.cargarProducto();
            }
            else
            {
                productoIndividual.Producto = producto;
                productoIndividual.idVideo++;
                productoIndividual.cargarProducto();

            }

            main.Enabled = true;
            main.Activate();
        }

        private void back_Click(object sender, EventArgs e)
        {
            //descartar
            this.Close();
            main.Enabled = true;
            main.Activate();

        }
        private void V_Producto_CrearModificar_Load(object sender, EventArgs e)
        {
            //crear = true -> en blanco, si no -> cargar datos actuales para modificar
            if (crear)
            {
                titulo.Text = "New product";
            }
            else
            {
                titulo.Text = "Modify";
            }

            //CATEGORIAS
            //Lista de todas las categorias del producto
            categoriasNoAsociadas = new BindingList<CategoriaP>((from c in bd.CategoriaP
                                     where cuenta.ID == c.Cuenta
                                     select c).ToList());
            categoriasAsociadas = new BindingList<CategoriaP>();

            //Si es una modificacion se carga en cada lista lo asociado y no asociado al producto
            if (!crear)
            {
                var categoriasAsociadasQuery = (from c in bd.CategoriaP
                                                where c.Producto.Any(p => p.ID == producto.ID) // Obtener categorías asociadas al producto
                                                select c).ToList();

                categoriasAsociadas = new BindingList<CategoriaP>(categoriasAsociadasQuery);
                for (int i = categoriasNoAsociadas.Count - 1; i >= 0; i--)
                {
                    CategoriaP cat = categoriasNoAsociadas[i];
                    if (categoriasAsociadas.Contains(cat))
                    {
                        categoriasNoAsociadas.RemoveAt(i);
                    }
                }
            }

            listBox_NoAsociado.DataSource = categoriasNoAsociadas;
            listBox_Asociado.DataSource = categoriasAsociadas;
            listBox_Asociado.ClearSelected();
            listBox_NoAsociado.ClearSelected();
            
           
            if (!crear)
            {
                if (producto.Label != null)
                {
                    tLabel.Text = producto.Label;
                }
                
                //no nulos
                tSKU.Text = producto.SKU;
                tGTIN.Text = producto.GTIN;
            }

            //ATRIBUTOSSSSSSSSSSSSSSSSSSSSS
            //List<Atributo> atributos = cuenta.Atributo.ToList();
            var atributosQuery = (from c in bd.Atributo
                                  where cuenta.ID == c.Cuenta
                                  select c);

            List<Atributo> atributos = atributosQuery.ToList();

            Point point = new Point(label1.Location.X,
                        listBox_Asociado.Location.Y + listBox_Asociado.Height + 10);
            
            atributosProducto = new List<AtributoProducto>();

            foreach (Atributo atr in atributos){
                //LABEL

                // Cargar valores existentes si no es un producto nuevo

                var valor2 = (from a in bd.AtributoProducto
                             where a.Producto.Equals(producto.ID) && a.Atributo.Equals(atr.ID)
                             select a).FirstOrDefault();
                AtributoProducto atributoProducto = valor2 ?? new AtributoProducto()
                {
                    Atributo = atr.ID,
                    Producto = producto?.ID ?? 0, // Producto ID (0 si es nuevo)
                };

                if (!crear)
                {
                    // Consulta el valor existente en la base de datos

                    if (valor2 != null)
                    {
                        // Asigna valores según el tipo de atributo
                        if (atr.Tipo.Equals("String"))
                        {
                            atributoProducto.ContenidoTexto = valor2.ContenidoTexto ?? ""; // Cadena vacía si es null
                        }
                        else if (atr.Tipo.Equals("Int"))
                        {
                            atributoProducto.ContenidoEntero = valor2.ContenidoEntero;
                        } else if (atr.Tipo.Equals("Real"))
                        {
                            atributoProducto.ContenidoReal = valor2.ContenidoReal;
                        }
                        else if (atr.Tipo.Equals("Boolean"))
                        {
                            atributoProducto.ContenidoBoolean = valor2.ContenidoBoolean ?? false;
                        }
                        else
                        {
                            atributoProducto.ContenidoBinario = valor2.ContenidoBinario;
                        }
                    }
                    else
                    {
                        // Si no existe, inicializa con valores predeterminados
                        if (atr.Tipo.Equals("String"))
                        {
                            atributoProducto.ContenidoTexto = ""; // Cadena vacía
                        }
                        else if (atr.Tipo.Equals("Int"))
                        {
                            atributoProducto.ContenidoEntero = 0;
                        } else if(atr.Tipo.Equals("Real"))
                        {
                            atributoProducto.ContenidoReal = 0;
                        }
                        else if (atr.Tipo.Equals("Boolean"))
                        {
                            atributoProducto.ContenidoBoolean = false;
                        }
                        else
                        {
                            atributoProducto.ContenidoBinario = null;
                        }
                    }
                }
                else
                {
                    // Producto nuevo, inicializar con valores predeterminados
                    if (atr.Tipo.Equals("String"))
                    {
                        atributoProducto.ContenidoTexto = ""; // Cadena vacía
                    }
                    else if (atr.Tipo.Equals("Int"))
                    {
                        atributoProducto.ContenidoEntero = 0;
                    } else if(atr.Tipo.Equals("Real"))
                    {
                        atributoProducto.ContenidoReal = 0;
                    }
                    else if (atr.Tipo.Equals("Boolean"))
                    {
                        atributoProducto.ContenidoBoolean = false;
                    }
                    else
                    {
                        atributoProducto.ContenidoBinario = null;
                    }
                }

                // Añade el atributo a la lista
                atributosProducto.Add(atributoProducto);


                Label label = new Label()
                {
                    Font = new Font("Lexend SemiBold", 11, FontStyle.Bold), //Lexend SemiBold; 10,8pt; style=Bold
                    Text = atr.Nombre.ToString()+": ",
                    Location = new Point(point.X, point.Y),
                    AutoSize = false, // Desactivamos el ajuste automático
                    Size = new Size(100, 25), // Establecemos el tamaño fijo del Label
                    TextAlign = ContentAlignment.MiddleLeft, // Ajustamos la alineación del texto
                    AutoEllipsis = true // Agregamos puntos suspensivos si el texto es demasiado largo
                };

                panel1.Controls.Add(label);

                //QUE TIPO?

                if(atr.Tipo.Equals("String") || atr.Tipo.Equals("Int") || atr.Tipo.Equals("Real"))
                {
                    //TEXTBOX
                    TextBox txt = new TextBox()
                    {
                        Width=panel1.Width-(9*(13+atr.Nombre.Length)),
                        Font = new Font("Lexend Light", 11),//Lexend Light; 10,8pt
                        Location =new Point(point.X+100, point.Y+3),
                        Name=atr.Nombre,
                        MaxLength=250
                    };

                    if (!crear)
                    {
                        var valor = (from a in bd.AtributoProducto where a.Producto.Equals(producto.ID) && a.Atributo.Equals(atr.ID) select a).ToList();
                        if (valor.Count > 0)
                        {
                            if (valor[0].ContenidoTexto != null)
                            {
                                txt.Text = valor[0].ContenidoTexto;
                            }
                            else if (valor[0].ContenidoEntero != null)
                            {
                                txt.Text = valor[0].ContenidoEntero.ToString();
                            } else if (valor[0].ContenidoReal != null)
                            {
                                txt.Text = valor[0].ContenidoReal.ToString();
                            }
       
                        }
                    }
                    // Asigna el objeto AtributoProducto al Tag del TextBox
                    AtributoProducto atributoPro = atributosProducto.First(a => a.Atributo == atr.ID);
                    txt.Tag = atributoPro;

                    // Suscribe al evento TextChanged
                    txt.TextChanged += (sender1, e1) =>
                    {
                        TextBox textBox = sender1 as TextBox;
                        if (textBox != null && textBox.Tag is AtributoProducto)
                        {
                            AtributoProducto atributo = (AtributoProducto)textBox.Tag;

                            // Actualiza el valor en la lista según el tipo
                            if (atr.Tipo.Equals("String"))
                            {
                                atributo.ContenidoTexto = textBox.Text;
                            }
                            else if (atr.Tipo.Equals("Int") )
                            {
                                if (int.TryParse(textBox.Text, out int result))
                                {
                                    atributo.ContenidoEntero = result;
                                }
                                else
                                {
                                    if (textBox.Text.Equals(""))
                                    {
                                        atributo.ContenidoEntero = 0;
                                    }
                                    else
                                    {
                                        MessageBox.Show("The value is not a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        atributo.ContenidoEntero = 0; // Por ejemplo, un valor especial para indicar error
                                        textBox.Text = atributo.ContenidoEntero.ToString();
                                    }
                                }
   
                            } else if(atr.Tipo.Equals("Real"))
                            {
                                if (float.TryParse(textBox.Text, out float result2))
                                {
                                    atributo.ContenidoReal = result2;
                                }
                                else
                                {
                                    if(textBox.Text.Equals(""))
                                    {
                                        atributo.ContenidoReal = 0;
                                    } else
                                    {
                                        MessageBox.Show("The value is not a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        atributo.ContenidoReal = 0; // Por ejemplo, un valor especial para indicar error
                                        textBox.Text = atributo.ContenidoReal.ToString();
                                    }
                                }
                            }
                            else
                            {
                                atributo.ContenidoBinario = null; // Si el valor no es válido, lo pone en null
                            }
                        }
                    };

                        panel1.Controls.Add((txt));

                        point.Y += 35;
                }else if (atr.Tipo.Equals("Boolean"))
                {
                    // Crear un CheckBox
                    CheckBox chk = new CheckBox()
                    {
                        Font = new Font("Lexend Light", 11), // Lexend Light; 10,8pt
                        Location = new Point(point.X + 125, point.Y + 3),
                        Name = atr.Nombre,
                        Text = "Yes / No", // Etiqueta opcional para el CheckBox
                        AutoSize = true
                    };

                    if (!crear)
                    {
                        var valor = (from a in bd.AtributoProducto
                                     where a.Producto.Equals(producto.ID) && a.Atributo.Equals(atr.ID)
                                     select a).ToList();
                        if (valor.Count > 0)
                        {
                            if(valor[0].ContenidoBoolean == null || valor[0].ContenidoBoolean == false)
                            {
                                chk.Checked = false;
                            }
                            else
                            {
                                chk.Checked = true;
                            }
                            
                        } else
                        {
                            chk.Checked = false; 
                        }
                    }

                    // Asigna el objeto AtributoProducto al Tag del CheckBox
                    AtributoProducto atributoPro = atributosProducto.First(a => a.Atributo == atr.ID);
                    chk.Tag = atributoPro;

                    // Suscribe al evento CheckedChanged
                    chk.CheckedChanged += (sender1, e1) =>
                    {
                        CheckBox checkBox = sender1 as CheckBox;
                        if (checkBox != null && checkBox.Tag is AtributoProducto)
                        {
                            AtributoProducto atributo = (AtributoProducto)checkBox.Tag;

                            // Actualiza el valor en la lista
                            atributo.ContenidoBoolean = checkBox.Checked ? true : false; // Convierte a sbyte
                        }
                    };

                    // Añadir el CheckBox al panel
                    panel1.Controls.Add(chk);

                    point.Y += 35; // Incrementar la posición para el próximo control
                }
                else
                {
                    //binarios
                    //creamos panel con label e imagen dentro

                    //GUARDAR ARCHIVO -> NAME

                    Panel panel = new Panel()
                    {
                        Size = new Size(240, 34),
                        Location = new Point(point.X + 125, point.Y ),
                        Cursor = Cursors.Hand,
                        Name=atr.Nombre
                    };

                    PictureBox pictureBox = new PictureBox()
                    {
                        Image = Properties.Resources.ICONdoc,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size= new Size(30,30),
                        Location= new Point(3, 1),
                        Name = atr.Nombre
                    };
                    //pictureBox.Click !!!!!!!!!!!!!!!!!!!!!!!

                    Label label1 = new Label()
                    {
                        Font = new Font("Lexend Light", 11),//Lexend Light; 10,8pt
                        Text = "Upload new " + atr.Nombre.ToString().ToLower(),
                        Location= new Point(39, 1),
                        AutoSize = false, // Desactivamos el ajuste automático
                        Size = new Size(150, 25), // Establecemos el tamaño fijo del Label
                        TextAlign = ContentAlignment.MiddleLeft, // Ajustamos la alineación del texto
                        AutoEllipsis = true // Agregamos puntos suspensivos si el texto es demasiado largo
                    };

                    AtributoProducto atributoProd = atributosProducto.First(a => a.Atributo == atr.ID);
                    panel.Tag = atributoProd;

                    // Determinar qué acción se asocia con los clics
                    EventHandler clickHandler;

                    if (atr.Tipo.Equals("Image"))
                        clickHandler = (sender1, e1) => subirImagen(sender, e, atributoProd, false, label1);
                    else if (atr.Tipo.Equals("Video"))
                        clickHandler = (sender1, e1) => subirVideo(sender, e, atributoProd, label1);
                    else if (atr.Tipo.Equals("PDF"))
                        clickHandler = (sender1, e1) => subirPDF(sender, e, atributoProd, label1);
                    else
                        clickHandler = (sender1, e1) => subirOtros(sender, e, atributoProd, label1);

                    // Asignar el evento de clic a los controles
                    label1.Click += clickHandler;
                    pictureBox.Click += clickHandler;
                    panel.Click += clickHandler;


                    panel.Controls.Add(label1);
                    panel.Controls.Add(pictureBox);

                    panel1.Controls.Add(panel);

                    point.Y += 40;
                }
            }
        }


        private void subirImagen(object sender, EventArgs e, AtributoProducto atributo, bool thmumbnail, Label l)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Verificar el tamaño del archivo que no supere los 5 megas
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5 MB
                    {
                        MessageBox.Show("The file is too large. The maximum allowed size is 5 MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                    if (thmumbnail)
                    {
                        byte[] imageBytes;
                        using (Image img = Image.FromFile(filePath))
                        {
                            // Crear una nueva imagen de 128x128 píxeles
                            Image resizedImage = ResizeImage(img, 128, 128);

                            // Guardar la imagen redimensionada en un byte array
                            using (MemoryStream ms = new MemoryStream())
                            {
                                resizedImage.Save(ms, img.RawFormat);
                                imageBytes = ms.ToArray();
                            }
                        }
                        producto.Thumbnail = imageBytes;
                    } else
                    {
                        atributo.ContenidoBinario = File.ReadAllBytes(filePath);
                    }
                    l.Text = "File: " + Path.GetFileName(filePath);
                    MessageBox.Show($"Image uploaded: {Path.GetFileName(filePath)}");
                }
            }
        }


        private Image ResizeImage(Image img, int width, int height)
        {
            // Redimensionar la imagen forzando las dimensiones exactas
            Bitmap resizedBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.DrawImage(img, 0, 0, width, height); // Fuerza el tamaño
            }

            return resizedBitmap;
        }


        private void subirThmumbnail(object sender, EventArgs e)
        {
            subirImagen(sender, e, null, true, lThumbnail);
        }

        private void subirVideo(object sender, EventArgs e, AtributoProducto atributo, Label l)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files (*.mp4;*.avi;*.mov)|*.mp4;*.avi;*.mov";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Verificar el tamaño del archivo que no supere los 5 megas
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5 MB
                    {
                        MessageBox.Show("The file is too large. The maximum allowed size is 5 MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    atributo.ContenidoBinario = File.ReadAllBytes(filePath);
                    MessageBox.Show($"Video uploaded: {Path.GetFileName(filePath)}");
                    l.Text = "File: " + Path.GetFileName(filePath);
                }
            }
        }

        private void subirPDF(object sender, EventArgs e, AtributoProducto atributo, Label l)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Verificar el tamaño del archivo que no supere los 5 megas
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5 MB
                    {
                        MessageBox.Show("The file is too large. The maximum allowed size is 5 MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    atributo.ContenidoBinario = File.ReadAllBytes(filePath);
                    MessageBox.Show($"PDF uploaded: {Path.GetFileName(filePath)}");
                    l.Text = "File: " + Path.GetFileName(filePath);
                }
            }
        }

        private void subirOtros(object sender, EventArgs e, AtributoProducto atributo , Label l)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Verificar el tamaño del archivo que no supere los 5 megas
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 5 * 1024 * 1024) // 5 MB
                    {
                        MessageBox.Show("The file is too large. The maximum allowed size is 5 MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    atributo.ContenidoBinario = File.ReadAllBytes(filePath);
                    MessageBox.Show($"File uploaded: {Path.GetFileName(filePath)}");
                    l.Text = "File: " + Path.GetFileName(filePath);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //añadir categoria
            CategoriaP sel = (CategoriaP)listBox_NoAsociado.SelectedItem;
            if (sel != null)
            {
                categoriasAsociadas.Add(sel);
                categoriasNoAsociadas.Remove(sel);
            }
            listBox_NoAsociado.ClearSelected();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //eliminar categoria
            CategoriaP sel = (CategoriaP)listBox_Asociado.SelectedItem;
            if (sel != null)
            {
                categoriasNoAsociadas.Add(sel);
                categoriasAsociadas.Remove(sel);
            }
            listBox_Asociado.ClearSelected();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si el cambio de selección es el resultado de un evento, no de una acción manual
            if (seleccionoCategoria) return;
            seleccionoCategoria = true;
            listBox_Asociado.ClearSelected();
            listBox_Asociado.SelectedIndex = -1;
            seleccionoCategoria = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si el cambio de selección es el resultado de un evento, no de una acción manual
            if (seleccionoCategoria) return;
            seleccionoCategoria = true;
            listBox_NoAsociado.ClearSelected();
            listBox_NoAsociado.SelectedIndex = -1;
            seleccionoCategoria = false;
        }
    }
}

