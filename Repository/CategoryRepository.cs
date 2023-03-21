using AutoMapper;
using Data;
using DTOs;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository: ICategoryRepository
    {

        public SqlConnection _connection;
        public SqlCommand _commands = new SqlCommand();
        readonly IMapper _mapper;
        IContext _context;

        public CategoryRepository(IMapper mapper, IContext context)
        {
            _mapper = mapper;
            _context = context;
            _connection = _context.Connection();

        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            try
            {
                _connection.Open();
                string cadena = "select * from Category";
                _commands = new SqlCommand(cadena, _connection);
                SqlDataReader registers = _commands.ExecuteReader();

                while (registers.Read())
                {
                    int Id = int.Parse(registers["Id"].ToString());
                    string? Name = registers["Name"].ToString();
                    categories.Add(new Category(Id, Name));
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
            return categories;
        }


        public async Task Add(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            try
            {

                _connection.Open();
                string? Name = category.Name;
                string cadena = "Insert  INTO [Category](Name) VALUES (@Name)";
                _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("Name", Name);
                var result = await _commands.ExecuteNonQueryAsync();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
            return;
        }


        public async Task Delete(int Id)
        {
            try
            {
                _connection.Open();
                string cadena = "delete Category where Id =@Id";
                _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("Id", Id);
                var result = await _commands.ExecuteNonQueryAsync();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                _connection.Close();
            }
            return;
        }



        public async Task<Category> GetById(int Id)
        {
            try
            {
                _connection.Open();
                string cadena = "select * from Category where Id=@Id";
                _commands = new SqlCommand(cadena, _connection);

                _commands.Parameters.AddWithValue("Id", Id);
                SqlDataReader registers = await _commands.ExecuteReaderAsync();
                var ad = registers.Read();

                if (!ad)
                {
                    var men = "datos no encontrado";

                }
                int id = int.Parse(registers["Id"].ToString());
                string? Name = registers["Name"].ToString();
    
               Category category = new(id, Name);
                return category;

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

    }
}
