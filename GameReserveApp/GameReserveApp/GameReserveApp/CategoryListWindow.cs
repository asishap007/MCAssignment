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
                log.Error(String.Format("Error in loading datagrid view {0}",webex.Message));   
            }

        }
        private DataTable GetRESTData()
        {
            this.allCategories = CategoryRepository.GetAllCategories();
            DataTable categoryDetail = new DataTable();
            categoryDetail.Columns.Add("CategoryName", typeof(string));
            categoryDetail.Columns.Add("CategoryColor", typeof(string));
            foreach (CategoryView animalCategory in allCategories)
            {
                categoryDetail.Rows.Add(animalCategory.categoryName,animalCategory.colorIndication);
            }  
            return categoryDetail;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

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
                    }
                }
            }catch(Exception ex)
            {
                this.SuspendLayout();
                PopUpControl popUp = new PopUpControl(ex.Message);
            }
            
            
        }

        private void CategoryListWindow_Activated(object sender, EventArgs e)
        {
            dataGrid();
        }
    }

   
}
