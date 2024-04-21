using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Entities;

namespace UserService.Infrastructure.Context.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ConfirmationCode> ConfirmationCodes { get; set; }
}
