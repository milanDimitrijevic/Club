using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clubv1._3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly ClubDbContext _dbContext;

        public SerieController(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("Serie")]
        [HttpGet]
        public async Task<ActionResult> Serie()
        {
            try
            {
                return Ok(await _dbContext.Series.Select(p =>
                new
                {
                    Id = p.Id,
                    Title = p.Title,
                    Genre = p.Genre,
                    Seasons = p.Seasons,
                    Episodes = p.Episodes,
                    Producer = p.Producer
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddSerie/{title}/{genre}/{seasons}/{episodes}")]
        [HttpPost]
        public async Task<ActionResult> AddSerie(string title, GenreType genre, int seasons, int episodes, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Insert title.");
            }
            if (episodes <= 0)
            {
                return BadRequest("Insert how many episodes there are in serie.");
            }
            try
            {
                Serie serie = new Serie
                {
                    Title = title,
                    Genre = genre,
                    Seasons = seasons,
                    Episodes = episodes,
                    ReleaseDate = releaseDate
                };
                _dbContext.Series.Add(serie);
                await _dbContext.SaveChangesAsync();
                return Ok("New serie has been added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ChangeSerie")]
        [HttpPut]
        public async Task<ActionResult> ChangeSerie([FromBody] Serie serie)
        {
            /* if (serie.Id < 0)
             {
                 return BadRequest("Wrong id.");
             }      */
            try
            {
                _dbContext.Series.Update(serie);
                await _dbContext.SaveChangesAsync();
                return Ok("Successfully changed serie!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DeleteSerie")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSerie(int id)
        {
            if (id == 0)
            {
                return BadRequest("Wrong id.");
            }
            try
            {
                var serie = await _dbContext.Series.FindAsync(id);
                string title = serie.Title;
                _dbContext.Series.Remove(serie);
                await _dbContext.SaveChangesAsync();
                return Ok($"Serie with title:{title} has been successfully deleted.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddCds")]
        [HttpPut]
        public async Task<ActionResult> AddCds(int id, int amount)
        {
            try
            {
                Serie serie = await _dbContext.Series.FindAsync(id);
                _dbContext.Series.Update(serie);
                await _dbContext.SaveChangesAsync();
                return Ok("Amount of Cds has been successfully changed!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddActorToMovie")]
        [HttpPut]
        public async Task<ActionResult> AddActorToSerie(int id, string name)
        {
            try
            {
                Serie serie = await _dbContext.Series.FindAsync(id);
                Actor actor = await _dbContext.Actors.FindAsync(name);
                _dbContext.Series.Update(serie);
                await _dbContext.SaveChangesAsync();
                return Ok("Actor has been added.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
