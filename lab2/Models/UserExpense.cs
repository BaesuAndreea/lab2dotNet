using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class UserExpense
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }
        public double Percent { get; set; }

    }
}