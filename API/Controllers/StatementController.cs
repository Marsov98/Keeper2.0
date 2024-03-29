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
    public StatementController(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
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
}
