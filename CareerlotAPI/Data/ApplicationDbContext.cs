using Microsoft.EntityFrameworkCore;
using CareerlotAPI.Models;

namespace CareerlotAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<CareerPivot> CareerPivots { get; set; }
}