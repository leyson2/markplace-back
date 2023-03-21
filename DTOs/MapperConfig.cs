using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTOs
{
 public class MapperConfig : AutoMapper.Profile
    {


        public MapperConfig()
        {
            CreateMap<Product, ProductDTOCreate>();

            CreateMap<ProductDTOCreate, Product>();



            CreateMap<User, RegisterDTOCreate>();

            CreateMap<RegisterDTOCreate, User>();


            CreateMap<User, UserLoginDTO>();

            CreateMap<UserLoginDTO, User>();




            CreateMap<Category, CategoryDTO>();


            CreateMap<CategoryDTO, Category>();





            CreateMap<User, UserDTOView>();


            CreateMap<UserDTOView, User>();

        }


    }
}
