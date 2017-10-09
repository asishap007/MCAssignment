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

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void generateButton_Click(object sender, EventArgs e)
        {
            reportChart.Series["Count"].Points.Clear();
            reportChart.Titles.Clear();
            if (toDate > DateTime.Now)
            {
                PopUpControl popUP = new PopUpControl("End date cannot be greater than present date");
                popUP.Show();
                Report.ActiveForm.SuspendLayout();
            }
            else if(fromDate>toDate){
                PopUpControl popUP = new PopUpControl("From date should be less then To date");
                popUP.Show();
                //Report.ActiveForm.SuspendLayout();
            }

            else
            {
                string json = "[{category:'Elephant',count:6,color:'#FF0000'},{category:'Tiger',count:8,color:'#FF00FF'},{category:'Lion',count:2,color:'#0000FF'}]";
                JavaScriptSerializer js = new JavaScriptSerializer();
                reportList[] animalList = js.Deserialize<reportList[]>(json);
                int i = 0;
                foreach (reportList animal in animalList)
                {
                    reportChart.Series["Count"].Points.AddXY(animal.category, animal.count);
                    Color color = ColorTranslator.FromHtml(animal.color);
                    reportChart.Series["Count"].Points[i].Color = color;
                    i++;
                }
                reportChart.Titles.Add("Count of Wildlife animals");
                jsonStringToCSV(json);
            }


        }

        /// <summary>
        ///Converts Json string to .csv file
        /// </summary>
        /// <param name="jsonContent">json string</param>

        public static void jsonStringToCSV(string jsonContent)
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
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = dataTable.AsEnumerable()
                               .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            string fileName = config.csvfilePath + "_" + String.Format("{0:dd MMMM yyyy}", DateTime.Now) + ".csv";
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

        private void reportChart_Click(object sender, EventArgs e)
        {

        }
             
    }

    public class reportList
    {
        public string category;
        public Int64 count;
        public string color;
    }

}
