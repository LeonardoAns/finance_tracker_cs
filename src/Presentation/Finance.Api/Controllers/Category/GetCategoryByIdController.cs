using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Category;

[Route("categories")]
[ApiController]
public class GetCategoryByIdController : ControllerBase{

    [HttpGet]
    [Route("get/{categoryId}")]
    public async Task<IActionResult> GetById([FromServices] IGetCategoryByIdUseCase useCase,
        [FromRoute] long categoryId){
        CategoryResponseJson response = await useCase.Execute(categoryId);

        return Ok(response);
    }
}