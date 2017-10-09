using GameReserveService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameReserveService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITrackingService" in both code and config file together.
    [ServiceContract]
    public interface ITrackingService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddTracking")]
        GPSTracking AddTracking(GPSTracking gpsDetails);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetLatestPositionOfAnimal")]
        List<GPSTracking> GetLatestPositionOfAnimal();
    }
}
