using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantDbContext _dbContext;

    public RestaurantRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        return await _dbContext.Restaurants.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Restaurant>> GetAllAsync()
    {
        return await _dbContext.Restaurants.ToListAsync();
    }

    public void Update(Restaurant restaurant)
    {
        _dbContext.Restaurants.Update(restaurant);
        _dbContext.Entry(restaurant).State = EntityState.Modified;
    }

    public async Task AddAsync(Restaurant restaurant)
    {
        await _dbContext.Restaurants.AddAsync(restaurant);
        _dbContext.Entry(restaurant).State = EntityState.Added;
    }

    public async Task<List<Restaurant>> GetWithFilterAsync(Expression<Func<Restaurant, bool>> expression = null)
    {
        if (expression != null)
        {
            return await _dbContext.Restaurants.Where(expression).ToListAsync();
        }

        return await _dbContext.Restaurants.ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}