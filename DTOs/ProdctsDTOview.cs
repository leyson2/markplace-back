using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProdctsDTOview
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Barcode { get; set; } = null!;

        public Double SalePrice { get; set; }

        public int Amount { get; set; }

        public int Fk_IdCategory { get; set; }

        public string nameCategory { get; set; }
        public string Imagen { get; set; } = null!;
        public Boolean Status { get; set; }

        public ProdctsDTOview(int id, string name, string barcode, double salePrice, int amount, int fk_IdCategory, string nameCategory, string imagen, bool status)
        {
            Id = id;
            Name = name;
            Barcode = barcode;
            SalePrice = salePrice;
            Amount = amount;
            Fk_IdCategory = fk_IdCategory;
            this.nameCategory = nameCategory;
            Imagen = imagen;
            Status = status;
        }
    }
}
