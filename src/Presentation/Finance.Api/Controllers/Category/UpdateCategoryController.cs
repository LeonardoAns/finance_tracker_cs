using Finance.Application.IUseCases.Category;
using Finance.Communication.Category.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Category;


[Route("categories")]
[ApiController]
public class UpdateCategoryController : ControllerBase{

    [HttpPut]
    [Route("update/{categoryId}")]
    public async Task<IActionResult> UpdateCategory([FromServices] IUpdateCategoryUseCase useCase,
        [FromRoute] long categoryId, 
        [FromBody] CategoryRequestJson categoryRequest){

        await useCase.Execute(categoryId, categoryRequest);
        return NoContent(); 

    }
    
    
}