using Domain.IRepositories;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Exception.ExceptionModel;
using Infrastructure.Repositories;

namespace Finance.Application.UseCases.AccountHolder;

using Domain.Entities;

public class GetAuthContextUseCase : IGetAuthContextUseCase {

    private readonly IAccountHolderRepository _accountHolderRepository;

    public GetAuthContextUseCase(IAccountHolderRepository accountHolderRepository){
        _accountHolderRepository = accountHolderRepository;
    }

    public Task<AccountHolder> Get(){
        return _accountHolderRepository.GetById() ??
               throw new NotFoundException("Account Holder Not Found");
    }
}