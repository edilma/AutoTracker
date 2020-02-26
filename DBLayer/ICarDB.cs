using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoTracker.Models;

namespace AutoTracker.DBLayer
{
    public interface ICarDB
    {
        List<Car> GetCars(int userId);
    }
}
