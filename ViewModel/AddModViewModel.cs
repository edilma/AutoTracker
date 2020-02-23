using System.ComponentModel.DataAnnotations;
using AutoTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoTracker.ViewModels
{
    public class AddModViewModel
    {
        public int CarID { get; set; }
        [Display(Name = "Modification Name")]
        [Required]
        public string ModName { get; set; }
        [Display(Name = "Modification Description")]
        public string ModDescription { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Modification Date")]
        public DateTime ModDate { get; set; }
        [Display(Name = "Modification Cost")]
        [Range(0, 9999.99)]
        public double ModCost { get; set; }

        public AddModViewModel() { }
    }
}
