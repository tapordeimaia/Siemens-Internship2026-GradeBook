using System.Text.Json;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class GradeRepository : IGradeRepository
{
    private readonly HttpClient _httpClient;
    private const string DataUrl = "https://gist.githubusercontent.com/ArdeleanTudor/8ea407832cd9794960e0e6bbd1319f6e/raw/145b121103dd1cee3737a681c487f7295ac82e6b/gistfile1.txt";

    public GradeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Grade>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(DataUrl);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var wrapper = JsonSerializer.Deserialize<GradeWrapper>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return wrapper?.Items ?? new List<Grade>();
    }

    public async Task<Grade?> GetByIdAsync(int id)
    {
        var grades = await GetAllAsync();
        return grades.FirstOrDefault(grade => grade.Id == id && grade.isActive);
    }
}

public class GradeWrapper
{
    public List<Grade> Items { get; set; }
}

