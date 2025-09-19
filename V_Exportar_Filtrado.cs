using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPIM
{
    public partial class V_Exportar_Filtrado : Form
    {
        private V_Principal main;
        private List<Producto> listaMostrar;
        private Cuenta tienda;
        private int contadorExportar;

        public V_Exportar_Filtrado(V_Principal main, List<Producto> listaMostrar,Cuenta tienda)
        {
            InitializeComponent();
            this.main = main;
            this.listaMostrar = listaMostrar;
            this.tienda = tienda;
            contadorExportar = 0;

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Enabled = true;
            main.Activate();
        }

        private void V_Exportar_Filtrado_Load(object sender, EventArgs e)
        {
            comboBoxSKU.SelectedIndex = 0;
            comboBoxLabel.SelectedIndex = 0;
            ComboBoxAccount.SelectedIndex = 0;
            comboBoxGTIN.SelectedIndex = 0;
            //creamos listas seleccionables
            crearListaSeleccionables();
            cargarProducto();
            //Rellena la columna de offerprime todo a False
            rellenarColumnas("Boolean", comboBoxOfferPrime);
            buscarFloatColum();
        }

        private void buscarFloatColum()
        {
            for(int i = 0;  i<comboBoxPrecio.Items.Count; i++)
            {
                if (comboBoxPrecio.Items[i] is Atributo)
                {
                    if(((Atributo)comboBoxPrecio.Items[i]).Tipo == "Real")
                    {
                        comboBoxPrecio.SelectedIndex = i;
                        return;
                    }
                    
                }
            }
        }

        public void cargarProducto()
        {
            //Conexion a la base de datos
            grupo21DBEntities bd = new grupo21DBEntities();

            //Limpiamos el grid que hubiera
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            //Creamos las columnas Label y SKU
            dataGridView1.Columns.Add("SKU", "SKU");
            dataGridView1.Columns.Add("Title", "Title");
            dataGridView1.Columns.Add("Fulfilled By", "Fulfilled By");
            dataGridView1.Columns.Add("Amazon SKU", "Amazon SKU");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Offer Prime", "Offer Prime");
            dataGridView1.Columns.Add("Optional1", "Optional1");
            dataGridView1.Columns.Add("Optional2", "Optional2");

            //cargamos lista de productos de la tienda
            List<Producto> list = listaMostrar;

            //Creamos la fila con todos los datos del producto
            foreach (Producto p in list)
            {
                //Lista de prooductos que va en cada fila
                List<Object> parametros = new List<Object>();


                
                //Añadimos en la posicion 1 del array parametros el SKU
                parametros.Add(p.SKU);
                //Añadimos en la posicion 2 del array parametros el label
                parametros.Add(p.Label);
                //Añadimos en la posicion 3 del array parametros el nombre
                parametros.Add(p.Cuenta1.Nombre);
                //Añadimos en la posicion 4 del array parametros el GTIN
                parametros.Add(p.GTIN);



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

        private void crearListaSeleccionables()
        {
            grupo21DBEntities bd = new grupo21DBEntities();
            Atributo atributoBoolTrue = new Atributo();
            atributoBoolTrue.Nombre = "AllTrue";
            atributoBoolTrue.Tipo = "Boolean";

            Atributo atributoBoolFalse = new Atributo();
            atributoBoolFalse.Nombre = "AllFalse";
            atributoBoolFalse.Tipo = "Boolean";

            List<Atributo> lista = new List<Atributo>();
            lista.Add(atributoBoolFalse);
            lista.Add(atributoBoolTrue);


            var queryPrecio = (from x in bd.Atributo
                              where x.Cuenta==tienda.ID && x.Tipo.Equals("Real")
                              select x).ToList();


            var queryOfferPrime = (from x in bd.Atributo
                                  where x.Cuenta == tienda.ID && x.Tipo.Equals("Boolean")
                                  select x).ToList();

            var queryOpcional1 = (from x in bd.Atributo
                                 where x.Cuenta == tienda.ID && 
                                 (x.Tipo.Equals("String") || x.Tipo.Equals("Boolean")
                                 || x.Tipo.Equals("Int") || x.Tipo.Equals("Real") )
                                  select x).ToList();

            var queryOpcional2 = (from x in bd.Atributo
                                 where x.Cuenta == tienda.ID &&
                                 (x.Tipo.Equals("String") || x.Tipo.Equals("Boolean")
                                 || x.Tipo.Equals("Int") || x.Tipo.Equals("Real"))
                                  select x).ToList();
            
            foreach( Atributo a in queryOfferPrime)
            {
                lista.Add(a);
            }


            comboBoxPrecio.DataSource = queryPrecio;
            comboBoxOfferPrime.DataSource = lista.ToArray();
            comboBoxOtros1.DataSource= queryOpcional1;
            comboBoxOtros2.DataSource = queryOpcional2;
            comboBoxPrecio.SelectedIndex=-1;
            comboBoxOtros1.SelectedIndex = -1;
            comboBoxOtros2.SelectedIndex = -1;
            comboBoxOfferPrime.SelectedIndex = 0;

        }

        private void GenerarCSV(string rutaArchivo)
        {
            StringBuilder sb = new StringBuilder();

            // Escribir encabezados, incluyendo "Updated SKU" y "Description" en las posiciones correctas
            var encabezados = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                     .Select(column => column.HeaderText).ToList();
            // Insertar "Updated SKU" en la columna 1 y "Description" en la columna 3
            encabezados.Insert(1, "Updated SKU");    // Columna 1
            encabezados.Insert(3, "Description");    // Columna 3

            sb.AppendLine(string.Join(",", encabezados));

            // Escribir filas, agregando valores vacíos en las posiciones 1 (Updated SKU) y 3 (Description)
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                bool noExportar = false;
                for (int i = 0; i < 6; i++) // Recorremos las primeras 6 columnas
                {
                    if (fila.Cells[i].Value == null || string.IsNullOrWhiteSpace(fila.Cells[i].Value.ToString()))
                    {
                        noExportar = true;
                    } 
                }
                
                if(noExportar)
                {

                }
                else
                {
                    var celdas = fila.Cells.Cast<DataGridViewCell>()
                       .Select(cell => cell.Value != null
                                       ? FormatearValor(cell.Value.ToString())
                                       : ""); // Formatear los valores antes de escribirlos

                    // Insertar columnas vacías en las posiciones 1 (Updated SKU) y 3 (Description)
                    var celdasConVacios = celdas.ToList();
                    celdasConVacios.Insert(1, "");  // Columna 1 vacía para "Updated SKU"
                    celdasConVacios.Insert(3, "");  // Columna 3 vacía para "Description"

                    sb.AppendLine(string.Join(",", celdasConVacios));
                    contadorExportar++;
                }

                // Guardar el archivo

                File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
            }
        }

        private string FormatearValor(string valor)
        {
            // Intentamos convertir el valor a un número decimal, si es un número lo formateamos con el punto como separador decimal
            if (decimal.TryParse(valor, out decimal resultado))
            {
                return resultado.ToString("0.##", CultureInfo.InvariantCulture); // Asegura que se utilice el punto como separador decimal
            }
            else
            {
                // Si no es un número, lo dejamos tal cual
                return valor.Replace(",", ";"); // Reemplaza comas en textos, si hay
            }
        }

        private void rellenarColumnas(string tipo, ComboBox combobox) {
            if (combobox.SelectedIndex != -1)
            {
                // Obtenemos el atributo seleccionado del ComboBox
                Atributo atributoSeleccionado = (Atributo)combobox.SelectedItem;

                // Array para los valores de la columna
                object[] valoresColumna = new object[listaMostrar.Count];

                // Recorremos la lista de productos
                for (int i = 0; i < listaMostrar.Count; i++)
                {
                    Producto producto = listaMostrar[i];

                    // Buscamos el atributo del producto
                    var atributoProducto = producto.AtributoProducto
                                                   .FirstOrDefault(ap => ap.Atributo == atributoSeleccionado.ID);

                    // Si existe, añadimos el contenido; si no, añadimos null
                    switch (tipo)
                    {
                        case "String":
                            valoresColumna[i] = atributoProducto != null ? atributoProducto.ContenidoTexto : null;
                            break;

                        case "Real":
                            valoresColumna[i] = atributoProducto != null ? atributoProducto.ContenidoReal : null;
                            break;

                        case "Int":
                            valoresColumna[i] = atributoProducto != null ? atributoProducto.ContenidoEntero : null;
                            break;

                        case "Boolean":
                            if(combobox.Tag.Equals("Offer Prime"))
                            {
                                if( ((Atributo)combobox.SelectedItem).Nombre.Equals("AllTrue") )
                                {
                                    valoresColumna[i] = "TRUE";
                                } else if (((Atributo)combobox.SelectedItem).Nombre.Equals("AllFalse"))
                                {
                                    valoresColumna[i] = "FALSE";
                                } else
                                {
                                    valoresColumna[i] = atributoProducto != null ? (atributoProducto.ContenidoBoolean == false ? "FALSE" : "TRUE") : null;
                                }
                            } else
                            {
                                valoresColumna[i] = atributoProducto != null ? (atributoProducto.ContenidoBoolean == false ? "FALSE" : "TRUE") : null;
                            }
                            break;
                        default:
                            break;
                    }
                    
                }

                // Actualizamos la columna correspondiente en el DataGridView
                string nombreColumna = (string)combobox.Tag;

                if (dataGridView1.Columns.Contains(nombreColumna))
                {
                    for (int i = 0; i < valoresColumna.Length; i++)
                    {
                        dataGridView1.Rows[i].Cells[nombreColumna].Value = valoresColumna[i];
                    }
                }
            }
        }

        private void comboBoxPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPrecio.SelectedIndex >= 0)
            {
                Atributo atrib = (Atributo)comboBoxPrecio.SelectedItem;
                if (atrib != null)
                {
                    rellenarColumnas(atrib.Tipo, comboBoxPrecio);
                }
                
            }
        }

        private void comboBoxOfferPrime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOfferPrime.SelectedIndex >= 0)
            {
                Atributo atrib = (Atributo)comboBoxOfferPrime.SelectedItem;
                if (atrib != null)
                {
                    rellenarColumnas(atrib.Tipo, comboBoxOfferPrime);
                }
                    
            }
        }

        private void comboBoxOtros1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOtros1.SelectedIndex >= 0) {
                Atributo atrib = (Atributo)comboBoxOtros1.SelectedItem;
                if (atrib != null)
                {
                    rellenarColumnas(atrib.Tipo, comboBoxOtros1);
                } 
            } 
        }

        private void comboBoxOtros2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOtros2.SelectedIndex >= 0)
            {
                Atributo atrib = (Atributo)comboBoxOtros2.SelectedItem;
                if (atrib != null)
                {
                    rellenarColumnas(atrib.Tipo, comboBoxOtros2);
                }
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            contadorExportar = 0;
            int totalProductos = listaMostrar.Count();
            // Comprobar si hay datos null en las primeras 6 columnas

            if(comboBoxPrecio.SelectedIndex < 0)
            {
                MessageBox.Show("The first 6 columns are mandatory; please select one of the available options.");
                return;
            }

            // Seleccionar directorio para guardar el archivo CSV
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Save CSV file",
                FileName = "ExportedData.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaArchivo = saveFileDialog.FileName;
                    GenerarCSV(rutaArchivo);
                    MessageBox.Show("CSV file generated successfully. Number of products that have been exported succesfully: " + contadorExportar.ToString() + "/" + totalProductos.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    main.Enabled = true;
                    main.Activate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
