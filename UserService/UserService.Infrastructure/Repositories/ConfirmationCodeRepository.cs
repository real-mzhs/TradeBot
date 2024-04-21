using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure.Context.Entities;
using UserService.Infrastructure.Entities;
using UserService.Infrastructure.Interfaces;

namespace UserService.Infrastructure.Repositories;

public class ConfirmationCodeRepository : IConfirmationCodeRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<ConfirmationCode> _entities;

    protected ConfirmationCodeRepository(AppDbContext context)
    {
        _context = context;
        _entities = context.Set<ConfirmationCode>();
    }

    public virtual async Task<ConfirmationCode?> GetByIdAsync(int id) =>
        await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);

    public async Task<ConfirmationCode?> GetByCodeAsync(string code) =>
        await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Code == code);

    public virtual async Task<ConfirmationCode> InsertAsync(ConfirmationCode entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var entityItem = await _entities.AddAsync(entity);
        
        await _context.SaveChangesAsync();

        return (await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Id == entityItem.Entity.Id))!;
    }

    public virtual void Update(ConfirmationCode entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _entities.Update(entity);
    }

    public virtual void Delete(ConfirmationCode entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _entities.Remove(entity);
    }

    public virtual async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();}
