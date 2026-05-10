using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;
    private readonly ILogger<GradeController> _logger;

    public GradeController(IGradeService gradeService, ILogger<GradeController> logger)
    {
        _gradeService = gradeService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("GET api/grade called at {Time}", DateTime.UtcNow);

        var (data, statistics) = await _gradeService.GetAllWithStatsAsync();

        return Ok(new {Data = data, Statistics = statistics});
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("GET api/grade/{Id} called at {Time}", id, DateTime.UtcNow);

        if (id <= 0)
        {
            _logger.LogWarning("Invalid id: {Id}" , id);
            return BadRequest("ID must be a positive integer.");
        }

        var grade = await _gradeService.GetByIdAsync(id);
        if (grade == null)
        {
            _logger.LogWarning("Grade {Id} not found", id);
            return NotFound($"Grade with ID {id} was not found.");
        }

        return Ok(grade);
    }

    [HttpGet("passing/{n}")]
    public async Task<IActionResult> GetPassingGrades(int n)
    {
        if (n <= 0)
        {
            return BadRequest("Number of grades must be a positive integer.");
        }

        var grades = await _gradeService.GetTopPassingGradesAsync(n);
        return Ok(grades);
    }

}
