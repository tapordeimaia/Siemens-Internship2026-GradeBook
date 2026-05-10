using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces;

public interface IGradeRepository
{
    Task<IEnumerable<Grade>> GetAllAsync();
    Task<Grade?> GetByIdAsync(int id);
}

