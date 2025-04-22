using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Pages.CRUD_Todo
{
    public class CreateModel : PageModel
    {
        private readonly TestApp.Data.TestAppContext _context;

        public CreateModel(TestApp.Data.TestAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todo.Add(Todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
