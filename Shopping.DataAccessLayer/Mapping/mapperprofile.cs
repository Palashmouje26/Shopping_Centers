using AutoMapper;
using BussinessModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.DataAccessLayer.Mapping
{
    internal class mapperprofile :Profile
    {
        public mapperprofile() 
        {
            CreateMap<Users,Users>().ReverseMap();
            CreateMap<ProductFileDetail, ProductFileDetail>().ReverseMap(); 
        }
    }
}
