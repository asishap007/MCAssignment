using GameReserveService.ErrorHandler;
using GameReserveService.Helper;
using GameReserveService.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameReserveService
{
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Service to get all animal categories.
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            return CategoryRepository.categoryList();
        }

        /// <summary>
        /// Service to get a single animal category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Category GetCategory(string categoryId)
        {
            return CategoryRepository.GetSingleCategory(categoryId);
        }
        /// <summary>
        /// Service to save a category.
        /// </summary>
        /// <param name="categoryDetails"></param>
        /// <returns></returns>
        public Category SaveCategory(Category categoryDetails)
        {
            return CategoryRepository.CreateNewCategory(categoryDetails);
        }

        /// <summary>
        /// Service to update animal category.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public Category UpdateCategory(Category cat)
        {
            return CategoryRepository.UpdateSingleCategory(cat);
        }
        /// <summary>
        /// Service to delete an animal category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Category DeleteCategory(string categoryId)
        {
            return CategoryRepository.DeleteCategory(categoryId);
        }


    }
}
