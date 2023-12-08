using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers;

[Route("api/supervisors")]
[ApiController]
public class SupervisorsController : ControllerBase
{
    private readonly CompanyDbContext _context;

    public SupervisorsController(CompanyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supervisor>>> GetSupervisor()
    {
        return await _context.Supervisors.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Supervisor>> CreateSupervisor(Supervisor supervisor)
    {
        _context.Supervisors.Add(supervisor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSupervisor), new { id = supervisor.SupervisorID }, supervisor);
    }
}