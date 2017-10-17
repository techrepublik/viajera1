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
using InventorySystem.dal.obj;
using InventorySystem.dal.sta;
using InventorySystem.data;

namespace InventorySystem.forms
{
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
        }

        private void productBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (productBindingSource?.Current == null) return;
            productBindingNavigatorSaveItem.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.TabIndex)
            {
                case 0:
                    productCodeTextBox.Focus();
                    break;
                case 1:
                    inInfoCodeTextBox.Focus();
                    break;
                case 2:
                    purchaseOrderNoTextBox.Focus();
                    break;
                case 3:
                    GetAllInventoryData();
                    inInfoCodeTextBox.Focus();
                    jTabWizard1.SelectTab(tabPage5);
                    break;
                default:
                    break;
            }
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.TabIndex)
            {
                case 0:
                    SaveProduct();
                    break;
                case 1:
                    SaveProductIn(SaveInInfo());
                    break;
                case 2:
                    SavePODetails(SavePurchaseOrder());
                    break;
                case 3:
                    SaveOutDetail(SavePurchaseOut());
                    break;
                default:
                    break;
            }
        }

        private void SaveProduct()
        {
            Validate();
            productBindingSource.EndEdit();
            MessageBox.Show(ProductManager.Save(((ObjectView<Product>)productBindingSource.Current).Object) > 0
                    ? @"Product was successfully saved."
                    : @"Error occurred in save operation.", @"Product - Save", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private int SaveInInfo()
        {
            Validate();
            inInfoBindingSource.EndEdit();
            return InInfoManager.Save(((ObjectView<InInfo>) inInfoBindingSource.Current).Object);
        }

        private void SaveProductIn(int iInfoId)
        {
            Validate();
            productInBindingSource.EndEdit();
            MessageBox.Show(ProductInManager.Save((from ObjectView<ProductIn> prodIn in productInBindingSource.List select prodIn.Object).ToList(), iInfoId) > 0
                    ? @"Product-in was successfully saved."
                    : @"Error occurred in save operation.", @"Product-In - Save", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private int SavePurchaseOrder()
        {
            Validate();
            purchaseOrderBindingSource.EndEdit();
            //return PurchaseOrderManager.Save(((ObjectView<PurchaseOrder>) purchaseOrderBindingSource.Current).Object);
            return PurchaseOrderManager.Save((PurchaseOrder)purchaseOrderBindingSource.Current);
        }
        private void SavePODetails(int iPOId)
        {
            Validate();
            pODetailBindingSource.EndEdit();
            //MessageBox.Show(PODetailManager.Save((from ObjectView<PODetail> poDetail in pODetailBindingSource.List select poDetail.Object).ToList(), iPOId) > 0
            //        ? @"PO/Details were successfully saved."
            //        : @"Error occurred in save operation.", @"PO/Detail - Save", MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            MessageBox.Show(PODetailManager.Save(pODetailBindingSource.Cast<PODetail>().ToList(), iPOId) > 0
                   ? @"PO/Details were successfully saved."
                   : @"Error occurred in save operation.", @"PO/Detail - Save", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private int SavePurchaseOut()
        {
            Validate();
            outInfoBindingSource.EndEdit();
            return OutInfoManager.Save((OutInfo) outInfoBindingSource.Current);
        }
        private void SaveOutDetail(int iOutId)
        {
            Validate();
            //MessageBox.Show(PODetailManager.Save((from ObjectView<PODetail> poDetail in pODetailBindingSource.List select poDetail.Object).ToList(), iPOId) > 0
            //        ? @"PO/Details were successfully saved."
            //        : @"Error occurred in save operation.", @"PO/Detail - Save", MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            productOutDataBindingSource.EndEdit();
            var listInventoryOut = new List<ProductOut>();
            foreach (ProductOutData data in productOutDataBindingSource.List)
            {
                listInventoryOut.Add(data);
            }
            MessageBox.Show(ProductOutManager.Save(listInventoryOut, iOutId) > 0
                   ? @"PO/Details were successfully saved."
                   : @"Error occurred in save operation.", @"PO/Detail - Save", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            GetAllCategories();
            GetAllUnits();
            GetAllSuppliers();
            GetAllAreas();
            GetAllProducts();
            GetAllInInfos();
            GetAllOutInfos();
            GetAllPurchaseOrders();

            jTabWizard1.SelectTab(tabPage6);
        }

        public void GetAllInventoryData()
        {
            Cursor.Current = Cursors.WaitCursor;
            productInventoryDataBindingSource.DataSource = InventoryQueries.GetInventoryDatas();
            Cursor.Current = Cursors.Default;
        }
        private void GetAllProducts()
        {
            Cursor.Current = Cursors.WaitCursor;
            productBindingSource.DataSource = new BindingListView<Product>(ProductManager.GetAll());
            Cursor.Current = Cursors.Default;
        }
        private void GetAllCategories()
        {
            Cursor.Current = Cursors.WaitCursor;
            categoryBindingSource.DataSource = CategoryManager.GetAll(); //new BindingListView<Category>(CategoryManager.GetAll());
            Cursor.Current = Cursors.Default;
        }
        private void GetAllUnits()
        {
            Cursor.Current = Cursors.WaitCursor;
            unitBindingSource.DataSource = new BindingListView<Unit>(UnitManager.GetAll());
            Cursor.Current = Cursors.Default;
        }
        private void GetAllSuppliers()
        {
            Cursor.Current = Cursors.WaitCursor;
            supplierBindingSource.DataSource = new BindingListView<Supplier>(SupplierManager.GetAll());
            Cursor.Current = Cursors.Default;
        }
        private void GetAllInInfos()
        {
            Cursor.Current = Cursors.WaitCursor;
            inInfoBindingSource.DataSource = InInfoManager.GetAll(); //new BindingListView<InInfo>(InInfoManager.GetAll());
            Cursor.Current = Cursors.Default;
        }

        private void GetAllProductIns(int iId)
        {
            Cursor.Current = Cursors.WaitCursor;
            productInBindingSource.DataSource = ProductInManager.GetAll(true, iId); //new BindingListView<ProductIn>(ProductInManager.GetAll(true, iId));
            Cursor.Current = Cursors.Default;
        }
        private void GetAllPurchaseOrders()
        {
            Cursor.Current = Cursors.WaitCursor;
            purchaseOrderBindingSource.DataSource = PurchaseOrderManager.GetAll(); //new BindingListView<PurchaseOrder>(PurchaseOrderManager.GetAll());
            Cursor.Current = Cursors.Default;
        }
        private void GetAllPODetails(int iId)
        {
            Cursor.Current = Cursors.WaitCursor;
            //pODetailBindingSource.DataSource = new BindingListView<PODetail>(PODetailManager.GetAll(iId));
            pODetailBindingSource.DataSource = PODetailManager.GetAll(iId);
            Cursor.Current = Cursors.Default;
        }
        private void GetAllAreas()
        {
            Cursor.Current = Cursors.WaitCursor;
            areaBindingSource.DataSource = AreaManager.GetAll();
            Cursor.Current = Cursors.Default;
        }
        private void GetAllOutInfos()
        {
            Cursor.Current = Cursors.WaitCursor;
            outInfoBindingSource.DataSource = OutInfoManager.GetAll();
            Cursor.Current = Cursors.Default;
        }

        private void GetAllProductOuts(int iOutId)
        {
            Cursor.Current = Cursors.WaitCursor;
            productOutDataBindingSource.DataSource = StandardQueries.GetAllProductOutData(iOutId);
            Cursor.Current = Cursors.Default;
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    productBindingNavigator.BindingSource = productBindingSource;
                    break;
                case 1:
                    productBindingNavigator.BindingSource = inInfoBindingSource;
                    break;
                case 2:
                    productBindingNavigator.BindingSource = purchaseOrderBindingSource;
                    break;
                case 3:
                    productBindingNavigator.BindingSource = outInfoBindingSource;
                    break;
                default:
                    break;
            }
        }

        private void inInfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (inInfoBindingSource?.Current == null) return;
            //GetAllProductIns(((ObjectView<InInfo>)inInfoBindingSource.Current).Object.InInfoId); 
            GetAllProductIns(((InInfo)inInfoBindingSource.Current).InInfoId);
        }

        private void purchaseOrderBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (purchaseOrderBindingSource?.Current == null) return;
            //GetAllPODetails(((ObjectView<PurchaseOrder>)purchaseOrderBindingSource.Current).Object.PurchaseOrderId);
            GetAllPODetails(((PurchaseOrder)purchaseOrderBindingSource.Current).PurchaseOrderId);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            SelectInventories();
            jTabWizard1.SelectTab(tabPage6);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            jTabWizard1.SelectTab(tabPage5);
        }

        private void SelectInventories()
        {
            var listInventory = new List<ProductOutData>();
            foreach (DataGridViewRow row in productInventoryDataDataGridView.Rows)
            {
                Console.WriteLine(row.Cells[0].FormattedValue);
                var formattedValue = row.Cells[0].FormattedValue;
                if (formattedValue != null && (bool) formattedValue)
                {
                    var a = new ProductOutData
                    {
                        ProductInId = ((ProductInventoryData) row.DataBoundItem).ProductInId,
                        ProductName = ((ProductInventoryData) row.DataBoundItem).ProductName,
                        ProductOutQnty = ((ProductInventoryData) row.DataBoundItem).TotalInQnty,
                        ProductOutIsActive = true,
                        ProductOutPrice = ((ProductInventoryData) row.DataBoundItem).Price,
                        UnitName = ((ProductInventoryData)row.DataBoundItem).UnitName
                    };
                    Console.WriteLine(a.ProductInId.ToString() + @" - " + a.ProductName);
                    listInventory.Add(a);
                }
            }
            productOutDataBindingSource.DataSource = listInventory;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                LoadInventoryProduct(Convert.ToInt16(comboBox1.SelectedValue));
            }
        }

        private void LoadInventoryProduct(int iCatId)
        {
            Cursor.Current = Cursors.WaitCursor;
            productInventoryDataBindingSource.DataSource = InventoryQueries.GetInventoryDatas(iCatId);
            Cursor.Current = Cursors.Default;
        }

        private void productOutDataDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void outInfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (outInfoBindingSource?.Current == null) return;
            GetAllProductOuts(((OutInfo) outInfoBindingSource.Current).OutInfoId);
        }
    }
}
