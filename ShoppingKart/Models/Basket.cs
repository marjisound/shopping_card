using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ShoppingKart.Models
{
    public class Basket
    {

        public Product Product { get; set; }

        [Required]
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        public string SessionId { get; set; }
    }
}