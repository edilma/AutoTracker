using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoTracker.Controllers
{
    public class MaintenanceController : Controller
    {

        private AutoTrackerDbContext context;
        public MaintenanceController(AutoTrackerDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }
        //Get where the user lands and sees the button
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(AddMaintenanceViewModel addMaintenanceViewModel)
        {
            return View();

        }
    }
}