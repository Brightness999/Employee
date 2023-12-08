using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers;

[Route("api/managers")]
[ApiController]
public class ManagersController : ControllerBase
{
    private readonly CompanyDbContext _context;

    public ManagersController(CompanyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
    {
        return await _context.Managers.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Manager>> CreateManager(Manager manager)
    {
        _context.Managers.Add(manager);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetManagers), new { id = manager.ManagerID}, manager);
    }
}