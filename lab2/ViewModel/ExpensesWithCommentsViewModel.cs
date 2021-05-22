using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.ViewModel
{
    public class ExpensesWithCommentsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Sum { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Currency { get; set; }

        public Types Type { get; set; }
        
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
