﻿using System.ComponentModel.DataAnnotations;

namespace Devlivery.Api.ValueObject
{
    public class RegistroRequisicaoModelDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}
