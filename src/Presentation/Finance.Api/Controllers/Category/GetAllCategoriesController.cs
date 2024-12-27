using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Category;

[Route("categories")]
[ApiController]
[Authorize]
public class GetAllCategoriesController : ControllerBase{

    [HttpGet]
    [Route("get/all")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllCategoriesUseCase useCase){
        List<CategoryResponseJson> response = await useCase.Execute();
        return Ok(response);
    }
    
}