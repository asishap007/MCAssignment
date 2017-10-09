using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Net;
using System.IO;
using GameReserveApp.Helper;
using GameReserveApp.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GameReserveApp.Repository;

namespace GameReserveApp
{
    public partial class CategoryListWindow : Form
    {

        public int cellNumber ;
        private CategoryView[] allCategories ;
        DataTable categoryDetail;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }


        public CategoryListWindow()
        {
            InitializeComponent();
            this.dataGridView1.MultiSelect = false;
            log4net.Config.XmlConfigurator.Configure();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cellNumber = this.dataGridView1.CurrentCell.RowIndex;
        }

        /// <summary>
        /// Setting up the data in category dataGrid component.
        /// </summary>
        private void dataGrid()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                dataGridView1.DataSource = GetRESTData();
                dataGridView1.Refresh();
                this.PerformLayout();
            }
            catch (WebException webex)
            {
                MessageBox.Show(webex.Message);
                log.Error(String.Format("Error in loading datagrid view {0}",webex.Message));   
            }

        }

        /// <summary>
        /// Return the category data as DataTable type.
        /// </summary>
        /// <returns></returns>
        private DataTable GetRESTData()
        {
            categoryDetail = new DataTable();
            try
            {
                this.allCategories = CategoryRepository.GetAllCategories();
                categoryDetail.Columns.Add("CategoryName", typeof(string));
                categoryDetail.Columns.Add("CategoryColor", typeof(string));
                foreach (CategoryView animalCategory in allCategories)
                {
                    categoryDetail.Rows.Add(animalCategory.categoryName, animalCategory.colorIndication);
                }
                return categoryDetail;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(string.Format("Error in get Reposiory details from server {0}", ex.Message));
                return categoryDetail;
            }
            
        }

        /// <summary>
        /// Add new animal category and send data to server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddCategory popup = new AddCategory();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    string categoryName = popup.categoryName;
                    string categoryColor = popup.categoryColor;
                    this.categoryDetail.Rows.Add(categoryName, categoryColor);
                    this.dataGridView1.Refresh();
                    CategoryRepository.AddCategory(GetCatgory(categoryName, categoryColor));
                    dataGrid();
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    //Close the popup box
                }
                popup.Dispose();
            }
            catch(Exception ex)
            {
                log.Error(string.Format("Error in send new category data to server {0}", ex.Message));
                dataGrid();
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Delete category from the data list. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    int itemTobedelete = item.Index;
                    CategoryView toBeDelete = allCategories[itemTobedelete];
                    Console.WriteLine(toBeDelete);
                    CategoryView deletedItem = CategoryRepository.DeleteCategory(toBeDelete.id);
                    if (deletedItem.categoryName != null)
                    {
                        this.dataGridView1.Rows.RemoveAt(itemTobedelete);
                        this.dataGridView1.Refresh();
                        dataGrid();
                    }
                }
            }catch(Exception ex)
            {
                log.Error(string.Format("Error in delete category from server {0}", ex.Message));
                this.SuspendLayout();
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void CategoryListWindow_Activated(object sender, EventArgs e)
        {
            dataGrid();
        }

        private CategoryView GetCatgory(string categoryName, string categoryColor)
        {
            CategoryView addNewCategory = new CategoryView();
            addNewCategory.categoryName = categoryName;
            addNewCategory.colorIndication = categoryColor;
            return addNewCategory;
        }
    }

   
}
