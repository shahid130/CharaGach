using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CharaGach.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.Data.SqlClient;


namespace CharaGach.Controllers
{
    public class AuthenticationController : Controller
    {
        dbContext entity;
        public AuthenticationController(dbContext db)
        {
            entity = db;
        }
        public IActionResult UserProfile()
        {
            return View(entity.userInfo.ToList());
            //return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            Variable.authentication_users = 0;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signin()
        {
            if (Variable.authentication_users == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserProfile", "Authentication");
            }
        }

        [HttpPost]
        public IActionResult Signin(Users s)
        {
            try
            {
                
                var userVarification = entity.userInfo.Any(u => u.userEmail.Equals(s.userEmail) && u.userPassword.Equals(s.userPassword));
                

                if (userVarification)
                {
                    ViewBag.profile = "Profile";
                    Variable.authentication_users = 1;
                    Variable.userEmail_var = s.userEmail;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var adminVarification = entity.adminInfo.Any(u => u.adminEmail.Equals(s.userEmail) && u.adminPassword.Equals(s.userPassword));

                    if (adminVarification)
                    {
                        Variable.authentication_users = 2;
                        Variable.userEmail_var = s.userEmail;
                        return RedirectToAction("AdminHome", "Admin");
                    }
                    else
                    {
                        ViewBag.Loginfailed = "User not found or Password mismatch";
                    }
                }
            }
            catch
            {
                ViewBag.Message = "Fill Up this form carefully";
            }
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Users s)
        {
            try
            {
                s.userNumber = "N/A";
                s.userAdress = "N/A";

                entity.userInfo.Add(s);
                entity.SaveChanges();
                return RedirectToAction("Signin", "Authentication");
            }
            catch (Exception ex)
            {
                if(s.userPassword.Length<6)
                {
                    ViewBag.Message = "Minimum Password Length 8 Character";
                }
                else
                    ViewBag.Message= "Fill Up this form carefully";
            }
            return View();
        }

        
        
    }
}
