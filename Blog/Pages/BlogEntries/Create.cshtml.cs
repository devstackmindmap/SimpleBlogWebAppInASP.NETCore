using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog.Data;
using Blog.Models;

namespace Blog.Pages.BlogEntries
{
    public class CreateModel : PageModel
    {
        private readonly Blog.Data.BlogContext _context;

        public CreateModel(Blog.Data.BlogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BlogEntry BlogEntry { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BlogEntry == null || BlogEntry == null)
            {
                return Page();
            }

            _context.BlogEntry.Add(BlogEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
