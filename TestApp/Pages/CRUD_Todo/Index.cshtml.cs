using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Pages.CRUD_Todo
{
    public class IndexModel : PageModel
    {
        private readonly TestApp.Data.TestAppContext _context;

        public IndexModel(TestApp.Data.TestAppContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Todo = await _context.Todo
                .Include(t => t.Person).ToListAsync();
        }
    }
}
