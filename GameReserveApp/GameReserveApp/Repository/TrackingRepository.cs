using GameReserveApp.Helper;
using GameReserveApp.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GameReserveApp.Repository
{
    class TrackingRepository
    {
        public static TrackingView[] GetLatestPositionOfAnimal()
        {
            string trackingurl = config.serverUrl + config.trackingUri;
            string trackListInJson = RequestClient.getRequest(trackingurl);
            TrackingView[] allAnimals =  JObject.Parse(trackListInJson)["GetLatestPositionOfAnimalResult"].ToObject<TrackingView[]>();
            return allAnimals;
        }

        public static TrackingView AddTracking(TrackingView animal)
        {
            string trackingurl = config.serverUrl + config.addTrackingUri;
            string addTrackInJson = RequestClient.getRequest(trackingurl);
            TrackingView addTrack = JsonConvert.DeserializeObject<TrackingView>(addTrackInJson);
            return addTrack;
        }


    }
}
