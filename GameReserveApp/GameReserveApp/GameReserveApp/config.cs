using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReserveApp
{
    class config
    {
        public const string categoryUri = "CategoryService.svc/GetAllCategories";
        public const string deleteCategoryUri = "CategoryService.svc/DeleteCategory";
        public const string csvfilePath = "./CsvFile/File";
        public const string serverUrl = "http://localhost:50059/";
        public const double SALatitude = -30.5595;
        public const double SALongitude = 22.9375;
    }
}
