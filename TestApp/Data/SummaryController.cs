using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Models;
namespace TestApp.Data;

[ApiController]
[Route("api/[controller]")]
public class SummaryController : ControllerBase
{
    private readonly TestApp.Data.TestAppContext _context;
    private System.Data.DataTable dt = new System.Data.DataTable();

    public SummaryController(TestApp.Data.TestAppContext context)
    {
        _context = context;
    }
    public IList<Summary> Summary { get; set; } = new List<Summary>();
    // GET: api/summary
    [HttpGet]
    public IActionResult GetSummary()
    {   // this statement brings back a table with 3 columns using SQL only. We need to load it using a different mechanism
        // such as the DBConnection and then read each record into our Model Summary
        string sqlStatement = @"SELECT Person.FirstName, Person.LastName, Count(Person.Id) as Total FROM Todo
                                INNER JOIN Person on Person.Id = Todo.PersonId
                                INNER JOIN Department on Department.Id= Person.DepartmentId
                                group by Person.Id";
        // Execute the SQL statement and get the result into an iList of type Summary

        using var connection = _context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = sqlStatement;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Summary.Add(new Summary
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Total = Convert.ToInt32(reader["Total"])
                    });
                }
            }
        }
        connection.Close();
        return Ok(Summary);
    }
}
