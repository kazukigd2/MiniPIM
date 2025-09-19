using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPIM
{

    public partial class V_Resumen : UserControl
    {
        private Cuenta tienda;
        private V_Principal main;
        public V_Resumen(Cuenta tienda, V_Principal main)
        {
            InitializeComponent();
            this.tienda = tienda;
            this.main = main;
        }

        private void V_Resumen_Load(object sender, EventArgs e)
        {
            grupo21DBEntities bd = new grupo21DBEntities();
            Cuenta cuenta = (from c in bd.Cuenta
                        where tienda.ID.Equals(c.ID)
                        select c).FirstOrDefault();

            if (tienda.Logo != null)
            {
                using (MemoryStream ms = new MemoryStream(cuenta.Logo))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                    // Muestra la imagen en un PictureBox o guárdala en disco
                    thumbnail.Image = image;
                }
            }

            label_FechaCreacion.Text = cuenta.FechaCreacion.ToUniversalTime().ToString();
            label_NombreCuenta.Text = cuenta.Nombre;
            label_nAtributos.Text = cuenta.Atributo.Count.ToString() + " / 5";
            label_nCategorias.Text = cuenta.CategoriaP.Count.ToString() + " / 3";
            label_nProductos.Text = cuenta.Producto.Count.ToString() + " / 100";
            label_nRelaciones.Text = cuenta.Relaciones.Count.ToString() + " / 3";
            

            AttachCursorEvents(panel4);
        }

        //Funcion para cambiar el cursor al entrar al panel de exportar
        private void AttachCursorEvents(Control control)
        {
            control.MouseEnter += (s, e) => { panel4.Cursor = Cursors.Hand; };
            control.MouseLeave += (s, e) => { panel4.Cursor = Cursors.Default; };

            // Aplica el mismo comportamiento a todos los controles hijos.
            foreach (Control child in control.Controls)
            {
                AttachCursorEvents(child);
            }
        }

        private void guardarDatosJson()
        {
            try
            {
                // Crear el objeto con los datos de la cuenta
                var accountData = new
                {
                    AccountName = tienda.Nombre,
                    CreationDate = tienda.FechaCreacion.ToUniversalTime(),
                    ProductCount = tienda.Producto.Count,
                    CategoryCount = tienda.CategoriaP.Count,
                    AttributeCount = tienda.Atributo.Count,
                    RelationshipCount = tienda.Relaciones.Count
                };

                // Serializar los datos a JSON
                string json = System.Text.Json.JsonSerializer.Serialize(accountData, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true // Formato legible
                });

                // Mostrar el cuadro de diálogo para guardar el archivo JSON
                using (SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    DefaultExt = "json",
                    Title = "Guardar archivo JSON"
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, json);
                        MessageBox.Show("Datos exportados con éxito.", "Exportación JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Ocurrió un error al exportar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            guardarDatosJson();
        }
        private void panel4_Click(object sender, EventArgs e)
        {
            guardarDatosJson();
        }

        private void label_nCategorias_Click(object sender, EventArgs e)
        {

        }
    }
}
