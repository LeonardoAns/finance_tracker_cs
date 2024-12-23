using Finance.Communication.Category.Request;

namespace Finance.Application.IUseCases.Category;

public interface IRegisterCategoryUseCase {
    Task Execute(CategoryRequestJson categoryRequest);
}