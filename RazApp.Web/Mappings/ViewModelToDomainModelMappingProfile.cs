using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;



namespace RazApp.Web.Mappings
{
    public class ViewModelToDomainModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainModelMappingProfile"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<CategoryViewModel,Domain.Model.Category>();           
        }
    }
}