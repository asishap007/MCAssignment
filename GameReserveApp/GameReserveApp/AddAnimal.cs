using GameReserveApp.Repository;
using GameReserveApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameReserveApp
{
    public partial class AddAnimal : Form
    {
        public string categoryName;
        public string GPSDeviceId;
        public int categoryId;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }


        public AddAnimal()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Load all categories on form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadAnimalCategories(object sender, EventArgs e)
        {
            try
            {
                CategoryView[] category = CategoryRepository.GetAllCategories();
                this.comboBox1.DataSource = category;
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "CategoryName";
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Error in load all animal categories {0}", ex.Message));
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Add new Animal and send data to server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryView selectedCategory = (CategoryView)this.comboBox1.Items[comboBox1.SelectedIndex];
                this.categoryId = selectedCategory.id;
                this.categoryName = selectedCategory.categoryName;
                this.GPSDeviceId = this.textBox1.Text;
            }
            catch(Exception ex)
            {
                log.Error(String.Format("Error in add new animal {0}", ex.Message));
                MessageBox.Show(ex.Message);
            }
            
        }

        
    }
}
