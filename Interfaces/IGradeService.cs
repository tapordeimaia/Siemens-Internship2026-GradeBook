using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces;

public interface IGradeService
{
    Task<(IEnumerable<Grade> Data, object Statistics)> GetAllWithStatsAsync();
    Task<Grade?> GetByIdAsync(int id);
    Task<IEnumerable<Grade>> GetTopPassingGradesAsync(int n);
}
