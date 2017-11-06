using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingKart.Models;

namespace ShoppingKart.ViewModels
{
    public class CheckoutDetail
    {
        public string ItemName { get; set; }
        public float SinglePrice { get; set; }
        public float ItemsPrice { get; set; }
        public int ItemQuantity { get; set; }
        public int ProductId { get; set; }
        public Offer Offer { get; set; }
        public bool UsedOffer { get; set; }
        public float PriceBeforeDiscount { get; set; }

    }
}