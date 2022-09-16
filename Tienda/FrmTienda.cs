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
    public partial class FrmTienda : Form
    {
        private ManejadorProducto _manejadorProducto;
        public static Producto producto = null;
        public FrmTienda()
        {
            InitializeComponent();
            _manejadorProducto = new ManejadorProducto();
        }

        #region Funciones

        private void Actualizar()
        {
            _manejadorProducto.obtenerProductos(dtgTienda);
        }

        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto frmAgregarProducto = new FrmAgregarProducto();
            frmAgregarProducto.ShowDialog();
            Actualizar();
        }

        private void dtgTienda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            producto = new Producto {
                IdProducto = Convert.ToInt32(dtgTienda.CurrentRow.Cells["IdProducto"].Value.ToString()),
                Nombre = dtgTienda.CurrentRow.Cells["Nombre"].Value.ToString(),
                Descripcion = dtgTienda.CurrentRow.Cells["Descripcion"].Value.ToString(),
                Precio = Convert.ToDecimal(dtgTienda.CurrentRow.Cells["Precio"].Value.ToString())
            };
            switch (e.ColumnIndex)
            {
                case 4: FrmAgregarProducto frmAgregarProducto = new FrmAgregarProducto();
                        frmAgregarProducto.ShowDialog();
                    ;break;
                case 5: _manejadorProducto.borrarProducto(producto); break;
            }

            producto = null;
            Actualizar();
        }

        private void FrmTienda_Load(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
