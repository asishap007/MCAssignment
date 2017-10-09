using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameReserveApp.ViewModels
{

class TrackingView
    {
        public int trackingId { get; set; }
        public int animalId { get; set; }
        public int catId { get; set; }
        public string categoryName { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string colorIndication { get; set; }
        public string gpsDeviceId { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string createdAt { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string message { get; set; }
        
    }
}
