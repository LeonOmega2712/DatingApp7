using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

// [ApiController]
// [Route("api/[controller]")] // Equivalent to .../api/users // ? [controller] takes the file class name excluding "...Controller".
[Authorize]
public class UsersController : BaseApiController // DRY: Remove headers with inheritance from a base controller
{
    // Inyect dependencies, "_" before name is used to avoid the excesive use of "this." inside the constructor
    // private readonly DataContext _context;

    // public UsersController(DataContext context) // ! Having the context injected in the controller difficults unit testing
    // {
    //     _context = context;
    // }
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        return Ok(await _userRepository.GetMembersAsync());
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberAsync(username);
    }
}
