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
    public class AnimalCategory
    {
        [DataMember]
        public Int32 id { get; set; }
        [DataMember(Name = "categoryName")]
        public string categoryName { get; set; }
        [DataMember(Name = "colorIndication")]
        public string colorIndication { get; set; }
        [DataMember(Name = "totalAnimals")]
        public Int32 totalAnimals { get; set; }
    }
}