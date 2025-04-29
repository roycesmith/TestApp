using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TestApp.Data;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TestApp.Data.TestAppContext _context;
    public TodoController(TestApp.Data.TestAppContext context)
    {
        _context = context;
    }
    // GET: api/todo
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        // connect with the context
        var Todo = _context.Todo.ToList();

        return new string[] { Todo.Count().ToString(), Todo.Count(t => t.IsComplete).ToString() };
    }
    // GET: api/todo/5
    // return the todo item with the given id
    [HttpGet("{id}")]
    public ActionResult<Todo> GetTodoById(int id)
    {
        // find all the todo and include person
        var todo = _context.Todo
            .Include(t => t.Person)
            .Include(t => t.Person.Department)

            .FirstOrDefault(t => t.Id == id);

        if (todo == null)
        {
            return NotFound();
        }
        return todo;
    }
}
