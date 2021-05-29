using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.ViewModel
{
    public class ExpensesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        public double Sum { get; set; }
        public Types Type { get; set; }

        public DateTime Date { get; set; }
    }
}
