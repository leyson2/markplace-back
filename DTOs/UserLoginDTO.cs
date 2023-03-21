using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "El campo  UserName es Obligatorio")]

        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "El campo Password es Obligatorio")]
        public string Password { get; set; } = null!;

    }
}
