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
    public partial class AnimalListWindow : Form
    {

        public int cellNumber ;
        private AnimalView[] allAnimals ;
        DataTable categoryDetail;
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }


        public AnimalListWindow()
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
        /// Setting up the data in animal dataGrid component.
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
                log.Error(String.Format("Error in loading datagrid view {0}",webex.Message));   
            }

        }
        /// <summary>
        /// Return the animal data as DataTable type.
        /// </summary>
        /// <returns></returns>
        private DataTable GetRESTData()
        {
            categoryDetail = new DataTable();
            try
            {
                this.allAnimals = AnimalRepository.GetAllAnimals();
                categoryDetail.Columns.Add("CategoryName", typeof(string));
                categoryDetail.Columns.Add("GPS Device No", typeof(string));
                foreach (AnimalView animal in allAnimals)
                {
                    categoryDetail.Rows.Add(animal.categoryName, animal.gpsDeviceId);
                }
                return categoryDetail;
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Error in data table", ex.Message));
                MessageBox.Show(ex.Message);
                return categoryDetail;
            }
            
        }

        /// <summary>
        /// Method to add new animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddAnimal popup = new AddAnimal();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    string categoryName = popup.categoryName;
                    int categoryId = popup.categoryId;
                    string GPSDeviceId = popup.GPSDeviceId;
                    this.categoryDetail.Rows.Add(categoryName, GPSDeviceId);
                    this.dataGridView1.Refresh();
                    AnimalRepository.AddAnimal(GetAnimal(categoryName, categoryId, GPSDeviceId));
                    dataGrid();
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    //Close the popup box
                }
                popup.Dispose();
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Error add animal", ex.Message));
                dataGrid();
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Delete an item from the list.
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
                    AnimalView toBeDelete = allAnimals[itemTobedelete];
                    Console.WriteLine(toBeDelete);
                    AnimalView deletedItem = AnimalRepository.DeleteAnimal(toBeDelete.animalId);
                    if (deletedItem.gpsDeviceId != null)
                    {
                        this.dataGridView1.Rows.RemoveAt(itemTobedelete);
                        this.dataGridView1.Refresh();
                        dataGrid();
                    }
                }
            }catch(Exception ex)
            {
                log.Error(String.Format("Error in delete animal", ex.Message));
                MessageBox.Show(ex.Message);
            }
            
            
        }

        /// <summary>
        /// Load the data in DataGrid when form is in active state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryListWindow_Activated(object sender, EventArgs e)
        {
            dataGrid();
        }

        /// <summary>
        /// Map a signle animal property ro AnimalView model.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="categoryId"></param>
        /// <param name="GPSDeviceId"></param>
        /// <returns></returns>
        private AnimalView GetAnimal(string categoryName, int categoryId, string GPSDeviceId)
        {
            AnimalView addNewAnimal = new AnimalView();
            addNewAnimal.categoryId = categoryId;
            addNewAnimal.categoryName = categoryName;
            addNewAnimal.gpsDeviceId = GPSDeviceId;
            return addNewAnimal;
        }
    }

   
}
