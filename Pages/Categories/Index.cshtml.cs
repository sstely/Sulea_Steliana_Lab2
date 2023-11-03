using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sulea_Steliana_Lab2.Data;
using Sulea_Steliana_Lab2.Models;
using Sulea_Steliana_Lab2.Models.ViewModels;

namespace Sulea_Steliana_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Sulea_Steliana_Lab2.Data.Sulea_Steliana_Lab2Context _context;

        public IndexModel(Sulea_Steliana_Lab2.Data.Sulea_Steliana_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookCategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories).ThenInclude(b => b.Book).ThenInclude(c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;
            }
        }
    }
}
