using Siemens.Internship2026.GradeBook.Models;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Services;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _repository;

    public GradeService(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<(IEnumerable<Grade> Data, object Statistics)> GetAllWithStatsAsync()
    {
        var items = await _repository.GetAllAsync();
        var gradeList = items.Where(grade => grade.isActive).ToList();

        var totalCount = gradeList.Count;
        var averageValue = gradeList.Any() ? gradeList.Average(grade => grade.Value) : 0;

        var statistics = new
        {
            TotalCount = totalCount,
            AverageValue = averageValue,
            RetrievedAt = DateTime.UtcNow
        };

        return (gradeList, statistics);
    }

    public async Task<Grade?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Grade>> GetTopPassingGradesAsync(int n)
    {
        var allGrades = await _repository.GetAllAsync();

        return allGrades
            .Where(grade => grade.isActive && grade.Value >= 5)
            .Take(n)
            .ToList();
    }
}
