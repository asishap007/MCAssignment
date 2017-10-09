using GameReserveService.ErrorHandler;
using GameReserveService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace GameReserveService.Repository
{
    /// <summary>
    /// Class which  updates the positions of different animals to database and 
    /// retrives the latest positions of the animals
    /// </summary>
    public class TrackingRepository
    {
        //Configures log4net in class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        public TrackingRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Saves the details of Gps device associated with each animal.
        /// </summary>
        /// <param name="GpsDetails">Instance of class GPSTracking</param>
        /// <returns>Instance of class GPSTracking</returns>
        public static GPSTracking AddTracking(GPSTracking GpsDetails)
        {
            string successMsg = "Created sucessfully";
            using (game_reserveEntities context = new game_reserveEntities())
            {
                var singleAnimal = (from p in context.animals where p.gpsDeviceId == GpsDetails.gpsDeviceId select p).FirstOrDefault();
                GpsDetails.animalId = singleAnimal.animalId;
                gpstracking trackingEntity = JsonConvert.DeserializeObject<gpstracking>(JsonConvert.SerializeObject(GpsDetails));
                trackingEntity.createdAt = DateTime.Now;
                context.gpstrackings.Add(trackingEntity);
                try
                {
                    context.SaveChanges();
                    GPSTracking castedGPSTracking = JsonConvert.DeserializeObject<GPSTracking>(JsonConvert.SerializeObject(trackingEntity, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                    castedGPSTracking.message = successMsg;
                    log.Info("Successfully saved the details. ");
                    return castedGPSTracking;
                }
                catch (DbUpdateConcurrencyException Ex)
                {
                    Ex.Entries.Single().Reload();
                    context.SaveChanges();
                    GPSTracking castedGPSTracking = JsonConvert.DeserializeObject<GPSTracking>(JsonConvert.SerializeObject(trackingEntity, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                    castedGPSTracking.message = successMsg;
                    log.Error(Ex.Message + Ex.StackTrace);
                    return castedGPSTracking;
                }
                catch (Exception e)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", e.Message);
                    log.Error(e.Message + e.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.BadRequest);
                    
                }

            }
        }

       
        /// <summary>
        /// Lets the latest position of an animal
        /// </summary>
        /// <returns>Returns the list of instances of class GPSTRacking</returns>

        public static List <GPSTracking> GetLatestPositionOfAnimal()
        {
            List<GPSTracking> lstOfAnimsPos = new List<GPSTracking>();
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    string sqlQuery = String.Format("SELECT cat.id as catId,cat.categoryName,cat.colorIndication,t.trackingId,t.createdAt,t.animalId,t.latitude,t.longitude,anim.gpsDeviceId FROM gpstracking AS t INNER JOIN animals AS anim ON t.animalId = anim.animalId INNER JOIN category as cat on cat.id = anim.categoryId  INNER JOIN ( SELECT trackingId, animalId, MAX( createdAt ) as MaxDate FROM gpstracking GROUP BY animalId) AS gp ON t.animalId = gp.animalId AND t.createdAt = gp.MaxDate");
                    lstOfAnimsPos = context.Database.SqlQuery<GPSTracking>(sqlQuery).ToList<GPSTracking>();
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.NotFound);
                }
            }
            return lstOfAnimsPos;
        }     
        
    }
}