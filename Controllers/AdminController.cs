using Forecast.Api.Data;
using Forecast.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forecast.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    // ================= CSV UPLOAD =================
    [HttpPost("upload-csv")]
    public async Task<IActionResult> UploadCsv(
        IFormFile file,
        [FromHeader(Name = "X-User-Role")] string? role)
    {
        if (role != "Admin")
            return StatusCode(403, "Admin access only");

        if (file == null || file.Length == 0)
            return BadRequest("CSV file required");

        using var reader = new StreamReader(file.OpenReadStream());
        var rawCsv = await reader.ReadToEndAsync();

        var csv = new CsvImport
        {
            FileName = file.FileName,
            RawData = rawCsv,
            UploadedOn = DateTime.UtcNow
        };

        _context.CsvImports.Add(csv);
        await _context.SaveChangesAsync();

        return Ok(new { message = "CSV uploaded successfully", csv.Id });
    }

    // ================= FORECAST GENERATION =================
    [HttpPost("generate-forecast")]
    public IActionResult GenerateForecast(
        [FromHeader(Name = "X-User-Role")] string? role)
    {
        if (role != "Admin")
            return StatusCode(403, "Admin access only");

        var csv = _context.CsvImports
            .OrderByDescending(x => x.UploadedOn)
            .FirstOrDefault();

        if (csv == null)
            return BadRequest("No CSV uploaded");

        var lines = csv.RawData!
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Skip(1);

        var numbers = new List<decimal>();

        foreach (var line in lines)
        {
            if (decimal.TryParse(line.Trim(), out var value))
                numbers.Add(value);
        }

        if (!numbers.Any())
            return BadRequest("CSV has no numeric data");

        var avg = numbers.Average();
        var result = new List<SimulatedProject>();

        for (int i = 1; i <= 12; i++)
        {
            result.Add(new SimulatedProject
            {
                CsvImportId = csv.Id,
                Month = DateTime.UtcNow.AddMonths(i).ToString("yyyy-MM"),
                ForecastValue = avg + (i * 10),
                CreatedOn = DateTime.UtcNow
            });
        }

        _context.SimulatedProjects.AddRange(result);
        _context.SaveChanges();

        return Ok(result);
    }
}
