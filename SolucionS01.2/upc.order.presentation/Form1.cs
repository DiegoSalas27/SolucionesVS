using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using upc.orders.entities;
using upc.order.business;


namespace upc.order.presentation
{
    public partial class Form1 : Form
    {
        IVenta objVentaBiseness = new VentaB();
        Venta objVenta = new Venta();
        string[] productos = { "Mouse", "Teclado", "Impresora", "Monitor", "Parlantes" };
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            objVenta.Producto = cmbProducto.Text;
            objVenta.Cantidad = Convert.ToInt16(txtCantidad.Text);
            lblPrecio.Text = objVentaBiseness.calcularNeto(objVenta).ToString();
            listProductos();
        }

        //methods

        void llenarProductos()
        {
            foreach(string p in productos)
            {
                cmbProducto.Items.Add(p);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarProductos();
        }
        private void listProductos()
        {
           
            ListViewItem item = new ListViewItem(new[] { cmbProducto.SelectedItem.ToString(), objVenta.Cantidad.ToString(),
                objVentaBiseness.asignarPrecio(objVenta).ToString(), objVentaBiseness.calcularSubtotal(objVenta).ToString(),
                objVentaBiseness.calcularDescuento(objVenta).ToString(), objVentaBiseness.calcularNeto(objVenta).ToString() });
            lstVentas.Items.Add(item);
            //Visualizar datos para el listViews
        }
    }
}
