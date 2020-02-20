using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTracker.ViewModel
{
    public class AddCarViewModel
    {
        [Display(Name = "VIN Number")]
        // put a regex code here [RegularExpression(@"^[A-HJ-NPR-Z0-9]{17}$",
         //ErrorMessage = "Number is incorrect")]
        public string VinNumber { get; }
        public string Make { get; }
        public string Model { get; }
       
        [Required(ErrorMessage = "Year cannot be empty")]
        [RegularExpression(@"^[0-9]{4}$",
        ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Year Make")]
        public int Year { get; }

        public int CurrentMiles { get; set; }

        public AddCarViewModel()
        { }
    }
}
