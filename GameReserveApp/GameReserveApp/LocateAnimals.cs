using GameReserveApp.Repository;
using GameReserveApp.ViewModels;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        public LocateAnimals()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        private void LocateAnimals_Load(object sender, EventArgs e)
        {
          
        }

        /// <summary>
        /// Locate all animals in Gmap with different color indication.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapControl_Load(object sender, EventArgs e)
        {
            this.loadMap();
        }

        /// <summary>
        /// Load the the animal location in Gmap when form is activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocateAnimals_Activated(object sender, EventArgs e)
        {
            this.loadMap();
        }

        /// <summary>
        /// Setting up GMap and pull all category animals. 
        /// Based on the latitude and logitude of each animal, 
        /// app will show the position.
        /// </summary>
        private void loadMap()
        {
            try
            {
                //Loading the google map in the gmap control
                gMapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                gMapControl.Zoom = 3;
                gMapControl.Position = new PointLatLng(config.SALatitude, config.SALongitude);
                TrackingView[] points = TrackingRepository.GetLatestPositionOfAnimal();
                var lstTrackingByGroups = points.GroupBy(s => s.catId);
                GMarkerGoogle marker;
                GMapOverlay markersOverlay = new GMapOverlay("markers");
                int i = 0;
                foreach (var listByGroups in lstTrackingByGroups)
                {
                    foreach (TrackingView point in listByGroups)
                    {
                        point.colorIndication = config.CategoryColors[i];
                        GMarkerGoogleType MarkerColor = (GMarkerGoogleType)Enum.Parse(typeof(GMarkerGoogleType), point.colorIndication, true);
                        marker = new GMarkerGoogle(new PointLatLng(point.latitude, point.longitude), MarkerColor);
                        marker.ToolTipText = point.categoryName;
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        markersOverlay.Markers.Add(marker);
                    }
                    i = i + 1;
                }
                gMapControl.Overlays.Add(markersOverlay);
               
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Error map view {0}", ex.Message));
                MessageBox.Show(ex.Message);
            }

        }

       
    }

}

