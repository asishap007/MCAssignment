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
    /// Adds, deletes and updates the details of each animals in different categories.
    /// </summary>
    public class AnimalRepository
    {
         //Configures log4net in class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        public AnimalRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        /// <summary>
        /// Obtains the list of animals configured, from the database
        /// </summary>
        /// <returns>List of instances of class Animal of type datacontract</returns>
        public static List<Animal> AnimalList()
        {
            List<Animal> lstAnimal = new List<Animal>();
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    //Fetchss the details of all animals configured from the database
                    lstAnimal = context.Database.SqlQuery<Animal>("SELECT animals.categoryId,animals.animalId,animals.gpsDeviceId, animals.createdAt, category.categoryName FROM animals INNER JOIN category on animals.categoryId = category.id order by createdAt").ToList<Animal>();
                    log.Info("Obtains the details of all saved animals");
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.NotFound);                  
                }
            }
            //Returns the List of instances of class Animal
            return lstAnimal;
        }

       
        /// <summary>
        /// Adds new animal to database
        /// </summary>
        /// <param name="animalDetails">instance of class Animal of type datacontract</param>
        /// <returns></returns>
        public static Animal AddNewAnimal(Animal animalDetails)
        {
            string successMsg = "Created sucessfully";
            using (game_reserveEntities context = new game_reserveEntities())
            {
                //Converts the details of animal from instance of class Animal to an instance of entity class animal 
                animal animalEntity = JsonConvert.DeserializeObject<animal>(JsonConvert.SerializeObject(animalDetails));
                animalEntity.createdAt = DateTime.Now;
                context.animals.Add(animalEntity);
                try
                {
                    //Saves the details of the new animal to database
                    context.SaveChanges();
                    Animal castedAnimal = JsonConvert.DeserializeObject<Animal>(JsonConvert.SerializeObject(animalEntity, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                    castedAnimal.message = successMsg;
                    log.Info("The details of new animal is saved");
                    return castedAnimal;
                }
                catch (DbUpdateConcurrencyException Ex)
                {
                    //Takes the one and only (Single) entity from the DbUpdateConcurrencyException.
                    //Entries that could not be saved to the database
                    Ex.Entries.Single().Reload();
                    //Saves the details to the database
                    context.SaveChanges();
                    Animal castedAnimal = JsonConvert.DeserializeObject<Animal>(JsonConvert.SerializeObject(animalEntity, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                    castedAnimal.message = successMsg;
                    log.Error(Ex.Message + Ex.StackTrace);
                    return castedAnimal;
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
        /// Updates the details of new animal in database.
        /// </summary>
        /// <param name="animalDetails">Instance of class Animal.</param>
        /// <returns>Instance of class Animal.</returns>
        public static Animal UpdateAnimal(Animal animalDetails)
        {
            string successMsg = "Updated sucessfully";
            using (game_reserveEntities context = new game_reserveEntities())
            {
                //Fetches the details of the animal to be updated to an instance of an entity class animal.
                animal singleAnimal = (from p in context.animals where p.animalId == animalDetails.animalId select p).FirstOrDefault<animal>();
                singleAnimal.categoryId = animalDetails.categoryId;
                singleAnimal.gpsDeviceId = animalDetails.gpsDeviceId;
                try
                {
                    //Saves the details to database context
                    context.SaveChanges();
                    Animal castedAnimal = JsonConvert.DeserializeObject<Animal>(JsonConvert.SerializeObject(singleAnimal, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                    castedAnimal.message = successMsg;
                    log.Info("Successfully updated the details of animal with Id : " + castedAnimal.animalId + " of type: " + castedAnimal.categoryName);
                    return castedAnimal;
                }
                catch (DbUpdateConcurrencyException Ex)
                {
                    Ex.Entries.Single().Reload();
                    context.SaveChanges();
                    animalDetails.message = successMsg;
                    Animal castedAnimal = JsonConvert.DeserializeObject<Animal>(JsonConvert.SerializeObject(animalDetails, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                    log.Error(Ex.Message + Ex.StackTrace);
                    return castedAnimal;
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
        /// Deletes the details of a particular animal from database
        /// </summary>
        /// <param name="animalId">Unique id corresponding to each animal</param>
        /// <returns>An instance of class Animal</returns>
        public static Animal DeleteAnimal(string animalId)
        {
            Int32 animId = Convert.ToInt32(animalId);
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    //Fetches the details of the particular animal to be deleted from database using the id of animal and 
                    //saves to an instance of an entity class animal.
                    animal singleAnimal = (from p in context.animals where p.animalId == animId select p).FirstOrDefault<animal>();
                    //Removes the details of animal from database context.
                    context.animals.Remove(singleAnimal);
                    //Saves the details in database.
                    context.SaveChanges();
                    Animal deletedAnimal = JsonConvert.DeserializeObject<Animal>(JsonConvert.SerializeObject(singleAnimal, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                    deletedAnimal.message = "Deleted successfully.";
                    log.Info("Successfully deleted the details of animal with Id :"+ deletedAnimal.animalId +" of category : "+deletedAnimal.categoryName);
                    //Returns an instance of class Animal with message.
                    return deletedAnimal;
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.NotFound);                   
                }

            }
        }

        /// <summary>
        /// Obtains the total counnt of animals by category from database.
        /// </summary>
        /// <param name="endDate">Ending date for the period</param>
        /// <param name="fromDate">starting date of the period</param>
        /// <returns> Returns list of instances of class AninalCategory</returns>
        public static List<AnimalCategory> GetTotalCountOfAnimalsByCategory(string endDate, string fromDate)
        {
            //string frmDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //string edDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ;
            List<AnimalCategory> lstOfAnims = new List<AnimalCategory>();
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    //Fetches the details of all animals between the starting and ending period.
                    string sqlQuery = String.Format("SELECT category.id, category.colorIndication,category.categoryName, COUNT(*) as totalAnimals FROM animals INNER JOIN category ON category.id = animals.categoryId where DATE(animals.createdAt) >= '{0}' and DATE(animals.createdAt) <= '{1}' GROUP BY category.id", fromDate,endDate);
                    lstOfAnims = context.Database.SqlQuery<AnimalCategory>(sqlQuery).ToList<AnimalCategory>();
                    log.Info("Obtained the details of all animals from : "+fromDate+" to : "+endDate);
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.NotFound);                  
                }

            }
            return lstOfAnims;
        }

        
        

    }
}