using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.ViewModel.User_Expense
{
    public class PutUserExpeseRequest
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public double Percent { get; set; }
    }
}
