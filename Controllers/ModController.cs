
using AutoTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoTracker.Models;
using AutoTracker.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(AddModViewModel addModViewModel)
        {
            if (ModelState.IsValid)
            {
                Mod newMod = new Mod()
                {
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