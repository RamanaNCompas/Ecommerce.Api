﻿using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Product
{
    public class DeleteImageCommandModel : IRequest
    {
        public Guid Id { get; set; }

        public DeleteImageCommandModel(Guid id)
        {
            Id = id;
        }
    }
}
