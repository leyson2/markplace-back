using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {

        IEnumerable<ProdctsDTOview> GetAll();


        Task Add(ProductDTOCreate productDTOCreate);

        Task<ProdctsDTOview> GetById(int Id);
        Task Update(int id, ProductDTOEdit ProductDTOEdit);
          
          Task Delete(int Id);

    }
}
