using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Repositories;

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
        var user = _userRepository.GetAllUsers();
        return Ok(user);
    }
    #endregion

    #region Регистрация

    [HttpPost("SignUp")]
    public ActionResult SignUp([FromBody] Users InputSignUp)
    {
        try
        {
            _userRepository.SignUp(InputSignUp);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Авторизация
    [HttpPost("Auth")]
    public ActionResult<Users> Auth([FromBody] Users InputAuth)
    {
        try
        {
            var user = _userRepository.Auth(InputAuth);
            if (user == null)
                return NotFound();

            return user;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion

    #region Удалить по id((
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userRepository.Remove(id);

        return Ok(new { Message = "User Deleted" });

    }
    #endregion

    #region Найти пользователя по id
    [NonAction]
    public Users GetById(int id)
    {
        var users = _userRepository.GetUser(id);
        if (users == null) { throw new KeyNotFoundException("User Not Found"); }
        return users;
    }
    #endregion
}
