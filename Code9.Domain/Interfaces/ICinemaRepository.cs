﻿using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();

        public Task<Cinema> AddCinema(Cinema cinema);

        public Task<Cinema> UpdateCinema(Cinema cinema);
        public Task<Cinema> GetCinemaById(Guid cinemaId);
    }
}
