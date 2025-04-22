using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Pages.CRUD_Department
{
    public class DetailsModel : PageModel
    {
        private readonly TestApp.Data.TestAppContext _context;

        public DetailsModel(TestApp.Data.TestAppContext context)
        {
            _context = context;
        }

        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FirstOrDefaultAsync(m => m.Id == id);

            if (department is not null)
            {
                Department = department;

                return Page();
            }

            return NotFound();
        }
    }
}
