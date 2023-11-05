using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dumitru_Delia_Lab2.Data;
using Dumitru_Delia_Lab2.Models;

namespace Dumitru_Delia_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Dumitru_Delia_Lab2.Data.Dumitru_Delia_Lab2Context _context;

        public IndexModel(Dumitru_Delia_Lab2.Data.Dumitru_Delia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
