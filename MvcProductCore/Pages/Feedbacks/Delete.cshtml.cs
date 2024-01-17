using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcProductCore.Models;

namespace MvcProductCore.Pages.Feedbacks
{
    public class DeleteModel : PageModel
    {
        private readonly MvcProductCore.Models.AdventureWorksLt2016Context _context;

        public DeleteModel(MvcProductCore.Models.AdventureWorksLt2016Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FirstOrDefaultAsync(m => m.id == id);

            if (feedback == null)
            {
                return NotFound();
            }
            else 
            {
                Feedback = feedback;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }
            var feedback = await _context.Feedback.FindAsync(id);

            if (feedback != null)
            {
                Feedback = feedback;
                _context.Feedback.Remove(Feedback);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
