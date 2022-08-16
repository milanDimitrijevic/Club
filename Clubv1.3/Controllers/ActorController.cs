using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clubv1._3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ClubDbContext _dbContext;

        public ActorController(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("Actors")]
        [HttpGet]
        public async Task<ActionResult> Actors()
        {
            try
            {
                return Ok(await _dbContext.Actors.Select(p =>
                new
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    DeceaseDate = p.DeceaseDate
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddActor")]
        [HttpPost]
        public async Task<ActionResult> AddActor([FromBody] Actor actor)
        {
            if (string.IsNullOrWhiteSpace(actor.Name) || actor.Name.Length > 50)
            {
                return BadRequest("Wrong name!");
            }
            try
            {
                _dbContext.Actors.Add(actor);
                await _dbContext.SaveChangesAsync();
                return Ok($"Actor has been added with Id: {actor.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ChangeActor")]
        [HttpPut]
        public async Task<ActionResult> ChangeActor([FromBody] Actor actor)
        {
            try
            {
                _dbContext.Actors.Update(actor);
                await _dbContext.SaveChangesAsync();
                return Ok($"Successfully changed actor with ID: {actor.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DeleteActor/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Wrong id.");
            }
            try
            {
                var actor = await _dbContext.Actors.FindAsync(id);
                string name = actor.Name;
                _dbContext.Actors.Remove(actor);
                await _dbContext.SaveChangesAsync();
                return Ok($"Successfully deleted actor with name:{name}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}