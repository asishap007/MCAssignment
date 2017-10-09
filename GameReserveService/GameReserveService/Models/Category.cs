using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameReserveService
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string categoryName { get; set; }
        [DataMember]
        public string colorIndication { get; set; }
        [DataMember(Name = "message", Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string message { get; set; }
    }
}
