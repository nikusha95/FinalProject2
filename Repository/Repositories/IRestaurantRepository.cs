using System.Linq.Expressions;
using Repository.Models;

namespace Repository.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant> GetByIdAsync(int id);
    Task<List<Restaurant>> GetAllAsync();
    void Update(Restaurant restaurant);
    Task AddAsync(Restaurant restaurant);

    Task<List<Restaurant>> GetWithFilterAsync(Expression<Func<Restaurant, bool>> expression = null);
    Task SaveAsync();
}