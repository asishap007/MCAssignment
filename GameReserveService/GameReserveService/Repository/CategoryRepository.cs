using GameReserveService.ErrorHandler;
using Newtonsoft.Json;
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
    /// Adds, deletes, updates the category details
    /// </summary>
    public class CategoryRepository
    {
        //Configures log4net in class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        public CategoryRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Obtain details of the whole available categories from the database
        /// </summary>
        /// <returns>Returns list of Category class</returns>
        public static List<Category> categoryList()
        {
            List<Category> lstCategory = new List<Category>();
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    //Fetches the details of all categories present in the database
                    var categories = from p in context.categories select p;
                    //Iterates through each singlecategory in category list of entity class and converting it into instances of class Category of type datacontract
                    foreach (category singleCategory in categories)
                    {
                        Category cat = JsonConvert.DeserializeObject<Category>(JsonConvert.SerializeObject(singleCategory));
                        lstCategory.Add(cat);
                    }
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.NotFound);
                  
                }

            }
            return lstCategory;
        }
        /// <summary>
        /// Obtains details of a single category from database
        /// </summary>
        /// <param name="categoryId">Unique Id corresponding to each category</param>
        /// <returns>Instance of category class containing all details  of a particular category</returns>
        public static Category GetSingleCategory(string categoryId)
        {
            Int32 catId = Convert.ToInt32(categoryId);
            Category cat;
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    //Fetches the details of a particular category using categoryId
                    var singleCategory = (from p in context.categories where p.id == catId select p).FirstOrDefault();
                    //Converts the Json string to an instance of class Category of type datacontract
                    cat = JsonConvert.DeserializeObject<Category>(JsonConvert.SerializeObject(singleCategory));
                    log.Info("Obtained the details of all categories");
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.BadRequest);                   
                }

            }
            return cat;
        }
        /// <summary>
        /// Creates a new category in database
        /// </summary>
        /// <param name="categoryDetails">Instance of category class containing all details of the new category to be added </param>
        /// <returns>Instance of category class after saving details to the database</returns>
        public static Category CreateNewCategory(Category categoryDetails)
        {
            string successMsg = "Created sucessfully";
            using (game_reserveEntities context = new game_reserveEntities())
            {
                //Converts the details of new category from  class of type datacontract to an entity class
                category categoryEntity = JsonConvert.DeserializeObject<category>(JsonConvert.SerializeObject(categoryDetails));
                context.categories.Add(categoryEntity);
                try
                {
                    //Saves details to database
                    context.SaveChanges();
                    categoryDetails.id = categoryEntity.id;
                    categoryDetails.message = successMsg;
                    log.Info("Created new category");
                    //Returns the instance of class Category of type datacontract, including id and  success message
                    return categoryDetails;
                    
                }
                catch (DbUpdateConcurrencyException Ex)
                {
                    //Takes the one and only (Single) entity from the DbUpdateConcurrencyException.
                    //Entries that could not be saved to the database
                    Ex.Entries.Single().Reload();
                    //Saves details to database
                    context.SaveChanges();
                    categoryDetails.id = categoryEntity.id;                   
                    categoryDetails.message = successMsg;
                    log.Error(Ex.Message + Ex.StackTrace);
                    //Returns the instance ofclass Category of type datacontract,  including id and  success message
                    return categoryDetails;
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
        /// Updates the details of a particular category in the databse
        /// </summary>
        /// <param name="categoryDetails">Instance of category class containing all details of the category to be updated </param>
        /// <returns>Instance of category class after saving details to the database</returns>
        public static Category UpdateSingleCategory(Category catgoryDetails)
        {
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    //Fetches details of the category to be updated from database to an  instance of entity class category using id of the category to be updated.
                    category singleCategory = (from p in context.categories where p.id == catgoryDetails.id select p).FirstOrDefault<category>();
                    singleCategory.categoryName = catgoryDetails.categoryName;
                    singleCategory.colorIndication = catgoryDetails.colorIndication;
                    context.SaveChanges();
                    catgoryDetails.message = "Updated Successfully";
                    log.Info("Updated the details of : " + catgoryDetails.categoryName);
                    //Returns the instance of class Category of type datacontract with success message
                    return catgoryDetails;
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.BadRequest);                   
                }

            }
        }

        /// <summary>
        /// Deletes the details of a particular category in the database
        /// </summary>
        /// <param name="categoryId">Unique Id corresponding to each category</param>
        /// <returns>Instance of Category class containing the details of the category</returns>
        public static Category DeleteCategory(string categoryId)
        {
            Int32 catId = Convert.ToInt32(categoryId);
            using (game_reserveEntities context = new game_reserveEntities())
            {
                try
                {
                    //Fetches details of the category to be deleted from database to an  instance of entity class category using id of the category to be deleted 
                    category singleCategory = (from p in context.categories where p.id == catId select p).FirstOrDefault<category>();
                   //Removes the details from the database
                    context.categories.Remove(singleCategory);
                    //Saves the instance of Dbcontext
                    context.SaveChanges();
                    Category deletedCategory = JsonConvert.DeserializeObject<Category>(JsonConvert.SerializeObject(singleCategory));
                    deletedCategory.message = "Deleted successfully.";
                    log.Info("Deleted the details of : " + deletedCategory.categoryName);
                    //Returns the instance of class Category of type datacontract with success message
                    return deletedCategory;
                }
                catch (Exception ex)
                {
                    ServiceErrorHandler customError = new ServiceErrorHandler("DB error", ex.Message);
                    log.Error(ex.Message + ex.StackTrace);
                    throw new WebFaultException<ServiceErrorHandler>(customError, HttpStatusCode.NotFound);                   
                }

            }
        }
        

    }
}