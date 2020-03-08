using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTracker.ViewModels
{
    public class AddCarLongViewModel:AddCarsViewModel
    {
        /*
        public int CarID { get; set; }
        public int UserID { get; set; }
        
        [Display(Name = "Vin Required")]
        public string VinNumber { get; set; }
        public string Make { get; set; }
        */
        [Required]
        public string Model { get; set; }
        public int NextMaintenanceMiles { get; set; }
        public int NextMaintenanceDays { get; set; }
        public int Year { get; set; }
        public int CurrentMiles { get; set; }
        public AddCarLongViewModel()
        {

        }
        public AddCarLongViewModel(string vinNumber, string make, string model, int year, int currentMiles)
        {
            NextMaintenanceMiles = currentMiles + 5000;
            NextMaintenanceDays = Convert.ToInt32(DateTime.Now.AddDays(30));

        }

    }
}
