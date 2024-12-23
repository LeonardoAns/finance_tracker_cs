using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Category; 

[Route("categories")]
[ApiController]
public class RegisterCatgoryController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterCategory([FromServices] IRegisterCategoryUseCase useCase,
        [FromBody] CategoryRequestJson categoryRequest){

        await useCase.Execute(categoryRequest);
        return Created(string.Empty, null);
    }
    
}