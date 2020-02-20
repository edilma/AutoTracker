using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoTracker.Models;
using AutoTracker.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutoTracker.Controllers
{
    public class MaintenanceController : Controller
    {

        private AutoTrackerDbContext context;
        public MaintenanceController(AutoTrackerDbContext dbContext)
        {
            context = dbContext;
        }

        //Here we show all the maintenance performed in the car
        public IActionResult Index()
        {
            IList<Maintenance> AllMaintenances = context.Maintenances.ToList();
            return View(AllMaintenances);
        }
        //Get where the user lands and sees the button
        public IActionResult Add()
        {
            AddMaintenanceViewModel addMaintenanceViewModel = new AddMaintenanceViewModel();
            return View(addMaintenanceViewModel);

        }
        [HttpPost]
        public IActionResult Add(AddMaintenanceViewModel addMaintenanceViewModel)
        {
            if (ModelState.IsValid)
            {
                Maintenance newMaintenance = new Maintenance()
                {
                    MaintenacePerformedMiles = addMaintenanceViewModel.MaintenacePerformedMiles,
                    MaintenancePerformedDate = addMaintenanceViewModel.MaintenancePerformedDate,
                    MaintenanceCost = addMaintenanceViewModel.MaintenanceCost,
                    MaintenanceTypeID = addMaintenanceViewModel.MaintenanceTypeID
                };
                context.Maintenances.Add(newMaintenance);
                context.SaveChanges();
                return Redirect("/Maintenance/Index/" + newMaintenance.ID);
            };
            return View();

        }
    }
}