using Domain.IRepositories;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Communication.AccountHolder.Request;
using Finance.Communication.AccountHolder.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountHolder;

[Route("users")]
[ApiController]
public class LoginAccountHolderController : ControllerBase{

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAccount([FromServices] ILoginAccountHolderUseCase useCase,
        [FromBody] LoginAccountHolderRequestJson holderRequestJson){

        AccountHolderResponseJson response = await useCase.Execute(holderRequestJson);
        return Ok(response);
    }
    
}