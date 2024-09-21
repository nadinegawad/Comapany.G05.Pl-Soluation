using AutoMapper;
using Comapany.G02.Pl.ViewModel;
using Company.G02.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comapany.G02.Pl.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
