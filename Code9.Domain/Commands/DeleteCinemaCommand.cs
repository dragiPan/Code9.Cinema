﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Code9Domain.Commands
{
    public class DeleteCinemaCommand(int id) : IRequest<bool>
    {
        public int Id { get; set; } = id;
    }
}
