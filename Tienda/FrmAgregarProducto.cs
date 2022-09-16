using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadoresTienda;
using EntidadesTienda;

namespace Tienda
{
    public partial class FrmAgregarProducto : Form
    {
        private ManejadorProducto _manejadorProducto;
        public FrmAgregarProducto()
        {
            InitializeComponent();
            _manejadorProducto = new ManejadorProducto();
            if (FrmTienda.producto != null)
            {
                txtDescripcion.Text = FrmTienda.producto.Descripcion.ToString();
                txtNombre.Text = FrmTienda.producto.Nombre.ToString();
                txtPrecio.Text = FrmTienda.producto.Precio.ToString();
            }
        }

        #region

        private void Cerrar()
        {
            this.Close();
        }

        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmTienda.producto == null)
            {
                _manejadorProducto.agregarProducto(new Producto
                {
                    IdProducto = 0,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text)
                });
            }
            else
            {
                _manejadorProducto.modificarProducto(new Producto
                {
                    IdProducto = FrmTienda.producto.IdProducto,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text)
                });
            }
            Cerrar();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
