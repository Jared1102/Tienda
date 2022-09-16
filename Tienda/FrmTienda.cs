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

namespace Tienda
{
    public partial class FrmTienda : Form
    {
        private ManejadorProducto _manejadorProducto;
        public FrmTienda()
        {
            InitializeComponent();
            _manejadorProducto = new ManejadorProducto();
            Actualizar();
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
    }
}
