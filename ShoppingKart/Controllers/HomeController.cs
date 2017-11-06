using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using ShoppingKart.Models;
using ShoppingKart.ViewModels;

namespace ShoppingKart.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {

            var query =
                from p in _context.Products
                join o in _context.Offers on p.Id equals o.ProductId into po
                from o in po.DefaultIfEmpty()
                select new ProductOffersViewModel()
                {
                    Name = p.Name,
                    Id = p.Id,
                    Price = p.Price,
                    Offer = o,
                    Amount = 1
                };

            return View(query.ToList());
        }
    }
}