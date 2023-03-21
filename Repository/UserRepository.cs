using AutoMapper;
using Data;
using DTOs;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Repository
{
    public class UserRepository : IUserRepository
    {

        public SqlConnection _connection;
        public SqlCommand _commands = new SqlCommand();
        readonly IMapper _mapper;
        IContext _context;


 
        public UserRepository(IMapper mapper, IContext context)
        {
            _mapper = mapper;
            _context = context;
            _connection = _context.Connection();

        }


        public void Register(RegisterDTOCreate register)
        {

            var user = _mapper.Map<User>(register);
            try
            {
               _connection.Open();
                string? Name = user.Name;
                string? UserName = user.UserName;
                string LastName = user.LastName;
                string Address = user.Address;
                string? Email =  user.Email;
                string? Password = user.Password;
                Boolean? Status = user.Status;

                string cadena = "Insert INTO [User] (Name,UserName,LastName,Address,Email,Password,Status,DateCreation) VAlUES (@Name,@UserName,@LastName,@Address,@Email,@Password,@Status,@DateCreation)";

                _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("Name", Name);
                _commands.Parameters.AddWithValue("UserName", UserName);
                _commands.Parameters.AddWithValue("LastName", LastName);
                _commands.Parameters.AddWithValue("Address", Address);
                _commands.Parameters.AddWithValue("Email", Email);
                _commands.Parameters.AddWithValue("Password", Password);
                _commands.Parameters.AddWithValue("Status", Status);
                _commands.Parameters.AddWithValue("DateCreation", DateTime.Now);

                _commands.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
        }

      



        public async Task<UserDTOView> GetUserName(string username)
        {
            try
            {
                _connection.Open();
                string cadena = "select * from [User] where UserNAme=@UserN";
                _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("UserN", username);
                SqlDataReader registers = await _commands.ExecuteReaderAsync();
                var ad = registers.Read();

                if (!ad)
                {
                    var men = "datos no encontrado";

                }

                string? Name = registers["Name"].ToString();
                string? UserName = registers["UserName"].ToString();
                string? LastName = registers["LastName"].ToString();
                string? Address = registers["Address"].ToString();
                string? Email = registers["Email"].ToString();
     

                UserDTOView userDto = new(Name, UserName, LastName, Address, Email);
                return userDto;

            }
            catch (SqlException e)
            {
                throw e;
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }

        }




        public IEnumerable<UserDTOView> GetAll()
        {
            List<UserDTOView> usersDto = new List<UserDTOView>();
            try
            {
                _connection.Open();
                string cadena = "select * from [User]";
                _commands = new SqlCommand(cadena, _connection);
                SqlDataReader registers = _commands.ExecuteReader();

                while (registers.Read())
                {

                    string? Name = registers["Name"].ToString();
                    string? UserName = registers["UserName"].ToString();
                    string? LastName = registers["LastName"].ToString();
                    string? Address = registers["Address"].ToString();
                    string? Email = registers["Email"].ToString();
                    usersDto.Add(new UserDTOView(Name, UserName, LastName, Address, Email));
                }
                 }
            catch (SqlException e)
            {

                throw e;

            }
            finally
            {
                _connection.Close();
            }
            return usersDto;
        }

        public bool login(UserLoginDTO user)
        {
            try
            {

                _connection.Open();
                string cadena = "select UserName, Password from [User] where UserName=@Username and Password=@Password";
                _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("Username", user.UserName);
                _commands.Parameters.AddWithValue("Password", user.Password);
                SqlDataReader registers = _commands.ExecuteReader();
                var ad = registers.Read();
                return ad;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }

        }
    }
}
