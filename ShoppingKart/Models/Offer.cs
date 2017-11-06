using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingKart.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; }

        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public int ProductId { get; set; }
        [Required]
        public short Number { get; set; }
        [Required]
        public float OfferedPrice { get; set; }
    }
}