﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Car
    {
        public string VINcode { get; set; } = null!;

        public string Manufacture { get; set; } = null!;

        [Required]
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public double EngDisplacement { get; set; }

        public int YearOfProd { get; set; }

        public int Mileage { get; set; }

        public List<Invoice> Invoices { get; } = new List<Invoice>();
    }
}