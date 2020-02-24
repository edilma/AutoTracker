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
    public class CarController : Controller
    {

        private AutoTrackerDbContext context;
        public CarController(AutoTrackerDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Car> AllCars = context.Cars.ToList();
            return View(AllCars);
        }
   
        public IActionResult Add(int id)
        {

        }
        [HttpPost]
        public IActionResult Add(AddCarViewModel addCarViewModel)
        {
            if (ModelState.IsValid)
            {

                
                Car newCar = new Car()
                {
                    

                };
                context.Cars.Add(newCar);
                context.SaveChanges();
                return Redirect("/Home/MainPage");
            };
            return View();

        }
    }
}
