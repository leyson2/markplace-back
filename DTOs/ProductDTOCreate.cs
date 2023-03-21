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


        [Required(ErrorMessage = "El campo Name es Obligatorio")]
     
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Barcode es Obligatorio")]
        public string Barcode { get; set; } = null!;

        [Required(ErrorMessage = "El campo SalePrice es Obligatorio")]
        public Double SalePrice { get; set; }
        [Required(ErrorMessage = "El campo Amount es Obligatorio")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "El campo  Fk_IdCategory es Obligatorio")]
        public int Fk_IdCategory { get; set; }
        public string Imagen { get; set; } = null!;

 
        public Boolean Status { get; set; } 
 
        public ProductDTOCreate()
        {
            this.Status = true;

        }


    }
}
