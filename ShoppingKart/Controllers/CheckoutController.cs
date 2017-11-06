using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingKart.Models;
using ShoppingKart.ViewModels;
using WebGrease.Css.Extensions;

namespace ShoppingKart.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Checkout page
        // Queries the Basket Table to get the products that
        // are stored for a specific session id
        public ActionResult Index()
        {
            var sessionId = HttpContext.Session.SessionID;

            var query =
                from b in _context.BasketOrders                
                join o in _context.Offers on b.ProductId equals o.ProductId into bo
                from o in bo.DefaultIfEmpty()
                where b.SessionId == sessionId
                select new CheckoutDetail()
                {
                    ItemName = b.Product.Name,
                    ProductId = b.ProductId,
                    ItemQuantity = b.Amount,
                    SinglePrice = b.Product.Price,
                    Offer = o           
                };

            var products = query.ToList();
            foreach (var item in products)
            {
                item.PriceBeforeDiscount = item.ItemQuantity * item.SinglePrice;

                if (item.Offer != null && item.ItemQuantity >= item.Offer.Number)
                {
                    var offerCount = item.ItemQuantity / item.Offer.Number;
                    var remainedItem = item.ItemQuantity % item.Offer.Number;
                    item.ItemsPrice = offerCount * item.Offer.OfferedPrice + remainedItem * item.SinglePrice;
                    item.UsedOffer = true;
                }
                else
                {
                    item.ItemsPrice = item.SinglePrice * item.ItemQuantity;
                    item.UsedOffer = false;
                }
            }

            return View(products);
        }

        // This method stores a specific product with its quantity number in 
        // Basket table for a specific session id
        [HttpPost]
        public ActionResult CalculateAmount(int productId)
        {
            var sessionId = HttpContext.Session.SessionID;

            var amount = 1;

            if (Request.Form.AllKeys.Contains("Amount"))
            {
                amount = Int32.Parse(Request.Form["Amount"]);
            }        

            var productInBasket = _context.BasketOrders
                .SingleOrDefault(m => m.ProductId == productId && m.SessionId == sessionId);

            if (productInBasket == null)
            {
                Basket newBabket = new Basket()
                {
                    ProductId = productId,
                    Amount = amount,
                    SessionId = sessionId
                };
                _context.BasketOrders.Add(newBabket);
            }
            else
            {
                productInBasket.Amount = productInBasket.Amount + amount;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Checkout");
        }

        // This method deletes one record from the Basket depending
        // on which product user has selected to be deleted
        [HttpPost]
        public ActionResult DeleteProductFromBasket(int productId)
        {
            var sessionId = HttpContext.Session.SessionID;
            var product =
                _context.BasketOrders.Find(productId, sessionId);

            if (product != null)
                 _context.BasketOrders.Remove(product);

            _context.SaveChanges();

            return RedirectToAction("Index", "Checkout");

        }


    }
}