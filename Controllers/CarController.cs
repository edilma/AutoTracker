using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoTracker.Data;
using AutoTracker.ViewModel;
using AutoTracker.Models;

namespace AutoTracker.Controllers
{
    public class CarController : Controller
    {
        private AutoTrackerDbContext context;
        public CarController(AutoTrackerDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        //The landing page after the user is logged in.  Now she can add a car
        public IActionResult Add()
        {
            return View();


        }
        //Action POST when the user tries to register
        [HttpPost]
        public IActionResult Add(AddCarViewModel addCarViewModel)
        {
            if (ModelState.IsValid)
            {
                Car newCar = new Car()
                {
                    //VinNumber = addCarViewModel.VinNumber,
                    //Make = addCarViewModel.Make,
                    //Model = addCarViewModel.Model,
                    //Year = addCarViewModel.Year,
                    CurrentMiles = addCarViewModel.CurrentMiles,
                    //NextMaintenanceMiles = addCarViewModel.NextMaintenanceMiles,
                    //NextMaintenanceDays = addCarViewModel.NextMaintenanceDays

                };
                context.Cars.Add(newCar);
                context.SaveChanges();
                //HttpContext.Session.SetInt32("userID", newUser.ID);


                return Redirect("/Home/MainPage");//if user is validated send to the  Main Page
            }
            else
            {
                return View();
            }

        }
    }
}