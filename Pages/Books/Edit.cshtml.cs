﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dumitru_Delia_Lab2.Data;
using Dumitru_Delia_Lab2.Models;

namespace Dumitru_Delia_Lab2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Dumitru_Delia_Lab2.Data.Dumitru_Delia_Lab2Context _context;

        public EditModel(Dumitru_Delia_Lab2.Data.Dumitru_Delia_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            //var book =  await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            Book = await _context.Book
                    .Include(b => b.Publisher)
                    .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);
            if (Book == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Book);
            //Book = book;
            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID",
"FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var bookToUpdate = await _context.Book
            .Include(i => i.Publisher)
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Book>(
            bookToUpdate,
            "Book",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }
    

    /*private bool BookExists(int id)
        {
          return (_context.Book?.Any(e => e.ID == id)).GetValueOrDefault();
        }*/
    }
}
