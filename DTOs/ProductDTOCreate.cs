using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
   public class ProductDTOCreate
    {


        [Required(ErrorMessage = "El campo Nombre es Obligatorio")]
     
        public string Name { get; set; }

        [Required]
        public string Barcode { get; set; } = null!;

        [Required]
        public Double SalePrice { get; set; }
        [Required]
        public int Amount { get; set; }

        [Required]
        public int Fk_IdCategory { get; set; }
        public string Imagen { get; set; } = null!;
        [Required]
        public Boolean Status { get; set; } 
 
        public ProductDTOCreate()
        {
            this.Status = true;

        }


    }
}
