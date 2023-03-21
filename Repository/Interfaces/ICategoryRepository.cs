using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
   public interface ICategoryRepository
    {

        IEnumerable<Category> GetAll();
        Task Add(CategoryDTO categoryDTO);
        Task<Category> GetById(int Id);
        Task Delete(int Id);
    }
}
