using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
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
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            GetAllCategoryRecords();
            GetAllAreaRecords();
            GetAllUnitRecords();
        }

        private void GetAllAreaRecords()
        {
            Cursor.Current = Cursors.WaitCursor;
            areaBindingSource.DataSource = new BindingListView<Area>(AreaManager.GetAll());
            Cursor.Current = Cursors.Default;
        }
        private void GetAllCategoryRecords()
        {
            Cursor.Current = Cursors.WaitCursor;
            categoryBindingSource.DataSource = new BindingListView<Category>(CategoryManager.GetAll());
            Cursor.Current = Cursors.Default;
        }
        private void GetAllUnitRecords()
        {
            Cursor.Current = Cursors.WaitCursor;
            unitBindingSource.DataSource = new BindingListView<Unit>(UnitManager.GetAll());
            Cursor.Current = Cursors.Default;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    categoryBindingNavigator.BindingSource = categoryBindingSource;
                    break;
                case 1:
                    categoryBindingNavigator.BindingSource = areaBindingSource;
                    break;
                case 2:
                    categoryBindingNavigator.BindingSource = unitBindingSource;
                    break;
                default:
                    break;
            }
        }

        private void categoryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (categoryBindingSource?.Current == null) return;
            categoryBindingNavigatorSaveItem.Enabled = true;
        }

        private void areaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (areaBindingSource?.Current == null) return;
            categoryBindingNavigatorSaveItem.Enabled = true;
        }

        private void unitBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (unitBindingSource?.Current == null) return;
            categoryBindingNavigatorSaveItem.Enabled = true;
        }

        private void categoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.TabIndex)
            {
                case 0:
                    SaveCategory();
                    break;
                case 1:
                    SaveArea();
                    break;
                case 2:
                    SaveUnit();
                    break;
                default:
                    break;
            }
        }

        private void SaveCategory()
        {
            Validate();
            categoryBindingSource.EndEdit();
            MessageBox.Show(CategoryManager.Save(
                    (from ObjectView<Category> category in categoryBindingSource.List select category.Object).ToList()) > 0
                    ? @"Categories were successfully saved."
                    : @"Error occurred in save operation.", @"Category - Save", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void SaveArea()
        {
            Validate();
            areaBindingSource.EndEdit();
            MessageBox.Show(AreaManager.Save(
                    (from ObjectView<Area> area in areaBindingSource.List select area.Object).ToList()) > 0
                    ? @"Areas were successfully saved."
                    : @"Error occurred in save operation.", @"Area - Save", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void SaveUnit()
        {
            Validate();
            unitBindingSource.EndEdit();
            MessageBox.Show(UnitManager.Save(
                    (from ObjectView<Unit> unit in unitBindingSource.List select unit.Object).ToList()) > 0
                    ? @"Categories were successfully saved."
                    : @"Error occurred in save operation.", @"Category - Save", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
