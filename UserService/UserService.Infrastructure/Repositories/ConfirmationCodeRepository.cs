using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Context;
using UserService.Infrastructure.Entities;
using UserService.Infrastructure.Interfaces;

namespace UserService.Infrastructure.Repositories;

public class ConfirmationCodeRepository(AppDbContext context) : IConfirmationCodeRepository
{
    private readonly DbSet<ConfirmationCode> _entities = context.Set<ConfirmationCode>();

    public async Task<ConfirmationCode?> GetByIdAsync(int id) =>
        await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

    public async Task<ConfirmationCode?> GetByCodeAsync(string code) =>
        await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Code == code);

    public async Task<ConfirmationCode> InsertAsync(ConfirmationCode entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var entityItem = await _entities.AddAsync(entity);
        
        await context.SaveChangesAsync();

        return (await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Id == entityItem.Entity.Id))!;
    }

    public void Update(ConfirmationCode entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _entities.Update(entity);
    }

    public void Delete(ConfirmationCode entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _entities.Remove(entity);
    }

    public async Task<int> SaveChangesAsync() =>
        await context.SaveChangesAsync();}
