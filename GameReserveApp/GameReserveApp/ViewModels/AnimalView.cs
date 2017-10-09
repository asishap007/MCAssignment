using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameReserveApp.ViewModels
{
   
    class AnimalView
    {
        public int id { get; set; }
        public int animalId { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string colorIndication { get; set; }
        public string gpsDeviceId { get; set; }
        public string createdAt { get; set; }
        public int totalAnimals { get; set; }
        public string message { get; set; }
        
    }
}
