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

namespace InventorySystem.forms
{
    public partial class InventoryForm : Form
    {
        private List<ProductInventoryData> _listDatas;

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            GetAllInventories();
        }

        private void GetAllInventories()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listDatas = InventoryQueries.GetInventoryDatas();
            productInventoryDataBindingSource.DataSource = new BindingListView<ProductInventoryData>(_listDatas); ;
            Cursor.Current = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBox1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var listDatas = _listDatas.Cast<ProductInventoryData>().ToList();
            switch (comboBox1.SelectedIndex)
            {
                case 0: //product/inventory item
                    comboBox2.DataSource = ProductManager.GetAll();
                    comboBox2.DisplayMember = "ProductName";
                    break;
                case 1: //unit
                    comboBox2.DataSource = UnitManager.GetAll();
                    comboBox2.DisplayMember = "UnitName";
                    break;
                case 2: //category
                    comboBox2.DataSource = CategoryManager.GetAll();
                    comboBox2.DisplayMember = "CategoryName";
                    break;
                case 3: //supplier
                    comboBox2.DataSource = SupplierManager.GetAll();
                    comboBox2.DisplayMember = "SupplierName";
                    break;
                case 4: //receipt no
                    comboBox2.DataSource = InInfoManager.GetAll();
                    comboBox2.DisplayMember = "InInfoReceiptNo";
                    break;
                case 5: //area
                    comboBox2.DataSource = AreaManager.GetAll();
                    comboBox2.DisplayMember = "AreaName";
                    break;
                default:
                    break;
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            //var listDatas = _listDatas.Cast<ObjectView<ProductInventoryData>>().ToList();
            switch (comboBox1.SelectedIndex)
            {
                case 0: //product/inventory item
                    var listView1 = new BindingListView<ProductInventoryData>(_listDatas.FindAll(f => f.ProductName.Contains(comboBox2.Text)));
                    productInventoryDataBindingSource.DataSource = listView1;
                    break;
                case 1: //unit
                    var listView2 = new BindingListView<ProductInventoryData>(_listDatas.FindAll(f => f.UnitName.Contains(comboBox2.Text)));
                    productInventoryDataBindingSource.DataSource = listView2;
                    break;
                case 2: //category
                    var listView3 = new BindingListView<ProductInventoryData>(_listDatas.FindAll(f => f.CategoryName.Contains(comboBox2.Text)));
                    productInventoryDataBindingSource.DataSource = listView3;
                    break;
                case 3: //supplier
                    var listView4 = new BindingListView<ProductInventoryData>(_listDatas.FindAll(f => f.SupplierName.Contains(comboBox2.Text)));
                    productInventoryDataBindingSource.DataSource = listView4;
                    break;
                case 4: //receipt no
                    var listView5 = new BindingListView<ProductInventoryData>(_listDatas.FindAll(f => f.ReceiptNo.ToString() == comboBox2.Text));
                    productInventoryDataBindingSource.DataSource = listView5;
                    break;
                case 5: //area
                    var listView6 = new BindingListView<ProductInventoryData>(_listDatas.FindAll(f => f.AreaName == comboBox2.Text));
                    productInventoryDataBindingSource.DataSource = listView6;
                    break;
                default:
                    break;
            }
        }
    }
}
