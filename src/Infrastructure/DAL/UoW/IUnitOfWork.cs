namespace Infrastructure.DAL.UoW;

internal interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}