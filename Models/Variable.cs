using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
namespace CharaGach.Models
{
    public class Variable : PageModel
    {
        public static int authentication_users { get; set; }
        public static int plantId_var { get; set; }
        public static string userEmail_var { get; set; }

        public static HashSet<int> CartID_Set = new HashSet<int>();

        public static int Counter { get; set; }

      

    }
}


