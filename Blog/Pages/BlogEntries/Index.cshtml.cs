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
    public class IndexModel : PageModel
    {
        private readonly Blog.Data.BlogContext _context;

        public IndexModel(Blog.Data.BlogContext context)
        {
            _context = context;
        }

        public IList<BlogEntry> BlogEntry { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BlogEntry != null)
            {
                BlogEntry = await _context.BlogEntry.ToListAsync();
            }
        }
    }
}
