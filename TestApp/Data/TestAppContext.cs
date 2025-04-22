using TestApp.Models;
using Microsoft.EntityFrameworkCore;
namespace TestApp.Data;

public class TestAppContext : DbContext
{
    public TestAppContext(DbContextOptions<TestAppContext> options)
    : base(options)
    {
    }
    public DbSet<Person> Person => Set<Person>();
    public DbSet<Todo> Todo => Set<Todo>();
    public DbSet<Department> Department => Set<Department>();
}
