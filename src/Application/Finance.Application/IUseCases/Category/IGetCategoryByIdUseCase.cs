using Finance.Communication.Category.Response;

namespace Finance.Application.IUseCases.Category;

public interface IGetCategoryByIdUseCase {
    Task<CategoryResponseJson> Execute(long id);
}