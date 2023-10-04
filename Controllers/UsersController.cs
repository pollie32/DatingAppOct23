using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    public UsersController(DataContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await Context.Users.ToListAsync();
    }

    [HttpGet("{id}")]   // /api/users/3
    
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await Context.Users.FindAsync(id);
    }

    public DataContext Context { get; }
}