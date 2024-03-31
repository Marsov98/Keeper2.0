using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Repositories;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatementController : Controller
{
    private readonly IStatementRepository _statementRepository;
    private readonly IUserRepository _userRepository;
    public StatementController(IStatementRepository statementRepository, IUserRepository userRepository)
    {
        _statementRepository = statementRepository;
        _userRepository = userRepository;
    }

    #region Вывести всех сотрудников
    [HttpGet("GetEmployees")]
    public async Task<ActionResult> GetEmployees()
    {
        var employees = _statementRepository.GetEmployees();
        return Ok(employees);
    }
    #endregion

    #region Вывести все подразделения
    [HttpGet("GetDivision")]
    public async Task<ActionResult> GetDivision()
    {
        var division = _statementRepository.GetDivision();
        return Ok(division);
    }
    #endregion

    #region Отправка индивидуальной заявки

    [HttpPost("CreateIndivid")]
    public ActionResult CreateIndivid([FromBody] Statement Individ)
    {

        try
        {
            _statementRepository.CreateIndivid(Individ);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    #endregion

    #region Отправка индивидуальной заявки

    [HttpPost("CreateGrpous")]
    public ActionResult CreateGrpous([FromBody] List<Statement> Group)
    {

        try
        {
            _statementRepository.CreateGroup(Group);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    #endregion

    #region Вывести все индивидуальные заявки по пользователю
    [HttpGet("GetStatement")]
    public ActionResult GetStatement()
    {
        //var user = _userRepository.GetUser(id);
        try
        {
            var Statement = _statementRepository.GetStatement();
            return Ok(Statement);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
}
