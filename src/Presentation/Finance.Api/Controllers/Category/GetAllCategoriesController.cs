using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Category;

[Route("categories")]
[ApiController]
public class GetAllCategoriesController : ControllerBase{

    [HttpGet]
    [Route("get/all")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllCategoriesUseCase useCase){
        List<CategoryResponseJson> response = await useCase.Execute();
        return Ok(response);
    }
    
}