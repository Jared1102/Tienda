using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesTienda;

namespace AccesoDatos
{
    public class AccesoProductos
    {
        private Conexion _conexion;

        public AccesoProductos()
        {
            _conexion = new Conexion("localhost","root","","Tienda", 3306);
        }

        public List<Producto> obtenerProductos()
        {
            var listProductos = new List<Producto>();
            var ds = new DataSet();
            string consulta = "SELECT * FROM PRODUCTO";
            ds = _conexion.ObtenerDatos(consulta, "producto");
            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var Producto = new Producto
                {
                    IdProducto = Convert.ToInt32(row["idproducto"]),
                    Nombre = row["nombre"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = Convert.ToDecimal(row["precio"])
                };

                listProductos.Add(Producto);
            }

            return listProductos;
        }

        public void agregarProducto(Producto producto)
        {
            string consulta = string.Format("call p_Productos('0','{0}','{1}',{2},1)",
                producto.Nombre,
                producto.Descripcion,
                producto.Precio.ToString());
            _conexion.EjecutarConsulta(consulta);

        }
    }
}
