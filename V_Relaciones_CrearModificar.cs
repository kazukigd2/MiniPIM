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
    public partial class V_Relaciones_CrearModificar : Form
    {
        grupo21DBEntities bd = new grupo21DBEntities();
        private Dictionary<Producto, List<Producto>> seleccionesPorProducto = new Dictionary<Producto, List<Producto>>();
        private V_Principal main;
        private V_Relaciones rel;
        private string celda;
        private bool modificar = false;
        private string nombreACambiar = null;

        public V_Relaciones_CrearModificar(V_Principal main, V_Relaciones rel)
        {
            InitializeComponent();
            this.main = main;
            this.rel = rel;
            label1.Text = "NEW RELATION";
        }

        public V_Relaciones_CrearModificar(V_Principal main, V_Relaciones rel, String nombre)
        {
            this.main = main;
            this.rel = rel;
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

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Enabled = true;
            main.Activate();
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
                MessageBox.Show("Please enter a name for the relation.");
                return;
            }
            

            if (modificar)
            {
                var query2 = (from p in bd.Relaciones where p.CuentaID.Equals(main.Tienda.ID) select p).ToArray();
                for (int i = 0; i < query2.Length; i++)
                {
                    if(nombreACambiar.Equals(nombre))
                    {

                    } else if (query2[i].Nombre.Equals(nombre))
                    {
                        MessageBox.Show("Duplicate name, please insert another name");
                        return;
                    }
                }

                var relacionModi = (from c in bd.Relaciones where c.Nombre.Equals(nombreACambiar) select c).FirstOrDefault();
                Relaciones relac = (Relaciones)relacionModi;
                relac.Nombre = nombre;

                try
                {
                    guardarRelaciones(nombreACambiar);
                    bd.SaveChanges();

                    rel.CargarDataGrid();
                    main.Enabled = true;
                    main.Activate();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                var query2 = (from p in bd.Relaciones where p.CuentaID.Equals(main.Tienda.ID) select p).ToArray();

                for (int i = 0; i < query2.Length; i++)
                {
                    if (query2[i].Nombre.Equals(nombre))
                    {
                        MessageBox.Show("Duplicate name, please insert another name");
                        return;

                    }

                }
                Relaciones nuevo = new Relaciones();

                nuevo.Nombre = nombre;
                nuevo.CuentaID = main.Tienda.ID;

                try
                {
                    bd.Relaciones.Add(nuevo);
                    bd.SaveChanges();

                    guardarRelaciones(nombre);
                    bd.SaveChanges();

                    rel.CargarDataGrid();
                    main.Enabled = true;
                    main.Activate();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void guardarRelaciones(string nombre)
        {
            // Recuperar la relación recién creada para agregar las relaciones de productos
            var relacion = (from r in bd.Relaciones
                            where r.Nombre.Equals(nombre) && r.CuentaID.Equals(main.Tienda.ID)
                            select r).FirstOrDefault();
            if (relacion == null)
            {
                MessageBox.Show("Relation not found.");
                return;
            }

            if(modificar)
            {
                var relacionesExistentes = bd.Relaciones_Productos.Where(rp => rp.RelacionID == relacion.ID).ToList();
                foreach (var relacionProducto in relacionesExistentes)
                {
                    bd.Relaciones_Productos.Remove(relacionProducto);
                }
            }


            // Iterar sobre el diccionario de selecciones y crear las relaciones de productos
            foreach (var productoA in seleccionesPorProducto)
            {
                var productoOrigen = productoA.Key;  // Producto de listBox_A (origen)

                foreach (var productoDestino in productoA.Value)  // Productos seleccionados en listBox_B (destinos)
                {
                    Relaciones_Productos relacionProducto = new Relaciones_Productos
                    {
                        ProductoOrigenID = productoOrigen.ID,
                        ProductoDestinoID = productoDestino.ID,
                        RelacionID = relacion.ID  // ID de la relación recién creada
                        
                    };
                    bd.Relaciones_Productos.Add(relacionProducto);
                }
            }
            
        }

        private void cargarRelacionesExistentes(int relacionID)
        {
               
                var todosLosProductos = bd.Producto.ToList();
                var relacionesProductos = from rp in bd.Relaciones_Productos
                                          where rp.RelacionID == relacionID
                                          select rp;

                // Limpiar el diccionario actual para evitar duplicados
                seleccionesPorProducto.Clear();
                // Iterar sobre las relaciones de productos existentes y agregarlas al diccionario
                foreach (var rp in relacionesProductos)
                {
                    // Obtener el producto de origen
                    Producto productoOrigen = todosLosProductos.FirstOrDefault(p => p.ID == rp.ProductoOrigenID);

                    // Obtener el producto de destino
                    Producto productoDestino = todosLosProductos.FirstOrDefault(p => p.ID == rp.ProductoDestinoID);

                    // Si el producto origen ya está en el diccionario, agregar el producto destino
                    if (productoOrigen != null)
                    {
                        if (!seleccionesPorProducto.ContainsKey(productoOrigen))
                        {
                            seleccionesPorProducto[productoOrigen] = new List<Producto>();
                        }

                        seleccionesPorProducto[productoOrigen].Add(productoDestino);
                    }
                }

                // Actualizar los ListBox con los productos de A y B
                actualizarListBoxes();
            
        }

        private void actualizarListBoxes()
        {
            // Actualizar listBox_A con los productos
            
            var productos = (from p in bd.Producto where p.Cuenta == main.Tienda.ID select p).ToArray();
            listBox_A.DataSource = productos;

            // Limpiar selección en listBox_A
            listBox_A.ClearSelected();

            listBox_B.DataSource = null;

            // Recorrer las selecciones y marcar los productos relacionados en listBox_B
            foreach (var productoA in seleccionesPorProducto)
            {
                Producto productoOrigen = productoA.Key;
                foreach (var productoDestino in productoA.Value)
                {
                    // Buscar el índice de productoDestino en listBox_B y marcarlo como seleccionado
                    int index = listBox_B.Items.IndexOf(productoDestino);
                    if (index >= 0)
                    {
                        listBox_B.SetSelected(index, true);
                    }
                }
            }
        }


        private void V_Relaciones_CrearModificar_Load(object sender, EventArgs e)
        {
            
            var productos = (from p in bd.Producto where p.Cuenta == main.Tienda.ID select p).ToArray();
            listBox_B.MouseClick += listBox_B_MouseClick;
            var relacionModi = (from c in bd.Relaciones where c.Nombre.Equals(nombreACambiar) select c).FirstOrDefault();
            if(modificar)
            {
                cargarRelacionesExistentes(relacionModi.ID);
            } else
            {
                cargarRelacionesExistentes(-1);
            }
            
        }

        private void listBox_B_MouseClick(object sender, MouseEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null && listBox.Items.Count > 0)  // Verificar si hay elementos en la ListBox
            {
                int index = listBox.IndexFromPoint(e.Location);  // Obtener el índice del ítem clickeado

                if (index != ListBox.NoMatches)  // Verificar que se haya hecho clic en un ítem válido
                {
                    var productoSeleccionado = (Producto)listBox.Items[index];
                    var productoSeleccionadoEnA = (Producto)listBox_A.SelectedItem;

                    // Verificar si el item ya está seleccionado
                    bool isItemSelected = listBox.SelectedIndices.Contains(index);

                    if (isItemSelected)
                    {
                        // Si ya está seleccionado, lo des-seleccionamos
                        listBox.SelectedIndices.Remove(index);

                        // Eliminar el producto de la lista de selecciones para este producto de listBox_A
                        if (seleccionesPorProducto.ContainsKey(productoSeleccionadoEnA))
                        {
                            seleccionesPorProducto[productoSeleccionadoEnA].Remove(productoSeleccionado);
                        }

                        if (seleccionesPorProducto.ContainsKey(productoSeleccionado))
                        {
                            seleccionesPorProducto[productoSeleccionado].Remove(productoSeleccionadoEnA);
                        }
                    }
                    else
                    {
                        // Si no está seleccionado, lo seleccionamos
                        listBox.SelectedIndices.Add(index);
                        // Agregar el producto a la lista de selecciones para este producto de listBox_A
                        if (!seleccionesPorProducto.ContainsKey(productoSeleccionadoEnA))
                        {
                            seleccionesPorProducto[productoSeleccionadoEnA] = new List<Producto>(); 
                        }

                        if (!seleccionesPorProducto.ContainsKey(productoSeleccionado))
                        {
                            seleccionesPorProducto[productoSeleccionado] = new List<Producto>();
                        }

                        if (!seleccionesPorProducto[productoSeleccionadoEnA].Contains(productoSeleccionado))
                        {
                            seleccionesPorProducto[productoSeleccionadoEnA].Add(productoSeleccionado);
                        }

                        if(!seleccionesPorProducto[productoSeleccionado].Contains(productoSeleccionadoEnA))
                        {
                            seleccionesPorProducto[productoSeleccionado].Add(productoSeleccionadoEnA);
                        }
                        
                    }
                }
            }
            else
            {
                // Si la ListBox está vacía, no hacer nada
            }

        }

        private void listBox_A_MouseClick(object sender, MouseEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null)
            {
                // Obtener el índice del ítem clickeado
                int index = listBox.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    var productoSeleccionado = (Producto)listBox.Items[index];

                    // Actualizar la selección de ListBox_A
                    listBox_A.SelectedItem = productoSeleccionado;

                    // Filtrar productos en ListBox_B, excluyendo el producto seleccionado
                    var productosFiltrados = (from p in (Producto[])listBox_A.DataSource
                                              where p != productoSeleccionado
                                              select p).ToArray();

                    // Cargar los productos filtrados en ListBox_B
                    listBox_B.DataSource = productosFiltrados;

                    // Limpiar la selección actual de ListBox_B
                    listBox_B.ClearSelected();

                    // Restaurar las selecciones previas de productos en ListBox_B
                    if (seleccionesPorProducto.ContainsKey(productoSeleccionado))
                    {
                        var productosSeleccionados = seleccionesPorProducto[productoSeleccionado];
                        foreach (var producto in productosSeleccionados)
                        {
                            int indexB = Array.IndexOf(productosFiltrados, producto);
                            if (indexB >= 0)
                            {
                                listBox_B.SetSelected(indexB, true);  // Restaurar la selección
                            }
                        }
                    }
                }
            }
        }
    }
}
