using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GameReserveService.Models
{
    [DataContract]
    public class GPSTracking
    {
        [DataMember]
        public int trackingId { get; set; }
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double longitude { get; set; }
        [DataMember]
        public System.DateTime createdAt { get; set; }
        [DataMember]
        public int animalId { get; set; }

        [DataMember(Name = "gpsDeviceId", IsRequired = false, EmitDefaultValue = false)]
        public string gpsDeviceId { get; set; }

        [DataMember(Name = "catId", IsRequired = false, EmitDefaultValue = false)]
        public int catId { get; set; }

        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string message { get; set; }

        [DataMember(Name = "categoryName", IsRequired = false, EmitDefaultValue = false)]
        public string categoryName { get; set; }

        [DataMember(Name = "colorIndication", IsRequired = false, EmitDefaultValue = false)]
        public string colorIndication { get; set; }





    }


}