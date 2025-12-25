namespace Forecast.Api.Models;

public class UserCommitment
{
    public int Id { get; set; }

    public int SimulatedProjectId { get; set; }
    public int UserId { get; set; }

    public decimal ProposedValue { get; set; }

    public string Status { get; set; } = "Pending"; 
    // Pending / Approved / Rejected

    public DateTime CreatedOn { get; set; }
}
