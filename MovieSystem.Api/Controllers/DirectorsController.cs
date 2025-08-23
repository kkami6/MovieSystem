using Microsoft.AspNetCore.Mvc;
using MovieSystem.Services.Dtos.DirectorDtos;
using MovieSystem.Services.Interfaces;

namespace MovieSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController(IDirectorService directorService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var directors = await directorService.GetAll();
            return Ok(directors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var director = await directorService.GetById(id);
            if (director == null) return NotFound();
            return Ok(director);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DirectorCreateDto dto)
        {
            var created = await directorService.Create(dto);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DirectorUpdateDto dto)
        {
            var updated = await directorService.Update(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await directorService.Delete(id);
            return Ok();
        }
    }
}
