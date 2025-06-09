using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Models;
using TestApp.Data;


namespace TestApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly TestApp.Data.TestAppContext _context;

    public IndexModel(ILogger<IndexModel> logger, TestApp.Data.TestAppContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IList<Todo> Todo { get; set; } = default!;
    public void OnGet()
    {
        Todo = _context.Todo.ToList();
        if (_context.Todo.Count() == 0)
        {
            // Seed the database with initial data
            Seed.Initialize(_context);
            Todo = _context.Todo.ToList();
        }
    }
}
