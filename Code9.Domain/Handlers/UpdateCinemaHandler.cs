using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code9.Domain.Commands;
using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;

namespace Code9.Domain.Handlers
{
    public class UpdateCinemaHandler : IRequestHandler<UpdateCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;
        public UpdateCinemaHandler(ICinemaRepository cinemaRepository) 
        {
            _cinemaRepository = cinemaRepository;  
        }
        public async Task<Cinema> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.GetCinemaById(request.CinemaId);

            cinema.Id = request.CinemaId;
            cinema.Name = request.Name;
            cinema.City = request.City;
            cinema.Street = request.Street;
            cinema.NumberOfAuditoriums = request.NumberofAuditoriums;
            return await _cinemaRepository.UpdateCinema(cinema);
        }
    }
}
