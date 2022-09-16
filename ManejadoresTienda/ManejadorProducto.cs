using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using EntidadesTienda;
using Crud;
using System.Drawing;

namespace ManejadoresTienda
{
    public class ManejadorProducto
    {
        private AccesoProductos _accesoProductos = new AccesoProductos();
        private Grafico _grafico = new Grafico();
        public void obtenerProductos(DataGridView tablaProductos)
        {
            tablaProductos.Columns.Clear();
            tablaProductos.DataSource = _accesoProductos.obtenerProductos();

            tablaProductos.Columns["IdProducto"].Visible = false;

            tablaProductos.Columns["Descripcion"].HeaderText = "Descripción";

            tablaProductos.Columns.Insert(4, _grafico.Boton("Modificar", Color.Blue));
            tablaProductos.Columns.Insert(5, _grafico.Boton("Eliminar", Color.Red));
        }

        public void agregarProducto(Producto producto)
        {
            _accesoProductos.agregarProducto(producto);
            _grafico.Mensaje(string.Format("Se agrego {0}", producto.Nombre), "Producto agregado", MessageBoxIcon.Information);
        }
    }
}
