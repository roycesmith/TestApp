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

        public IList<Todo> Todo { get; set; } = default!;

        public async Task OnGetAsync()
        {
            string sqlStatement = @"UPDATE Todo
                                SET Outstanding = cast(julianday('now')- julianday(Modified) as int)";
            _context.Database.ExecuteSqlRaw(sqlStatement);
            Todo = await _context.Todo
                .Include(t => t.Person)
                .ToListAsync();
            // sort based on outstanding descending
            Todo = Todo.OrderByDescending(t => t.Outstanding).ToList();
            //Todo = Todo.OrderBy(t => t.Outstanding).ToList();

            // make the outstanding field the time in days from last modified
            // foreach (var todo in Todo)
            // {
            //     todo.Outstanding = (int)(DateTime.Now - todo.Modified).TotalDays;
            // }
        }
    }
}
