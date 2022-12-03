using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repositories;
using Repository.ViewModels;

namespace Repository.Controllers;

[ApiController]
[Route("restaurant")]
public class RestaurantController : ControllerBase
{
    //private readonly IRestaurantRepository _repository;
    private readonly IGenericRepository<Restaurant> _restaurantRepository;
    public RestaurantController(IGenericRepository<Restaurant> restaurantRepository /*IRestaurantRepository repository*/)
    {
        _restaurantRepository = restaurantRepository;
        //_repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<RestaurantModel>> GetAllAsync()
    {
        var restaurants = await _restaurantRepository.GetAllAsync();

        var rViewModel = restaurants.Select(x => new RestaurantModel
        {
            Address = x.Address,
            Name = x.Name,
            Phone = x.Phone
        });

        return rViewModel;
    }

    [HttpPost]
    public async Task AddRestaurant(RestaurantModel restaurant)
    {
        await _restaurantRepository.AddAsync(new Restaurant
        {
            Address = restaurant.Address,
            Name = restaurant.Name,
            Phone = restaurant.Phone
        });
        await _restaurantRepository.SaveAsync();
    }
    
}