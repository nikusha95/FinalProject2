using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories;
using Repository.ViewModels;

namespace Repository.Controllers;

[ApiController]
[Route("employee")]
public class EmployeeController : ControllerBase
{
    private readonly IGenericRepository<Employee> _employeeRepository;
    private readonly IGenericRepository<Position> _positionRepository;

    public EmployeeController(IGenericRepository<Employee> employeeRepository,
        IGenericRepository<Position> positionRepository)
    {
        _employeeRepository = employeeRepository;
        _positionRepository = positionRepository;
    }

    [HttpGet("v1/employees")]
    public async Task<IEnumerable<EmployeeModel>> GetAllEmployeeWithPosition()
    {
        List<EmployeeModel> employeeModels = new();
        string positionTitle = null;

        var employees = await _employeeRepository.GetAllAsync();
        foreach (var employee in employees)
        {
            if (employee.PositionId != null)
            {
                var position = await _positionRepository.GetByIdAsync((int)employee.PositionId);
                if (position != null)
                {
                    positionTitle = position.Title;
                }
            }

            employeeModels.Add(new EmployeeModel
            {
                Name = employee.Name,
                Address = employee.Address,
                Phone = employee.Phone,
                Position = positionTitle
            });
        }

        return employees.Select(x => new EmployeeModel
        {
            Address = x.Address,
            Name = x.Name,
            Phone = x.Phone,
            Position = x.Position?.Title
        });
    }

    [HttpGet("v2/employees")]
    public async Task<IEnumerable<EmployeeModel>> GetAllEmployeeWithPositionV2()
    {
        List<EmployeeModel> employeeModels = new();
        string positionTitle = null;
        Expression<Func<Employee, object>> includes = exp => exp.Position;

        var employees = await _employeeRepository.GetAllAsync(null, new[] { includes });
        
        return employees.Select(x => new EmployeeModel
        {
            Address = x.Address,
            Name = x.Name,
            Phone = x.Phone,
            Position = x.Position?.Title
        });
    }
}