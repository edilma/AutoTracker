using System.ComponentModel.DataAnnotations;
using AutoTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoTracker.ViewModels
{
    public class AddMaintenanceViewModel
    {
        [Required]
        [Display(Name = "Maintenance Service")]
        //public string SelectMaintenace { get; set; }
        
        public int MaintenanceTypeID { get; set; }
        public IEnumerable<SelectListItem> maintenanceTypes { get; set; }
        
        [Required (ErrorMessage = "Please enter a valid number of miles")]
        [Display(Name = "Miles in Odometer")]
        public int MaintenacePerformedMiles { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Maintenance")]
        public DateTime MaintenancePerformedDate { get; set; }
        
        [Display(Name = "Maintenance Cost")]
        [Range(0, 9999.99)]
        public double MaintenanceCost { get; set; }


        public AddMaintenanceViewModel()
        { }

        public AddMaintenanceViewModel(IEnumerable<MaintenanceType> maintenanceTypes)
        {
           //Car = car;
            List<SelectListItem> MaintenanceTypes = new List<SelectListItem>();
            
            foreach (MaintenanceType maintenanceType in maintenanceTypes)
            {
                MaintenanceTypes.Add(new SelectListItem {
                    Value = maintenanceType.MaintenanceTypeID.ToString(),
                        Text = maintenanceType.Description
                    });
            }
        }

    }
}