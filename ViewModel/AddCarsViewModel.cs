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
        
        [Display(Name = "Vin Required")]
        public string VinNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NextMaintenanceMiles { get; set; }
        public int NextMaintenanceDays { get; set; }
        public int Year { get; set; }
        [Required]
        public int CurrentMiles { get; set; } 
        public AddCarsViewModel()
        {

        }
        public AddCarsViewModel(string vinNumber, string make, string model, int year, int currentMiles)
        {
        NextMaintenanceMiles = currentMiles + 5000;
        NextMaintenanceDays = Convert.ToInt32(DateTime.Now.AddDays(30));

        }

    }
}
