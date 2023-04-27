using Microsoft.EntityFrameworkCore;
using restApi.Models;

namespace restApi.Data; 
public class GrapeContext : DbContext {
    public GrapeContext(DbContextOptions<GrapeContext> options) : base(options) {}
    public DbSet<Client> Client { get; set; }
}