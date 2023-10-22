using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sulea_Steliana_Lab2.Data;
using Sulea_Steliana_Lab2.Models;

namespace Sulea_Steliana_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Sulea_Steliana_Lab2.Data.Sulea_Steliana_Lab2Context _context;

        public DetailsModel(Sulea_Steliana_Lab2.Data.Sulea_Steliana_Lab2Context context)
        {
            _context = context;
        }

      public Book Book { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }

            return Page();
        }
    }
}
