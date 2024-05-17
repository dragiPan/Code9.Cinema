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

        public async Task<Cinema> AddCinema(Cinema cinema)
        {
            _dbContext.Add(cinema);
            await _dbContext.SaveChangesAsync();
            return cinema;
        }

        public async Task<Cinema> UpdateCinema(Cinema cinema)
        {
            _dbContext.Update(cinema);
            await _dbContext.SaveChangesAsync();
            return cinema;
        }

        public async Task<Cinema> GetCinemaById(Guid cinemaId)
        {
            return await _dbContext.Cinemas.FirstOrDefaultAsync(c => c.Id == cinemaId);
        }

        public async Task<bool> DeleteCinema(int id)
        {
            var cinema = await _dbContext.Cinemas.FindAsync(id);
            if (cinema == null)
            {
                return false;
            }

            _dbContext.Cinemas.Remove(cinema);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}