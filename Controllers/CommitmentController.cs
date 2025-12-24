using Forecast.Api.Data;
using Forecast.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forecast.Api.Controllers;

[ApiController]
[Route("api/commitments")]
public class CommitmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public CommitmentController(AppDbContext context)
    {
        _context = context;
    }

    // =====================================================
    // USER / MANAGER submits a forecast modification
    // =====================================================
    [HttpPost("submit")]
    public IActionResult SubmitCommitment(
        [FromHeader(Name = "X-User-Role")] string? role,
        int simulatedProjectId,
        int userId,
        decimal proposedValue)
    {
        // Only User or Manager can submit changes
        if (role != "User" && role != "Manager")
            return StatusCode(403, "Not allowed to submit commitment");

        // Validate forecast exists
        var forecast = _context.SimulatedProjects
            .FirstOrDefault(x => x.Id == simulatedProjectId);

        if (forecast == null)
            return NotFound("Forecast not found");

        var commitment = new UserCommitment
        {
            SimulatedProjectId = simulatedProjectId,
            UserId = userId,
            ProposedValue = proposedValue,
            Status = "Pending",
            CreatedOn = DateTime.UtcNow
        };

        _context.UserCommitments.Add(commitment);
        _context.SaveChanges();

        return Ok(commitment);
    }

    // =====================================================
    // ADMIN / MANAGER views all pending approvals
    // =====================================================
    [HttpGet("pending")]
    public IActionResult GetPendingCommitments(
        [FromHeader(Name = "X-User-Role")] string? role)
    {
        if (role != "Admin" && role != "Manager")
            return StatusCode(403, "Not allowed");

        var pending = _context.UserCommitments
            .Where(x => x.Status == "Pending")
            .OrderByDescending(x => x.CreatedOn)
            .ToList();

        return Ok(pending);
    }

    // =====================================================
    // ADMIN / MANAGER approves or rejects a commitment
    // =====================================================
    [HttpPost("approve")]
    public IActionResult ApproveCommitment(
        [FromHeader(Name = "X-User-Role")] string? role,
        int commitmentId,
        bool approve)
    {
        if (role != "Admin" && role != "Manager")
            return StatusCode(403, "Not allowed");

        var commitment = _context.UserCommitments
            .FirstOrDefault(x => x.Id == commitmentId);

        if (commitment == null)
            return NotFound("Commitment not found");

        commitment.Status = approve ? "Approved" : "Rejected";

        _context.SaveChanges();

        return Ok(commitment);
    }

    // =====================================================
    // USER can view their own submitted commitments
    // =====================================================
    [HttpGet("my")]
    public IActionResult GetMyCommitments(
        [FromHeader(Name = "X-User-Role")] string? role,
        int userId)
    {
        if (role != "User" && role != "Manager")
            return StatusCode(403, "Not allowed");

        var myCommitments = _context.UserCommitments
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedOn)
            .ToList();

        return Ok(myCommitments);
    }
}
