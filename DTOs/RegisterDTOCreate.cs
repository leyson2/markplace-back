using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class RegisterDTOCreate
    {

        [Required(ErrorMessage = "El campo Nombre es Obligatorio")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo username es Obligatorio")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "El campo lastname es Obligatorio")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "El campo addres es Obligatorio")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "El campo Email es Obligatorio")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo password es Obligatorio")]
        public string Password { get; set; } = null!;
        public Boolean Status { get; set; }
        public RegisterDTOCreate()
        {
            Status = true;

        }
    }
}
