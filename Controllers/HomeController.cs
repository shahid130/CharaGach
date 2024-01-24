using Microsoft.AspNetCore.Mvc;
using CharaGach.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        /* public IActionResult Products(int id)
         {

             Variable.plantId_var = id;
             Variable.CartID_Set.Add(id);
             return View(entity.plants.ToList());
         }*/

        public IActionResult Products(int id)
        {

            Variable.plantId_var = id;
            Variable.CartID_Set.Add(id);
            return View(entity.plants.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
