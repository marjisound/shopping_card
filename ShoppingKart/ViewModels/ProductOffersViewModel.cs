using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingKart.Models;

namespace ShoppingKart.ViewModels
{
    public class ProductOffersViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float Price { get; set; }
        public Offer Offer { get; set; }
        public int Amount { get; set; }
    }
}