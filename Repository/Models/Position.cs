using Microsoft.IdentityModel.Tokens;

namespace Repository.Models;

public class Position
{
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<Employee> Employees { get; set; }
}