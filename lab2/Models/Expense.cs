using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public enum Types
    {
        food,
        utilities,
        transportation,
        outing,
        groceries,
        clothes,
        electronics,
        other,
    };
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(10)]
        public string Description { get; set; }

        [Range(10, Double.MaxValue)]
        public double Sum { get; set; }

        public DateTime Date { get; set; }

        [MinLength(3)]
        public string Location { get; set; }

        public string Currency { get; set; }

        public Types Type { get; set; }
    }
}
