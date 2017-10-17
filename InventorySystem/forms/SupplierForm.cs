using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using InventorySystem.dal.man;
using InventorySystem.data;

namespace InventorySystem.forms
{
    public partial class SupplierForm : Form
    {
        private List<Supplier> _deleteSupplierList = null; 
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            GetSuppliers();
        }

        private void GetSuppliers()
        {
            Cursor.Current = Cursors.WaitCursor;
            supplierBindingSource.DataSource = new BindingListView<Supplier>(SupplierManager.GetAll());
            Cursor.Current = Cursors.Default;
        }

        private void supplierBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (supplierBindingSource?.Current == null) return;
            supplierBindingNavigatorSaveItem.Enabled = true;
        }

        private void supplierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            supplierBindingSource.EndEdit();
          
            if (SupplierManager.Save(ConvertToSuppliers()) > 0) //add + update
            {
                MessageBox.Show(@"Supplier record(s) were successfully saved.", @"Suppier - Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show(@"Error in saving.", @"Suppier - Save", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private List<Supplier> ConvertToSuppliers()
        {
            Validate();
            return (from ObjectView<Supplier> supplier in supplierBindingSource.List select supplier.Object).ToList();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (supplierBindingSource?.Current == null) return;
            //_deleteSupplierList = new List<Supplier> {((ObjectView<Supplier>) supplierBindingSource.Current).Object};
            //_deleteSupplierList = new List<Supplier> { (Supplier)supplierBindingSource.Current };
            Console.WriteLine(((ObjectView<Supplier>)supplierBindingSource.Current).Object.SupplierName);
        }

        private void DeleteSuppliers()
        {
            var dialog =
                MessageBox.Show(@"There are records marked for deletion. Press YES to continue and NO to cancel.",
                    @"Supplier Record - Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
            if (dialog == DialogResult.Yes)
            {
                if (SupplierManager.Delete(_deleteSupplierList))
                    Console.WriteLine(@"Delete Completed Successfully.");
                else
                {
                    Console.WriteLine(@"Error in deleting supplier records.");
                }
            }
        }
    }
}
