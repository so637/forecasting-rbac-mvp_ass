namespace Forecast.Api.Models;

public class CsvImport
{
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? RawData { get; set; }
    public DateTime UploadedOn { get; set; }
}
