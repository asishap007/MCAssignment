using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GameReserveService.Models;
using GameReserveService.Repository;

namespace GameReserveService
{
    
    public class TrackingService : ITrackingService
    {
        /// <summary>
        /// Service to add current location of an animal. This api is used by the GPS and will trigger
        /// at a particular interval of time.
        /// </summary>
        /// <param name="gpsDetails"></param>
        /// <returns></returns>
        public GPSTracking AddTracking(GPSTracking gpsDetails)
        {
            return TrackingRepository.AddTracking(gpsDetails);
        }

        /// <summary>
        /// Service to get the list of latest position of all animals.
        /// </summary>
        /// <returns></returns>
        public List<GPSTracking> GetLatestPositionOfAnimal()
        {
            return TrackingRepository.GetLatestPositionOfAnimal();
        }
    }
}
