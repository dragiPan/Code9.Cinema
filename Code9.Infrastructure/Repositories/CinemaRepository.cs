using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Code9.Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext _dbContext;

        public CinemaRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cinema>> GetAllCinemas()
        {
            return await _dbContext.Cinemas.ToListAsync();
        }

        public async void AddCinema(Cinema cinema) 
        {
            this._dbContext.Add(cinema);
            await this._dbContext.SaveChangesAsync();
        }

        public async void UpdateCinema(Cinema cinema)
        {
            this._dbContext.Update(cinema);
            await this._dbContext.SaveChangesAsync();
        }
    }
}