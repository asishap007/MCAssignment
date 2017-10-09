using GameReserveApp.Helper;
using GameReserveApp.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReserveApp.Repository
{
    class CategoryRepository
    {
        public static CategoryView[] GetAllCategories()
        {
            string categoryurl = config.serverUrl + config.categoryUri;
            string categoryListInJson = RequestClient.getRequest(categoryurl);
            CategoryView[] allCategories =  JObject.Parse(categoryListInJson)["GetAllCategoriesResult"].ToObject<CategoryView[]>();
            return allCategories;
        }

        public static CategoryView DeleteCategory(int categoryId)
        {
            string categoryurl = config.serverUrl + config.deleteCategoryUri + "/" +categoryId.ToString();
            string categoryListInJson = RequestClient.getRequest(categoryurl);
            CategoryView deletedCategory = JsonConvert.DeserializeObject<CategoryView>(categoryListInJson);
            return deletedCategory;
        }
    }
}
