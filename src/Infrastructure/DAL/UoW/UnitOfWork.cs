namespace Infrastructure.DAL.UoW;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly BodyGuardDbContext _context;

    public UnitOfWork(BodyGuardDbContext context)
    {
        _context = context;
    }

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            await action();
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}