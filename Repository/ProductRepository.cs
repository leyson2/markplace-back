using AutoMapper;
using Data;
using DTOs;
using Microsoft.Win32;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public SqlConnection _connection;
        public SqlCommand _commands = new SqlCommand();
        readonly IMapper _mapper;
        IContext _context;

        public ProductRepository(IMapper mapper,IContext context)
        {
            _mapper = mapper;
            _context = context;
            _connection = _context.Connection();
        }


        public async Task Add(ProductDTOCreate productDTOCreate)
        {


            var product = _mapper.Map<Product>(productDTOCreate); 
            try {

                _connection.Open();

                string? Name = product.Name;
                string? Barcode = product.Barcode;
                Double SalePrice = product.SalePrice;
                int Amount = product.Amount;
                string? Imagen = product.Imagen;
                Boolean Status = product.Status;
                int Fk_IdCategory = product.Fk_IdCategory;

                string cadena = "Insert  INTO Product(Name,Barcode,SalePrice,Amount,Status,Fk_IdCategory,Imagen,DateCreation) VALUES (@N,@B,@S,@A,@ST,@Fk,@I,@D)";
                _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("N", Name);
                _commands.Parameters.AddWithValue("B", Barcode);
                _commands.Parameters.AddWithValue("S", SalePrice);
                _commands.Parameters.AddWithValue("A", Amount);
                _commands.Parameters.AddWithValue("ST", Status);
                _commands.Parameters.AddWithValue("Fk", Fk_IdCategory);
                _commands.Parameters.AddWithValue("I", Imagen);
                _commands.Parameters.AddWithValue("D", DateTime.Now);
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


        public IEnumerable<ProdctsDTOview> GetAll()
        {
            List<ProdctsDTOview> products = new List<ProdctsDTOview>();
            try
            {
             _connection.Open();
            string cadena = "SELECT p.Id,p.Name ,p.Status, p.Barcode,p.SalePrice ,p.Amount,p.Fk_IdCategory,p.Imagen, c.Name  as nameCategory FROM Product as p INNER JOIN Category as c ON p.Fk_IdCategory = c.Id";
            _commands = new SqlCommand(cadena, _connection);
            SqlDataReader registers = _commands.ExecuteReader();
         
            while (registers.Read())
            {
                int Id = int.Parse(registers["Id"].ToString());
                string? Name = registers["Name"].ToString();
                string? Barcode = registers["Barcode"].ToString();
                Double SalePrice = Double.Parse(registers["SalePrice"].ToString());
                int Amount = int.Parse(registers["Amount"].ToString());
                string? Imagen = registers["Imagen"].ToString();
                    Boolean Status = Boolean.Parse(registers["Status"].ToString());
                    int Fk_IdCategory = int.Parse(registers["Fk_IdCategory"].ToString());
                   string? nameCategory = registers["nameCategory"].ToString();
             products.Add(new ProdctsDTOview(Id,Name, Barcode, SalePrice, Amount,   Fk_IdCategory, nameCategory, Imagen,Status));

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
            return products;
        }

        public async Task Delete(int Id)
        {
            try
            {
                _connection.Open();
            string cadena = "delete Product where Id =@Id";
            _commands = new SqlCommand(cadena, _connection);
            _commands.Parameters.AddWithValue("Id", Id);
            var result = await _commands.ExecuteNonQueryAsync();
            }catch (SqlException e)
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
            return;
        }

         public async Task<ProdctsDTOview> GetById(int id)
         {
             try
             {
                 _connection.Open();
                 string cadena = "SELECT p.Id,p.Name , p.Status, p.Barcode,p.SalePrice ,p.Amount,p.Fk_IdCategory,p.Imagen, c.Name  as nameCategory FROM Product as p INNER JOIN Category as c ON p.Fk_IdCategory = c.Id where p.Id = @Id";
                 _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("Id", id);
                SqlDataReader registers = await _commands.ExecuteReaderAsync();
                var ad=  registers.Read();

                 if (!ad)
                 {
                     var men = "datos no encontrado";

                 }
                int Id = int.Parse(registers["Id"].ToString());
                string? Name = registers["Name"].ToString();
                string? Barcode = registers["Barcode"].ToString();
                Double SalePrice = Double.Parse(registers["SalePrice"].ToString());
                int Amount = int.Parse(registers["Amount"].ToString());
                string? Imagen = registers["Imagen"].ToString();
                Boolean Status = Boolean.Parse(registers["Status"].ToString());

                int Fk_IdCategory = int.Parse(registers["Fk_IdCategory"].ToString());
                string? nameCategory = registers["nameCategory"].ToString();
                ProdctsDTOview product = new(Id, Name, Barcode, SalePrice, Amount, Fk_IdCategory, nameCategory, Imagen, Status);
                 return product;

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

        public async Task Update(int id, ProductDTOEdit ProductDTOEdit)
        {

            try
            {

  
                _connection.Open();
                string cadena = "update  Product set Name=@N,Barcode=@B,SalePrice=@S,Amount=@A, Fk_IdCategory=@FK ,Imagen=@I ,Status=@ST Where Id =@Id";
                _commands = new SqlCommand(cadena, _connection);
                _commands.Parameters.AddWithValue("N", ProductDTOEdit.Name);
                _commands.Parameters.AddWithValue("B", ProductDTOEdit.Barcode);
                _commands.Parameters.AddWithValue("S", ProductDTOEdit.SalePrice);
                _commands.Parameters.AddWithValue("A", ProductDTOEdit.Amount);
                _commands.Parameters.AddWithValue("ST", ProductDTOEdit.Status);
                _commands.Parameters.AddWithValue("Fk", ProductDTOEdit.Fk_IdCategory);
                _commands.Parameters.AddWithValue("I", ProductDTOEdit.Imagen);
                _commands.Parameters.AddWithValue("Id", id);
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
    }
}
