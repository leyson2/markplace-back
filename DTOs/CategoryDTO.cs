﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CategoryDTO
    {

        [Required(ErrorMessage = "El campo name es Obligatorio")]
        public string Name { get; set; }

    }
}
