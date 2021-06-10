using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Order
    {
        public int ID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
