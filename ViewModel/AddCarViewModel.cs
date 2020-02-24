using System.ComponentModel.DataAnnotations;
using AutoTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoTracker.ViewModels
{
    public class AddCarViewModel
    {
        public int CarID { get; set; }
        [Required]
        [Display(Name = "Your Car")]


        public int CarCategoryID { get; set; }
        public List<SelectListItem> CarTypes { get; set; }

        [Required(ErrorMessage = "Please enter a valid Vin")]
        [Display(Name = "Vin")]
        public string VinNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid make")]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter a valid model")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter a valid year")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter the current miles")]
        [Display(Name = "CurrentMiles")]
        public int CurrentMiles { get; set; }

        [Required(ErrorMessage = "Please enter the next maintenance miles")]
        [Display(Name = "NextMaintenanceMiles")]
        public int NextMaintenanceMiles { get; set; }

        [Required(ErrorMessage = "Please enter next maintenace day")]
        [Display(Name = "Next Maintenance day")]
        public int NextMaintenanceDays { get; set; }

        public AddCarViewModel()
        { }

        public AddCarViewModel(IEnumerable<MaintenanceType> CarCategories)
        {
            //Car = car;
            CarCategories = new List<SelectListItem>();

            foreach (CarCategory Category in CarCategories)
            {
                CarCategories.Add(new SelectListItem
                {
                    Value = Category.ID.ToString(),
                    Text = Category.Make
                });
            }
        }

    }
}