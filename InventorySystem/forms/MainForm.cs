using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySystem.forms;

namespace InventorySystem
{
    public partial class MainForm : Form
    {
        private SupplierForm _supplierForm = null;
        private ProductListForm _productListForm = null;
        private InventoryForm _inventoryForm = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((_supplierForm == null) || (_supplierForm.IsDisposed))
            {
                _supplierForm = new SupplierForm
                {
                    WindowState = FormWindowState.Maximized,
                    MdiParent = this
                };
            }
            _supplierForm.Show();
            _supplierForm.BringToFront();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Preferences
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle
            };
            f.ShowDialog();
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productManagementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ((_productListForm == null) || (_productListForm.IsDisposed))
            {
                _productListForm = new ProductListForm
                {
                    WindowState = FormWindowState.Maximized,
                    MdiParent = this
                };
            }
            _productListForm.Show();
            _productListForm.BringToFront();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((_inventoryForm == null) || (_inventoryForm.IsDisposed))
            {
                _inventoryForm = new InventoryForm
                {
                    WindowState = FormWindowState.Maximized,
                    MdiParent = this
                };
            }
            _inventoryForm.Show();
            _inventoryForm.BringToFront();
        }
    }
}
