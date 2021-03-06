using AutoMapper;
using lab2.Models;
using lab2.ViewModel;
using lab2.ViewModel.User_Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, ExpensesViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Expense, ExpensesWithCommentsViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
            CreateMap<UserExpense, ExpenseForUserResponse>().ReverseMap();

        }
    }
}
