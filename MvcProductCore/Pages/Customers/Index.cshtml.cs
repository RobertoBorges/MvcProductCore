using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcProductCore.Models;

namespace MvcProductCore.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly MvcProductCore.Models.AdventureWorksLt2016Context _context;

        public IndexModel(MvcProductCore.Models.AdventureWorksLt2016Context context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
