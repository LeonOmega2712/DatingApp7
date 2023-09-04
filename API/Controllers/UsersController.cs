using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// [ApiController]
// [Route("api/[controller]")] // Equivalent to .../api/users // ? [controller] takes the file class name excluding "...Controller".
[Authorize]
public class UsersController : BaseApiController // DRY: Remove headers with inheritance from a base controller
{
    // Inyect dependencies, "_" before name is used to avoid the excesive use of "this." inside the constructor
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync(); // ToListAsync comes from: // * using Microsoft.EntityFrameworkCore; * //

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        // TODO: Add error handling
        return Ok(await _context.Users.FindAsync(id));
    }
}
