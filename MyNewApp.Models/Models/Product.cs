﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewApp.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Author { get; set; }
        [Required]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
