﻿using System.ComponentModel.DataAnnotations;

namespace CharaGach.Models
{
    public class CartModel
    {
        [Key]
        public int cartID { get; set; }
        public int userID { get; set; }
        public int plantID { get; set; }
        public int plantAmount { get; set; }
    }
}
