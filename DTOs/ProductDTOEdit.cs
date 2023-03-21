using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductDTOEdit
    {

        public string Name { get; set; } = null!;

        public string Barcode { get; set; } = null!;

        public Double SalePrice { get; set; }

        public int Amount { get; set; }

        public int Fk_IdCategory { get; set; }

        public string Imagen { get; set; } = null!;
        public Boolean Status { get; set; }
    }
}