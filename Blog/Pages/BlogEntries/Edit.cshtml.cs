using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Pages.BlogEntries
{
    public class EditModel : PageModel
    {
        private readonly Blog.Data.BlogContext _context;

        public EditModel(Blog.Data.BlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogEntry BlogEntry { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BlogEntry == null)
            {
                return NotFound();
            }

            var blogentry =  await _context.BlogEntry.FirstOrDefaultAsync(m => m.Id == id);
            if (blogentry == null)
            {
                return NotFound();
            }
            BlogEntry = blogentry;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BlogEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogEntryExists(BlogEntry.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BlogEntryExists(int id)
        {
          return (_context.BlogEntry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
