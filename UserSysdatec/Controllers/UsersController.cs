using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserSysdatec.Abstractions;
using UserSysdatec.Data;
using UserSysdatec.Models;
using UserSysdatec.Models.Dto;
using static System.Net.Mime.MediaTypeNames;

namespace UserSysdatec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly Helpercs _helper;

        public UsersController(AppDbContext context, Helpercs helpercs)
        {
            _context = context;
            _helper = helpercs;
        }

        // Obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // Obtener un usuario por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // Crear un nuevo usuario
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            HashedPassword hash = _helper.Hash(user.Password);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                user.Password = hash.Password;
                user.Sal = hash.Salt;
                user.Token = _helper.GenerateJwtToken(user.Email, "salt");
                user.Status = true;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
