namespace Domain.IUnitOfWork;

public interface IUnitOfWork {
    Task Commit();
}