using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace GameReserveApp
{
    public partial class LocateAnimals : Form
    {
        public LocateAnimals()
        {
            InitializeComponent();
        }

        private void LocateAnimals_Load(object sender, EventArgs e)
        {
          
        }

        /// <summary>
        /// Google map functionalities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapControl_Load(object sender, EventArgs e)
        {
            //Loading the google map in the gmap control
            gMapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.Zoom = 3;
            gMapControl.Position = new PointLatLng(config.SALatitude,config.SALongitude);
            //Marking the different locations in google map
            string json = "[{latitude:-30.2555,longitude:31.2555,category:'elephant',colorHexCode:'#FF0000'},{latitude:-25.966688,longitude:32.580528,category:'tiger',colorHexCode:'#FFFF00'},{latitude:8.5241,longitude:76.9366,category:'elephant',colorHexCode:'#FF0000'},{latitude:-26.2041,longitude:28.0473,category:'tiger',colorHexCode:'#FF0000'},{latitude:-28.8016,longitude:28.5331,category:'tiger',colorHexCode:'#FF0000'},{latitude:-28.7282,longitude:24.7499,category:'elephant',colorHexCode:'#FF0000'},{latitude:-25.7479,longitude:28.2293,category:'tiger',colorHexCode:'#FF0000'}]";
            JavaScriptSerializer js = new JavaScriptSerializer();
            Points[] pointObj = js.Deserialize<Points[]>(json); 

            foreach (Points point in pointObj)
            {
                GMarkerGoogle marker;
                GMapOverlay markersOverlay = new GMapOverlay("markers");               
                string colorMarker = GetColourName(point.colorHexCode)+"_small"; 
                GMarkerGoogleType MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), colorMarker, true);
                marker = new GMarkerGoogle(new PointLatLng(point.latitude, point.longitude),MarkerColor);  
                markersOverlay.Markers.Add(marker);
                gMapControl.Overlays.Add(markersOverlay);
            }  
           
        }
        
        string GetColourName(string colorCode)
        {
            Color color = (Color)new ColorConverter().ConvertFromString(colorCode);
            KnownColor knownColor = color.ToKnownColor();
            string name = knownColor.ToString().ToLower();
            return name.Equals("0") ? "green" : name;
        }

        
       

    }

    /// <summary>
    /// Class containing details of points
    /// </summary>
    public class Points
    {
        public double longitude;
        public double latitude;
        public string category;
        public string colorHexCode;
    }
}

        //For drawing the polygons in google map
        //GMapOverlay polyOverlay = new GMapOverlay("polygons");
        //List<PointLatLng> pointsObj = new List<PointLatLng>();
        //pointsObj.Add(new PointLatLng(-45.969562, 32.585789));
        //pointsObj.Add(new PointLatLng(-30.966205, 42.588171));
        //pointsObj.Add(new PointLatLng(-30.968134, 52.591647));
        //pointsObj.Add(new PointLatLng(-45.971684, 62.589759));
        //GMapPolygon polygon = new GMapPolygon(pointsObj, "mypolygon");
        //polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
        //polygon.Stroke = new Pen(Color.Red, 1);
        //polyOverlay.Polygons.Add(polygon);
        //gMapControl.Overlays.Add(polyOverlay);

