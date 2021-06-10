using AutoMapper;
using lab2.Data;
using lab2.Models;
using lab2.ViewModel.User_Expense;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace lab2.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UsersExpensesController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public UsersExpensesController(ApplicationDbContext context, ILogger<UsersExpensesController> logger, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> AssignExpense(NewUserExpenseRequest newRequest)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var expenseWithId = _context.Expense.Find(newRequest.ExpenseId);
            if (expenseWithId == null)
            {
                return BadRequest();
            }

            var userExpense = new UserExpense
            {
                ApplicationUser = user,
                Percent = newRequest.Percent,
                Expense = expenseWithId
            };

            _context.UsersExpenses.Add(userExpense);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = _context.UsersExpenses.Where(ue => ue.ApplicationUser.Id == user.Id).FirstOrDefault();
            var resultViewModel = _mapper.Map<ExpenseForUserResponse>(result);

            return Ok(resultViewModel);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserExpense(int id, PutUserExpeseRequest usrExp)
        {
            if (id != usrExp.Id)
            {
                return BadRequest();
            }
            var userExpense = _context.UsersExpenses.Find(usrExp.Id);

            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (userExpense.ApplicationUserId!=user.Id)
            {
                return Forbid();
            }

            userExpense.ExpenseId = usrExp.ExpenseId;
            userExpense.ApplicationUser = user;
            userExpense.Percent = usrExp.Percent;

            _context.Entry(userExpense).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UsersExpenses.Any(ue => ue.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var userExpense = await _context.UsersExpenses.FindAsync(id);
            if (userExpense == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (userExpense.ApplicationUserId != user.Id)
            {
                return Forbid();
            }
            _context.UsersExpenses.Remove(userExpense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}

