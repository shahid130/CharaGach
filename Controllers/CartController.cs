using CharaGach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        [HttpGet]
        public IActionResult CartView()
        {
            var plantsData = entity.plants.ToList();
            var cartData = entity.cart.ToList();

            var viewModel = new PlantsView
            {
                plantsData = plantsData
            };

            var cartViewModel = new CartView
            {
                cartsData = cartData
            };

            return View(Tuple.Create(viewModel, cartViewModel));
        }

        [HttpGet]
        public IActionResult IncreaseQuantity(int id, CartModel cm)
        {
            
            var plant = entity.cart.FirstOrDefault(p => p.plantID == id);

            if (plant != null)
            {
                plant.plantAmount = plant.plantAmount + 1;
                entity.SaveChanges();
            }

            return RedirectToAction("CartView", "Cart");
        }

        [HttpGet]
        public IActionResult DecreaseQuantity(int id, CartModel cm)
        {

            var plant = entity.cart.FirstOrDefault(p => p.plantID == id);

            if(plant != null)
            {
                if(plant.plantAmount > 1)
                {
                    plant.plantAmount = plant.plantAmount - 1;
                    entity.SaveChanges();
                }
            }
            return RedirectToAction("CartView", "Cart");
        }

        public IActionResult PlantDetails(int id)
        {
            Variable.plantId_var =  id;
            return View(entity.plants.ToList());
        }
        
        public IActionResult DeletePlant(int id, CartModel cm)
        {
            var plantToDelete = entity.cart.FirstOrDefault(p => p.plantID == id);
            if (plantToDelete != null)
            {
                entity.cart.Remove(plantToDelete);
                entity.SaveChanges();
            }
            return RedirectToAction("CartView", "Cart");
        }

        public IActionResult PlaceOrder()
        {

            if (Variable.authentication_users > 0)
            {
                var PlantsData = entity.plants.ToList();
                var CartData = entity.cart.ToList();
                var UsersData = entity.userInfo.ToList();

                var plantViewModel = new PlantsView
                {
                    plantsData = PlantsData
                };

                var cartViewModel = new CartView
                {
                    cartsData = CartData
                };

                var userViewModel = new UserView
                {
                    usersData = UsersData
                };
                return View(Tuple.Create(plantViewModel, cartViewModel, userViewModel));
            }
            else
            {
                return RedirectToAction("Signin", "Authentication");
            }
        }

        public IActionResult ConfirmedOrder(Order o, UpdateUsers u)
        {
            if(Variable.TotalPrice ==0) {
				return RedirectToAction("Products", "Home");
			}

            try
            {


                var userItem = entity.userInfo.FirstOrDefault(p => p.userID == Variable.authentication_users);
                if (userItem != null)
                {
                    if (u.userAdress != null && u.userNumber != null)
                    {
                        userItem.userNumber = u.userNumber;
                        userItem.userAdress = u.userAdress;
                        entity.SaveChanges();
                    }
                    else
                    {
						return RedirectToAction("PlaceOrder", "Cart");
                    }
                }

                var cartItems = entity.cart.Where(p => p.userID == Variable.authentication_users).ToList();

                if (cartItems.Any())
                {
                    foreach (var cartItem in cartItems)
                    {
                        var newOrder = new Order
                        {
                            userID = cartItem.userID,
                            plantID = cartItem.plantID,
                            plantAmount = cartItem.plantAmount,
                        };

                        entity.orders.Add(newOrder);
                    }

                    entity.SaveChanges();

                    entity.cart.RemoveRange(cartItems);
                    entity.SaveChanges();
                }
				
				return View();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

            return View();
        }

    }
}
