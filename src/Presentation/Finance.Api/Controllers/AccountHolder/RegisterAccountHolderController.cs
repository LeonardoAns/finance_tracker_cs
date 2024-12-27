using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.UseCases.AccountHolder;
using Finance.Communication.AccountHolder;
using Finance.Communication.AccountHolder.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountHolder;

[Route("users")]
[ApiController]
public class RegisterAccountHolderController : ControllerBase {


    private readonly IRegisterAccountHolderUseCase _useCase;

    public RegisterAccountHolderController(IRegisterAccountHolderUseCase useCase){
        _useCase = useCase;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterAccountHolder([FromBody] AccountHolderRequestJson request){

        await _useCase.Execute(request);
        return Created(string.Empty, null);
    }
}