using Mesimat_Sicom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mesimat_Sicom.Controllers
{
    public class SportShoeController : Controller
    {
        SportShoe[] sportShoes = new SportShoe[4]
        {
            new SportShoe(1, "Nike", "Air Force", 9, 100),
            new SportShoe(2, "Nike", "Air Max", 9, 250),
            new SportShoe(3, "Adids", "Superstar", 9, 90),
            new SportShoe(4, "Adidas", "Foam", 9, 200)
        };
        // GET: SportShoe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetShoeModel()
        {
            ViewBag.model = sportShoes[0].ModelName;
            return View();
        }

        public ActionResult GetShoe(int id)
        {
            foreach(SportShoe shoe in sportShoes)
            {
                if(shoe.Id == id)
                {
                    ViewBag.model = shoe.ModelName;
                    ViewBag.company = shoe.CompanyName;
                    ViewBag.size = shoe.Size;
                    ViewBag.price = shoe.Price;
                }
            }
            return View();
        }

        public ActionResult GetAllShoes()
        {
            return View(sportShoes);
        }
    }
}