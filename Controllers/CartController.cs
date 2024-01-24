using CharaGach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace CharaGach.Controllers
{
    public class CartController : Controller
    {
        dbContext entity;
        public CartController(dbContext db)
        {
            entity = db;
        }

        public IActionResult CartView()
        {

            return View(entity.plants.ToList());
        }

        
        public IActionResult okk()
        {
            return View(entity.plants.ToList());
        }

        public IActionResult UserProfile()
        {
            return View(entity.userInfo.ToList());
        }

        public IActionResult PlantDetails(int id)
        {
            Variable.plantId_var =  id;
            Debug.WriteLine("aaaaaaaaaaa" + Variable.plantId_var);
            return View(entity.plants.ToList());
        }

       /* public IActionResult PlantDetails(int id)
        {
            Debug.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            var item = entity.plants.FirstOrDefault(i => i.plantID == id);
            Debug.WriteLine(item.plantDetails);
           // if (item == null)
            //{
               // return NotFound();
            //}
            return View(entity.plants.ToList().IndexOf);
        }*/

        public IActionResult PlaceOrder()
        {
            if (Variable.authentication_users == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }
    }
}
