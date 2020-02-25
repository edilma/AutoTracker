using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoTracker.Models;
using Microsoft.AspNetCore.Http;
using AutoTracker.Data;
using AutoTracker.ViewModels;
using AutoTracker.DBLayer;


namespace AutoTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private AutoTrackerDbContext context;
        private ICarDB cardb;


        public HomeController(ILogger<HomeController> logger, AutoTrackerDbContext dbContext, ICarDB _carDB)
        {
            _logger = logger;
             context = dbContext;
            cardb = _carDB;

        }

        public IActionResult Index()
        {
            return View();
        }

        // Action for the main system page 
        public IActionResult MainPage()
        {
            var userID = HttpContext.Session.GetInt32("userID");
            MainPageViewModel mainPageViewModel = new MainPageViewModel();
           //  mainPageViewModel.Cars = context.Cars.Where(x => x.UserID == userID).ToList();

            
            mainPageViewModel.Cars = cardb.GetCars(userID.Value);
            mainPageViewModel.Maintenances = context.Maintenances.ToList();
            mainPageViewModel.Mods= context.Mods.ToList();
            mainPageViewModel.MaintenanceTypes = context.MaintenanceTypes.ToList();

            return View(mainPageViewModel);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
