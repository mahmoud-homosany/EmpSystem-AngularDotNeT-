using AutoMapper;
using DTOS.EmpDTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Mapper
{
    public class AutoMapperAdd:Profile
    {
        public AutoMapperAdd()
        {
            CreateMap<CreateOrUpdateVM,Employee>().ReverseMap();
            CreateMap<EmpGetAllVM,Employee>().ReverseMap();
            

        }

    }
}
