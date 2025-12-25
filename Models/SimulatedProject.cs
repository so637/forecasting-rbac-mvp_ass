namespace Forecast.Api.Models;

public class SimulatedProject
{
    public int Id { get; set; }
    public int CsvImportId { get; set; }
    public string? Month { get; set; }
    public decimal ForecastValue { get; set; }
    public DateTime CreatedOn { get; set; }
}
