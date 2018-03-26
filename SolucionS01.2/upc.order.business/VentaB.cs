using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upc.orders.entities;

namespace upc.order.business
{
    public class VentaB : IVenta
    {
        public double asignarPrecio(Venta v)
        {
           switch(v.Producto.ToLower())
            {
                case "mouse": return 20;
                case "teclado": return 120;
                case "impresora": return 320;
                case "monitor": return 550;
                case "parlantes": return 50;
            }
            throw new NotImplementedException();
        }

        public double calcularDescuento(Venta v)
        {
            double subtotal = calcularSubtotal(v);
            if (subtotal <= 30)
            {
                return 0.05 * subtotal;
            }
            else if (subtotal > 300 && subtotal < 500)
            {
                return 0.10 * subtotal;
            }
            else if (subtotal > 500)
            {
                return 0.125 * subtotal;
            }
            else
                return 0;
            throw new NotImplementedException();
        }

        public double calcularNeto(Venta v)
        {
            return calcularSubtotal(v) - calcularDescuento(v);
            throw new NotImplementedException();
        }

        public double calcularSubtotal(Venta v)
        {
            return asignarPrecio(v) * v.Cantidad;
        }
    }
}
