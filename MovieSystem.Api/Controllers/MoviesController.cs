using Microsoft.AspNetCore.Mvc;
using MovieSystem.Services.Dtos.MovieDtos;
using MovieSystem.Services.Interfaces;

namespace MovieSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController(IMovieService movieService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await movieService.GetById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieCreateDto dto)
        {
            var created = await movieService.Create(dto);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MovieUpdateDto dto)
        {
            var updated = await movieService.Update(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await movieService.Delete(id);
            return Ok();
        }

        // 🔹 Custom endpoints
        [HttpGet("director/{directorId:int}")]
        public async Task<IActionResult> GetByDirectorWithAverageRating(int directorId)
        {
            var movies = await movieService.GetByDirectorWithAverageRating(directorId);
            return Ok(movies);
        }

        [HttpGet("top/{count:int}")]
        public async Task<IActionResult> GetTopRated(int count)
        {
            var movies = await movieService.GetTopRated(count);
            return Ok(movies);
        }
    }
}
