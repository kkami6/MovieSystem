using Microsoft.AspNetCore.Mvc;
using MovieSystem.Services.Dtos.RatingDtos;
using MovieSystem.Services.Interfaces;

namespace MovieSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController(IRatingService ratingService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ratings = await ratingService.GetAll();
            return Ok(ratings);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await ratingService.GetById(id);
            if (rating == null) return NotFound();
            return Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RatingCreateDto dto)
        {
            var created = await ratingService.Create(dto);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RatingUpdateDto dto)
        {
            var updated = await ratingService.Update(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await ratingService.Delete(id);
            return Ok();
        }

        // 🔹 Custom endpoints
        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var ratings = await ratingService.GetByUser(userId);
            return Ok(ratings);
        }

        [HttpGet("movie/{movieId:int}")]
        public async Task<IActionResult> GetByMovie(int movieId)
        {
            var ratings = await ratingService.GetByMovie(movieId);
            return Ok(ratings);
        }
    }
}
