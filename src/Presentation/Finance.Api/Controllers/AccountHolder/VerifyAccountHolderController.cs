using Finance.Application.IUseCases.AccountHolder;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountHolder;

[Route("users")]
[ApiController]
public class VerifyAccountHolderController : ControllerBase{

    [HttpGet]
    [Route("verify/{verificationCode}")]
    public async Task<IActionResult> VerifyAccountHolder([FromServices] IVerifyAccountHolderUseCase useCase,
        [FromRoute] string verificationCode){

        await useCase.Execute(verificationCode);
        return Ok();
    }
    
}