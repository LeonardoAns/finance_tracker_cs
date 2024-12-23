namespace Finance.Application.IUseCases.Category;

public interface IDeleteCategoryUseCase {
    Task Execute(long id);
}