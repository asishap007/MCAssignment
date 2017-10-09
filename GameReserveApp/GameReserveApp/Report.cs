using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Windows;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using GameReserveApp.ViewModels;
using GameReserveApp.Repository;

namespace GameReserveApp
{
    public partial class Report : Form
    {

        public DateTime fromDate =DateTime.Now;
        public DateTime toDate = DateTime.Now;

        public Report()
        {
            InitializeComponent();
            reportChart.DataSource = null;
            reportChart.Titles.Clear();
        }

        /// <summary>
        /// Generate Barchart based on the animal category and count
        /// for a particular time period.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateButton_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            try
            {
                reportChart.Series["Count"].Points.Clear();
                reportChart.Titles.Clear();
                if (toDate > DateTime.Now)
                {
                    PopUpControl popUP = new PopUpControl("End date cannot be greater than present date");
                    popUP.Show();
                    Report.ActiveForm.SuspendLayout();
                }
                else if (fromDate > toDate)
                {
                    PopUpControl popUP = new PopUpControl("From date should be less then To date");
                    popUP.Show();
                }else if (filePath == "")
                {
                    PopUpControl popUP = new PopUpControl("Please enter a location");
                    popUP.Show();
                }else
                {
                    string frmDate = fromDate.ToString("yyyy-MM-dd");
                    string endDate = toDate.ToString("yyyy-MM-dd");
                    AnimalView[] animalList = AnimalRepository.GetTotalCountOfAnimalsByCategory(frmDate, endDate);
                    int i = 0;
                    foreach (AnimalView animal in animalList)
                    {
                        reportChart.Series["Count"].Points.AddXY(animal.categoryName, animal.totalAnimals);
                        Color color = ColorTranslator.FromHtml(animal.colorIndication);
                        reportChart.Series["Count"].Points[i].Color = color;
                        i++;
                    }
                    reportChart.Titles.Add("Count of Wildlife animals");
                    string jsonContent = JsonConvert.SerializeObject(animalList);
                    jsonStringToCSV(jsonContent, filePath);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///Converts Json string to .csv file
        /// </summary>
        /// <param name="jsonContent">Report data in json string format.</param>
        /// <param name="filePath">json string</param>

        public static void jsonStringToCSV(string jsonContent, string filePath)
        {
            
            //used NewtonSoft json nuget package
            XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + jsonContent + "}}");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml.InnerXml);
            XmlReader xmlReader = new XmlNodeReader(xml);
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            var dataTable = dataSet.Tables[0];
            //Datatable to CSV
            var lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = dataTable.AsEnumerable().Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            string fileName = filePath + "_" + String.Format("{0:dd MMMM yyyy}", DateTime.Now) + ".csv";
            File.WriteAllLines(fileName, lines);
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            fromDate = fromDatePicker.Value.Date;
        }

        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            toDate = toDatePicker.Value.Date;
        }

    
        private void SelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                textBox1.Text = sSelectedPath + "Report";
            }
        }
    }

}
