using Finance.Communication.Category.Response;

namespace Finance.Application.IUseCases.Category;

public interface IGetAllCategoriesUseCase {
    Task<List<CategoryResponseJson>> Execute();
}