using CharaGach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;

namespace CharaGach.Controllers
{
    public class AdminController : Controller
    {
        dbContext entity;
        IWebHostEnvironment _environment;
        public AdminController(dbContext db, IWebHostEnvironment environment)
        {
            entity = db;
            _environment = environment;
        }


        public IActionResult AddPlant()
        {
            if(Variable.authentication_users == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }

        [HttpPost]
        public IActionResult AddPlant(PlantImage plant)
        {
            try
            {
                string fileName = "";
                if (plant.photo!=null)
                {
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "CharaGachImages");
                    fileName = Guid.NewGuid().ToString() + "_" + plant.photo.FileName;

                    string filePath = Path.Combine(uploadFolder, fileName);


                    plant.photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                else
                {
                    ViewBag.Message = "Image upload failed";
                }
                

                Plants p = new Plants
                {
                    plantName = plant.plantName,
                    plantDetails = plant.plantDetails,
                    plantType = plant.plantType,
                    plantPrice = plant.plantPrice,
                    plantQuantity = plant.plantQuantity,
                    plantSize = plant.plantSize,
                    plantImagePath = fileName
                };

                entity.plants.Add(p);
                entity.SaveChanges();
                ViewBag.Message = "Added Successfully";
            }
            catch
            {
                ViewBag.Message = "Add Plants info carefully";
            }
            return View();
        }
        public IActionResult AdminHome()
        {
            if (Variable.authentication_users == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }
        public IActionResult UpdatePlant()
        {
            if (Variable.authentication_users == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }
        public IActionResult NewOrder()
        {
            if (Variable.authentication_users == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }
        public IActionResult DeliveredOrder()
        {
            if (Variable.authentication_users == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }

        public IActionResult AdminProfile()
        {
                return View(entity.adminInfo.ToList());
        }
    }
}
