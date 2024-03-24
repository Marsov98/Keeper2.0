using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #region Вывести всех пользователей
    [HttpGet]
    public async Task<ActionResult> GetUsers()
    {
        var user = _userRepository.GetAll();
        return Ok(user);
    }
    #endregion

    #region Регистрация

    [HttpPost("SignUp")]
    public async Task<ActionResult> SignUp([FromBody] Users InputSignUp)
    {
        try
        {
            _userRepository.Create(InputSignUp);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
}
