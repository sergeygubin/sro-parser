namespace Domain.Abstraction;

public interface IUnitOfWork
{
    Task Commit();
}