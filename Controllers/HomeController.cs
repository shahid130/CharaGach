using Microsoft.AspNetCore.Mvc;
using CharaGach.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace CharaGach.Controllers
{
    public class HomeController : Controller
    {
        dbContext entity;

        public HomeController( dbContext db)
        {
            entity = db;
        }

        public IActionResult Index()
        {
            return View(entity.plants.ToList());
        }

        public IActionResult Products()
        {
                return View(entity.plants.ToList());
        }

        [HttpGet]
        public IActionResult AddCart(int id, CartModel cm)
        {
            if (Variable.authentication_users >0)
            {
                try
                {
                    cm.userID = Variable.authentication_users;
                    cm.plantID = id;
                    cm.plantAmount = 1;

                    entity.cart.Add(cm);
                    entity.SaveChanges();
                    return RedirectToAction("Products", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Already added";
                    Debug.WriteLine("Error: " + ex.Message);
                }
                return RedirectToAction("Products", "Home");
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }





            public async Task<IActionResult> SearchProducts(string searchString)
        {
            if (entity.plants == null)
            {
                return Problem("Entity set 'entity.plants'  is null.");
            }

            var plantts = from m in entity.plants select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                plantts = entity.plants.Where(s => s.plantName!.Contains(searchString));
            }

            return View(await plantts.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
