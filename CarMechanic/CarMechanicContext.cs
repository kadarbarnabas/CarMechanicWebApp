using CarMechanic.Shared;
using Microsoft.EntityFrameworkCore;

namespace CarMechanic;

public class CarMechanicContext : DbContext
{
    public CarMechanicContext() { }
    public CarMechanicContext(DbContextOptions<CarMechanicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Work> Works { get; set;}
}