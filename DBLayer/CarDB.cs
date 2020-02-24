using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTracker.Data;
using AutoTracker.ViewModels;
using AutoTracker.Models;

namespace AutoTracker.DBLayer
{

    public class CarDB : ICarDB
    {
        private AutoTrackerDbContext context;

        public  CarDB(AutoTrackerDbContext _context) {

            context = _context;
        }

        public  List<Car> GetCars(int userId)
        {
            List<Car> cars = context.Cars.Where(z => z.User.ID == userId).ToList();
            return cars;
           // return new List<MainPageViewModel>();

        }
    }
}
