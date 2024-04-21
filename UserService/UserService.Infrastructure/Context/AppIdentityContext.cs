using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Context.Entities;
using UserService.Infrastructure.Entities;

namespace UserService.Infrastructure.Context;

public class AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
    : IdentityDbContext<AppUserIdentity>(options);
