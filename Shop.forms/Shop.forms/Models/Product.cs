﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.forms.Models
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public byte[] Picture { get; set; }
    }
}
