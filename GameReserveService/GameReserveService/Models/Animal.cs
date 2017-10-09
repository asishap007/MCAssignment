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
    public class Animal
    {
        [DataMember]
        public int animalId { get; set; }
        [DataMember]
        public int categoryId { get; set; }
        [DataMember]
        public string gpsDeviceId { get; set; }
        [DataMember(Name = "createdAt", IsRequired = false, EmitDefaultValue = false)]
        public string createdAt { get; set; }
        [DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
        public string message { get; set; }
        [DataMember(Name = "categoryName", IsRequired = false, EmitDefaultValue = false)]
        public string categoryName { get; set; }

    }

   
}