using Finance.Communication.Category.Request;
using Finance.Communication.Category.Response;

namespace Finance.Application.IUseCases.Category;

public interface IUpdateCategoryUseCase {
    Task Execute(long id, CategoryRequestJson categoryRequest);
}