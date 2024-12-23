using AutoMapper;
using Domain.Entities;
using Finance.Communication.Category.Request;
using Finance.Communication.Category.Response;

namespace Finance.Application.AutoMapping;

public class AutoMappingConfig : Profile{
    
    public AutoMappingConfig(){
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity(){
        CreateMap<CategoryRequestJson, Category>()
            .ForMember(dest => dest.Expenses, opt => opt.Ignore());
    }

    private void EntityToResponse(){
        CreateMap<Category, CategoryResponseJson>();
    }
}