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
        public int CarID { get; set; }
        [Required]
        [Display(Name = "Maintenance Service")]
        //public string SelectMaintenace { get; set; }
        
        public int MaintenanceTypeID { get; set; }
        public string CarName { get; set; }
        public List<SelectListItem> MaintenanceTypes { get; set; }
        
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

        public AddMaintenanceViewModel(IEnumerable<MaintenanceType> _maintenanceTypes)
        {
           //Car = car;
             MaintenanceTypes = new List<SelectListItem>();
            
            foreach (MaintenanceType maintenanceType in _maintenanceTypes)
            {
                MaintenanceTypes.Add(new SelectListItem {
                    Value = maintenanceType.MaintenanceTypeID.ToString(),
                        Text = maintenanceType.Description
                    });
            }
        }

    }
}