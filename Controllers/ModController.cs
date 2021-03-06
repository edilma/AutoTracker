﻿
using AutoTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoTracker.Models;
using AutoTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace AutoTracker.Controllers
{
    public class ModController : Controller
    {

        private AutoTrackerDbContext context;
        public ModController(AutoTrackerDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Mod> AllMod = context.Mods.ToList();
            return View(AllMod);
        }

        public IActionResult Add(int id)
        {
           AddModViewModel addModViewModel = new AddModViewModel();
            addModViewModel.CarID = id;
            Car myCar = context.Cars.Where(x => x.ID == id).FirstOrDefault();
            addModViewModel.CarName = myCar.Make + " " + myCar.Model + " " + myCar.Year;
            return View(addModViewModel);
            
        }
        [HttpPost]
        public IActionResult Add(AddModViewModel addModViewModel)
        {
            if (ModelState.IsValid) { 
               Mod newMod = new Mod()
                {
                    CarID = addModViewModel.CarID,
                    ModName = addModViewModel.ModName,
                    ModDescription = addModViewModel.ModDescription,
                    ModDate = addModViewModel.ModDate,
                    ModCost = addModViewModel.ModCost

                };
                context.Mods.Add(newMod);
                context.SaveChanges();
                //HttpContext.Session.SetInt32("userID", newUser.ID);


                return Redirect("/Home/MainPage");
            }
            else
            {
                return View();
            }

        }

    }
}