using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameReserveApp.ViewModels
{
    class CategoryView
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string colorIndication { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string message { get; set; }
    }
}
