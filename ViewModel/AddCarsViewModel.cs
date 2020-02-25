using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTracker.ViewModels
{
    public class AddCarsViewModel
    {

        public int CarID { get; set; }
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Vin Required")]
        public string VinNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CurrentMiles { get; set; }
        public int NextMaintenanceMiles { get; set; }
        public int NextMaintenanceDays { get; set; }
    }
}
