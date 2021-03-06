﻿using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Commands.Models.Product;

namespace Streetwood.API.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ImagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("{id}/{isMain}")]
        public async Task<IActionResult> Post(IFormFile file, [FromRoute] int id, [FromRoute] bool isMain)
        {
            if (file == null)
            {
                return BadRequest("Missing file");
            }

            await mediator.Send(new AddProductImageCommandModel(id, file, isMain));
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteImageCommandModel(id));
            return Accepted();
        }
    }
}