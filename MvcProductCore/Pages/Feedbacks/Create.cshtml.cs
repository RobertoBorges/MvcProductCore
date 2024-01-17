using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcProductCore.Models;
using MvcProductCore.Services;

namespace MvcProductCore.Pages.Feedbacks
{
    public class CreateModel : PageModel
    {
        private readonly ICosmosDbService _context;

        public CreateModel(ICosmosDbService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Feedback.id = Guid.NewGuid().ToString();            
            await _context.AddItemAsync(Feedback);

            return RedirectToPage("./Index");
        }
    }
}
