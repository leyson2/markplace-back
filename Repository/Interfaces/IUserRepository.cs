using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {


        void Register(RegisterDTOCreate register);

        IEnumerable<UserDTOView> GetAll();
        bool login(UserLoginDTO user);


        Task<UserDTOView> GetUserName(string username);
    }
}
