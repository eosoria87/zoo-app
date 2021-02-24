using ZooApp.Application.Common.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZooApp.Application.Animal.Queries;
using ZooApp.Application.Animal.Queries.GetAnimalWithFilterAndPagination;
using ZooApp.Application.Animal.Commands.CreateAnimal;
using ZooApp.Application.Animal.Queries.GetAnimalWithPagination;
using ZooApp.Application.Animal.Commands.UpdateAnimal;
using ZooApp.Application.Animal.Commands.DeleteAnimal;

namespace ZooApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AnimalController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<AnimalDto>>> GetAnimalWithPagination(GetAnimalWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        [Route("getByFilterAndPagination")]
        public async Task<ActionResult<PaginatedList<AnimalFilterDto>>> GetAnimalWithFilterAndPagination(GetAnimalWithFilterAndPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAnimalCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAnimalCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAnimalCommand { Id = id });

            return NoContent();
        }
    }
}
