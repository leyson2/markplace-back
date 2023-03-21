using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Barcode { get; set; } = null!;

        public Double SalePrice { get; set; }

        public int Amount { get; set; }

        public int Fk_IdCategory { get; set; }
        public string Imagen { get; set; } = null!;

        public DateTime DateCreation { get; set; }

        public Boolean Status { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string barcode, double salePrice, int amount, string imagen, DateTime dateCreation, bool status,int fk_IdCategory)
        {
            Id = id;
            Name = name;
            Barcode = barcode;
            SalePrice = salePrice;
            Amount = amount;
            Imagen = imagen;
            DateCreation = dateCreation;
            Status = status;
            Fk_IdCategory = fk_IdCategory;
        }
    }
}
