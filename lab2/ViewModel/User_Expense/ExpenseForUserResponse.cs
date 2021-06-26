using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.ViewModel.User_Expense
{
    public class ExpenseForUserResponse
    {
        public int Id { get; set; }
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public ExpensesViewModel Expense { get; set; }
        public double Percent { get; set; }

    }
}
