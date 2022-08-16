using clubv1._3.Database;
using Clubv1._3.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clubv1._3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ClubDbContext _dbContext;

        public UserController(ClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("Users")]
        [HttpGet]
        public async Task<ActionResult> Users()
        {
            try
            {
                return Ok(await _dbContext.Users.Select(p =>
                new
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email
                }).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            if(string.IsNullOrWhiteSpace(user.FirstName) || user.FirstName.Length > 50)
            {
                return BadRequest("Unable to add name.");
            }
            if(string.IsNullOrWhiteSpace(user.LastName) || user.LastName.Length > 50)
            {
                return BadRequest("Unable to add last name.");
            }
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return Ok($"User has been added with Id: {user.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("ChangeUser")]
        [HttpPut]
        public async Task<ActionResult> ChangeUser([FromBody] User user)
        {
            try
            {
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return Ok($"Successfully changed user with Id: {user.Id}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("DeleteUser/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return BadRequest("Wrong id.");
            }
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                string email = user.Email;
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return Ok($"Successfully deleted user with email:{email}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //User rentMovie(int id, int movieId);
        [Route("rentMovie")]
        [HttpPost]
        public async Task<ActionResult> rentMovie(int id, int movieId)
        {
            try
            {
                User user = await _dbContext.Users.FindAsync(id);
                Movie movie = await _dbContext.Movies.FindAsync(movieId);
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return Ok("Movie has been added for rent.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("rentSerie")]
        [HttpPost]
        public async Task<ActionResult> rentSerie(int id, int serieId)
        {
            try
            {
                User user = await _dbContext.Users.FindAsync(id);
                Serie serie = await _dbContext.Series.FindAsync(serieId);
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return Ok("Movie has been added for rent.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
