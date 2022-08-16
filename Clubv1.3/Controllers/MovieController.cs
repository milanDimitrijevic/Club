using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Clubv1._3.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clubv1._3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ClubDbContext _dbContext;

        public MovieController(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("Movies")]
        [HttpGet]
        public async Task<ActionResult> Movies()
        {
            try
            {
                return Ok(await _dbContext.Movies.Select(p =>
                new
                {
                    Id = p.Id,
                    Title = p.Title,
                    Producer = p.Producer
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddMovie/{title}/{genre}/{producer}")]
        [HttpGet]
        public async Task<ActionResult> AddMovie(string title, GenreType genre, string producer, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Insert title.");
            }
            if (string.IsNullOrWhiteSpace(producer) || producer.Length > 50)
            {
                return BadRequest("Insert producers name.");
            }
            try
            {
                Movie movie = new Movie
                {
                    Title = title,
                    Genre = genre,
                    Producer = producer,
                    ReleaseDate = releaseDate
                };

                _dbContext.Movies.Add(movie);
                await _dbContext.SaveChangesAsync();
                return Ok("New movie has been added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ChangeMovie")]
        [HttpPut]
        public async Task<ActionResult> ChangeMovie([FromBody] Movie movie)
        {
            try
            {
                _dbContext.Movies.Update(movie);
                await _dbContext.SaveChangesAsync();
                return Ok("Movie information has been changed!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DeleteMovie")]
        [HttpDelete]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            if (id == 0)
            {
                return BadRequest("Wrong id.");
            }
            try
            {
                var movie = await _dbContext.Movies.FindAsync(id);
                string title = movie.Title;
                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
                return Ok($"Movie with title:{title} has been successfully deleted.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Movie AddCds(int id, int amount);
        [Route("AddCds")]
        [HttpPut]
        public async Task<ActionResult> AddCds(int id, int amount)
        {
            try
            {
               Movie movie = await _dbContext.Movies.FindAsync(id);
                _dbContext.Movies.Update(movie);
                await _dbContext.SaveChangesAsync();
                return Ok("Amount of Cds has been successfully changed!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddActorToMovie")]
        [HttpPut]
        public async Task<ActionResult> AddActorToMovie(int id, string name)
        {
            try
            {
                Movie movie = await _dbContext.Movies.FindAsync(id);
                Actor actor = await _dbContext.Actors.FindAsync(name);
                _dbContext.Movies.Update(movie);
                await _dbContext.SaveChangesAsync();
                return Ok("Actor has been added.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
