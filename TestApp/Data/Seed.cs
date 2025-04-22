using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using TestApp.Models;

namespace TestApp.Data;

public class Seed
{
    // This method will be called at runtime to seed the database with initial data.


    // 
    public static void Initialize(TestApp.Data.TestAppContext context)
    {

        // Look for any movies.
        if (context.Department.Any())
        {
            //return;   // DB has been seeded
            //Delete all from the database
            context.Database.ExecuteSqlRaw("DELETE FROM Person");
            context.Database.ExecuteSqlRaw("DELETE FROM Department");
            context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name='Person'");
            context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name='Department'");
            context.Database.ExecuteSqlRaw("DELETE FROM Todo");
            context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name='Todo'");
            context.SaveChanges();
            // could also just return instead of deleting
            // return;
            string hello = "Hello";
        }

        context.Department.AddRange(
            new Department
            {
                Name = "Design"
            },
            new Department
            {
                Name = "Media"
            },
            new Department
            {
                Name = "Art"
            }
        );

        context.SaveChanges();

        context.Person.AddRange(
            new Person
            {
                FirstName = "Bill",
                LastName = "Smith",
                DepartmentId = 2
            },
            new Person
            {
                FirstName = "Sam",
                LastName = "Jones",
                DepartmentId = 2
            },
            new Person
            {
                FirstName = "Jane",
                LastName = "Thompson",
                DepartmentId = 1
            },
            new Person
            {
                FirstName = "Julie",
                LastName = "Johnstone",
                DepartmentId = 1
            },
            new Person
            {
                FirstName = "Debbie",
                LastName = "Flintstone",
                DepartmentId = 3
            },
            new Person
            {
                FirstName = "Rob",
                LastName = "Robinson",
                DepartmentId = 3
            }
        );
        context.SaveChanges();
        // Add some test data to the database
        // for the Todo table.
        // This is just test data and can be removed later.
        // refactor following code and use fields from Models.Todo.cs
        context.Todo.AddRange(
            new Todo
            {
                Name = "Year 12 IA1",
                IsComplete = false,
                Modified = DateTime.UtcNow.AddDays(7),
                PersonId = context.Person.First(p => p.FirstName == "Bill" && p.LastName == "Smith").Id
            },
            new Todo
            {
                Name = "Year 10 Test",
                IsComplete = true,
                Modified = DateTime.UtcNow.AddDays(-7),
                PersonId = context.Person.First(p => p.FirstName == "Bill" && p.LastName == "Smith").Id
            },
            new Todo
            {
                Name = "Year 11 FIA1",
                IsComplete = false,
                Modified = DateTime.UtcNow.AddDays(14),
                PersonId = context.Person.First(p => p.FirstName == "Sam" && p.LastName == "Jones").Id
            },
            new Todo
            {
                Name = "Year 10 Test",
                IsComplete = true,
                Modified = DateTime.UtcNow.AddDays(-7),
                PersonId = context.Person.First(p => p.FirstName == "Sam" && p.LastName == "Jones").Id
            },
            new Todo
            {
                Name = "Year 12 IA2",
                IsComplete = false,
                Modified = DateTime.UtcNow.AddDays(21),
                PersonId = context.Person.First(p => p.FirstName == "Jane" && p.LastName == "Thompson").Id
            },
            new Todo
            {
                Name = "Year 10 Test",
                IsComplete = true,
                Modified = DateTime.UtcNow.AddDays(-14),
                PersonId = context.Person.First(p => p.FirstName == "Jane" && p.LastName == "Thompson").Id
            },
            new Todo
            {
                Name = "Year 11 FIA1",
                IsComplete = false,
                Modified = DateTime.UtcNow.AddDays(1),
                PersonId = context.Person.First(p => p.FirstName == "Julie" && p.LastName == "Johnstone").Id
            },
            new Todo
            {
                Name = "Year 10 Test",
                IsComplete = false,
                Modified = DateTime.UtcNow.AddDays(-14),
                PersonId = context.Person.First(p => p.FirstName == "Julie" && p.LastName == "Johnstone").Id
            },
            new Todo
            {
                Name = "Year 11 IA1",
                IsComplete = false,
                Modified = DateTime.UtcNow.AddDays(-7),
                PersonId = context.Person.First(p => p.FirstName == "Debbie" && p.LastName == "Flintstone").Id
            },
            new Todo
            {
                Name = "Year 10 Test",
                IsComplete = true,
                Modified = DateTime.UtcNow.AddDays(-7),
                PersonId = context.Person.First(p => p.FirstName == "Debbie" && p.LastName == "Flintstone").Id
            },
            new Todo
            {
                Name = "Year 12 IA1",
                IsComplete = true,
                Modified = DateTime.UtcNow.AddDays(-14),
                PersonId = context.Person.First(p => p.FirstName == "Rob" && p.LastName == "Robinson").Id
            },
            new Todo
            {
                Name = "Year 10 Test",
                IsComplete = true,
                Modified = DateTime.UtcNow.AddDays(-7),
                PersonId = context.Person.First(p => p.FirstName == "Rob" && p.LastName == "Robinson").Id
            }
        );
        context.SaveChanges();
    }
}
