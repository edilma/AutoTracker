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
using Microsoft.AspNetCore.Http;
using NHTSAVehicleData;
using NHTSAVehicleData.Models;

namespace AutoTracker.Controllers
{
    public class CarsController : Controller
    {

        private AutoTrackerDbContext context;
        private int userID;
        public CarsController(AutoTrackerDbContext dbContext)
        {
            context = dbContext;
           
        }

        //Here we show all the maintenance performed in the car
        public IActionResult Index(int id)
        {
            userID = HttpContext.Session.GetInt32("userID") ?? 0;

            Car car = context.Cars.Where(x => x.ID == id).FirstOrDefault();
            AddCarsViewModel addCarsViewModel = new AddCarsViewModel()
            {
                CarID = car.ID,
                Make = car.Make,
                Model = car.Model,
                UserID = this.userID,
                CurrentMiles = car.CurrentMiles,
                NextMaintenanceDays = car.NextMaintenanceDays,
                NextMaintenanceMiles = car.NextMaintenanceMiles,
                VinNumber = car.VinNumber,
                Year = car.Year
            };

            return View(addCarsViewModel);
        }

        [HttpPost]
        public IActionResult Index(AddCarsViewModel addCarsViewModel)
        {

            Car car = context.Cars.Where(x => x.ID == addCarsViewModel.CarID).FirstOrDefault();

            car.ID = addCarsViewModel.CarID;
            car.Make = addCarsViewModel.Make;
            car.Model = addCarsViewModel.Model;
            car.CurrentMiles = addCarsViewModel.CurrentMiles;
            car.NextMaintenanceDays = addCarsViewModel.NextMaintenanceDays;
            car.NextMaintenanceMiles = addCarsViewModel.NextMaintenanceMiles;
            car.VinNumber = addCarsViewModel.VinNumber;
            car.Year = addCarsViewModel.Year;
            context.SaveChanges();
            return Redirect("/Home/MainPage");
        }

        //Get where the user lands and sees the button
        public IActionResult Add()
        {
            AddCarsViewModel addCarsViewModel = new AddCarsViewModel();

            return View(addCarsViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCarsViewModel addCarsViewModel)
        {
            if (ModelState.IsValid)
            {
                userID = HttpContext.Session.GetInt32("userID") ?? 0;

                if (addCarsViewModel.VinNumber != null)
                {

                    // Vin API: https://github.com/writelinez/NHTSA-VehicleData
                    NHTSAClient nhtsaClient = new NHTSAClient();
                    VehicleDataResponse<VinDecodeResult> vinResult = await nhtsaClient.DecodeVinAsync(addCarsViewModel.VinNumber);
                    VinDecodeResult VinAPIResult = vinResult.Results.FirstOrDefault();

                    if (VinAPIResult != null)
                    {


                        Car car = new Car();
                        car.Make = VinAPIResult.Make;
                        car.Model = VinAPIResult.Model;
                        car.CurrentMiles = addCarsViewModel.CurrentMiles;
                        car.UserID = userID;
                        car.NextMaintenanceDays = 0;
                        car.NextMaintenanceMiles = 0;
                        car.VinNumber = addCarsViewModel.VinNumber;
                        car.Year = Int32.Parse(VinAPIResult.ModelYear);
                        context.Cars.Add(car);
                        context.SaveChanges();
                        return Redirect("/Cars/Index/" + car.ID);
                    }

                }
                else
                {
                    Car car = new Car();
                    car.Make = addCarsViewModel.Make;
                    car.Model = addCarsViewModel.Model;
                    car.CurrentMiles = addCarsViewModel.CurrentMiles;
                    car.UserID = userID;
                    car.NextMaintenanceDays = 0;
                    car.NextMaintenanceMiles = 0;
                    car.VinNumber = addCarsViewModel.VinNumber;
                    car.Year = addCarsViewModel.Year;
                    context.Cars.Add(car);
                    context.SaveChanges();
                    return Redirect("/Cars/Index/" + car.ID);

                }

            };
            return View(addCarsViewModel);

        }
        //Get action to make a report
       public IActionResult Display()
        {
            var cars = context.Cars;
            return View(cars);
        }

        public IActionResult History(int id)
        {
            Car myCar = context.Cars.Where(x => x.ID == id).FirstOrDefault();
            myCar.Maintenances = context.Maintenances.Where(x => x.CarID == id).ToList();
            foreach (var main in myCar.Maintenances)
            {
                main.MaintenanceType = context.MaintenanceTypes.Where(x => x.MaintenanceTypeID == main.MaintenanceTypeID).FirstOrDefault();
            }
            
            myCar.Mods = context.Mods.Where(x => x.CarID == id).ToList();

            return View(myCar);
        }
    }
}