using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code9.Domain.Interfaces;
using Code9Domain.Commands;
using MediatR;

namespace Code9Domain.Handlers
{
    public class DeleteCinemaHandler : IRequestHandler<DeleteCinemaCommand, bool>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public DeleteCinemaHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<bool> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.DeleteCinema(request.Id);
        }
    }
}
