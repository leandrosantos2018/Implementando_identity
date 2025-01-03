﻿using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace UsuarioApi.Data.Dtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
