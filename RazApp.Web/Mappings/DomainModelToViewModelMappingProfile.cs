using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;



namespace RazApp.Web.Mappings
{
    public class DomainModelToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainModelToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {

            //Mapper.CreateMap<Domain.Model.Category, CategoryViewModel>();
            // Mapper.CreateMap<Domain.Model.User, UserViewModel>().ForMember(x => x.DisplayName, opt => opt.MapFrom(source => source.FirstName + " " + source.LastName));




        }
    }
}