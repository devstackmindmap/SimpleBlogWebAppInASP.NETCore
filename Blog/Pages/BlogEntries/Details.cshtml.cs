using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Pages.BlogEntries
{
    public class DetailsModel : PageModel
    {
        private readonly Blog.Data.BlogContext _context;

        public DetailsModel(Blog.Data.BlogContext context)
        {
            _context = context;
        }

      public BlogEntry BlogEntry { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BlogEntry == null)
            {
                return NotFound();
            }

            var blogentry = await _context.BlogEntry.FirstOrDefaultAsync(m => m.Id == id);
            if (blogentry == null)
            {
                return NotFound();
            }
            else 
            {
                BlogEntry = blogentry;
            }
            return Page();
        }
    }
}
