﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovalynxFashion.Core.Enums;

namespace NovalynxFashion.Core.Entidades.DTO
{
    public class RegistrarDTO
    {
        [Required(ErrorMessage = "El campo {0} es necesario rellenar")]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "El campo {0} es necesario rellenar")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es necesario rellenar")]
        [RegularExpression("^[0-9]*$")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El campo {0} es necesario rellenar")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "El campo {0} es necesario rellenar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las dos contraseñas no coinciden entre sí.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
        
        public RoleEnum Role { get; set; }
        public string Direccion { get; set; }
        public string LinkedIn { get; set; }
        public string ImageProfile { get; set; }
    }
}