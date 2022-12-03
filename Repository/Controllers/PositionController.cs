using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repositories;
using Repository.ViewModels;

namespace Repository.Controllers;

[ApiController]
[Route("position")]
public class PositionController : ControllerBase
{
    private readonly IGenericRepository<Position> _positionRepository;

    public PositionController(IGenericRepository<Position> positionRepository)
    {
        _positionRepository = positionRepository;
    }

    [HttpPost]
    public async Task AddPositionAsync(PositionModel model)
    {
        await _positionRepository.AddAsync(new Position
        {
            Title = model.Title
        });
        await _positionRepository.SaveAsync();
    }
}