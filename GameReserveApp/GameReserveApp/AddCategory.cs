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
    public partial class AddCategory : Form
    {
        public string categoryName;
        public string categoryColor;
        public string colorHexCode;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public AddCategory()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Add new animal category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            this.categoryName = this.textBox1.Text;
            this.categoryColor = "#" + colorHexCode;
            //Log.Info("Add new category prperties.");
        }

        /// <summary>
        /// Select a color for each animal category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.colorHexCode = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            }
            this.textBox2.BackColor = colorDialog1.Color;
        }
    }
}
