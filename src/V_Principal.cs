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
    public partial class V_Principal : Form
    {
        grupo21DBEntities bd = new grupo21DBEntities();
        private Label actual;
        private Cuenta tienda;

        public Cuenta Tienda { get => tienda; set => tienda = value; }

        private void seleccionada(Label label)
        {
            if(actual == label) return;
            label.ForeColor = Color.FromArgb(162, 100, 255);
            if (actual != null)
            {
                actual.ForeColor = Color.FromArgb(145, 24, 218);
            }
            actual = label;
        }

        public V_Principal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Tienda = (from c in bd.Cuenta select c).ToList().First();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            MenuPrin();
        }

        private void MenuPrin()
        {
            listBox1.Visible = false;
            seleccionada(Dashboard);
            cambiarVista(new V_Resumen(Tienda, this));
        }

        private void Products_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            seleccionada(Products);
            cambiarVista(new V_Productos(Tienda, this));
        }

        private void Assets_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            seleccionada(Assets);
            cambiarVista(new V_Exportar(Tienda, this));
        }

        private void Categories_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            seleccionada(Categories);   
            cambiarVista(new V_Categorias(Tienda, this));
        }

        private void Atributes_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            seleccionada(Atributes);
            cambiarVista(new V_Atributos(Tienda, this));
        }

        private void Relations_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            seleccionada(Relations);
            cambiarVista(new V_Relaciones(Tienda, this));

        }

        private void Account_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false) {
                listBox1.Visible = true;
            } 
            else
            {
                listBox1.Visible = false;
            }      
        }

        private void V_Principal_Load(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            listBox1.DataSource = bd.Cuenta.ToList();
            AjustarListBox();
            panel1.Controls.Clear();
            MenuPrin();

            SubscribeMouseDownEvents(this);
            this.MouseDown += Control_MouseDown;
        }

        private void SubscribeMouseDownEvents(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.MouseDown += Control_MouseDown;

                // Recursivamente manejar controles hijos (por ejemplo, paneles)
                if (control.HasChildren)
                {
                    SubscribeMouseDownEvents(control);
                }
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificar si el clic está fuera del ListBox
            if (listBox1.Visible && !listBox1.Bounds.Contains(listBox1.PointToClient(Cursor.Position)))
            {
                listBox1.Visible = false;
            }
        }

        public void cambiarVista(UserControl nuevoControl)
        {
            if (panel1.Controls.Count > 0)
            {
                var controlActual = panel1.Controls[0];

                // Llama a Dispose para liberar recursos del control actual
                if (controlActual is V_ProductoIndividual)
                {  
                    ((V_ProductoIndividual)controlActual).cerrarVideo();
                }
                controlActual.Dispose();
                //panel1.Controls.RemoveAt(0);
            }
            // Agrega el nuevo UserControl al panel
            nuevoControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(nuevoControl);
            nuevoControl.BringToFront();  // Asegura que el nuevo control esté al frente
            SubscribeMouseDownEvents(nuevoControl);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tienda = (Cuenta)listBox1.SelectedItem;
            MenuPrin();
        }


        private void AjustarListBox()
        {
            int alturaItem = listBox1.ItemHeight; 
            int itemsTotales = listBox1.Items.Count + 1; 

            int altura = alturaItem * itemsTotales;

            listBox1.Height = altura;
        }

    }
    
}
