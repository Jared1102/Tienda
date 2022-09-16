using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTienda
{
    public class Producto
    {
        private int _idProducto;
        private string _Nombre;
        private string _Descripcion;
        private decimal _Precio;

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
    }
}
