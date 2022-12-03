namespace Repository.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int? PositionId { get; set; }
    public Position Position { get; set; }
}