using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareerlotAPI.Data;
using CareerlotAPI.Models;


namespace CareerlotAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CareerPivotController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    //passing the DB bridge
    public CareerPivotController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CareerPivot>>> GetPivots()
    {
        return await _context.CareerPivots.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<CareerPivot>> PostPivot(CareerPivot pivot)
    {
        _context.CareerPivots.Add(pivot);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetPivots), new { id = pivot.Id }, pivot);
    }
}