﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraAPI.Dtos
{
    public class LoginRespostaDto
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }

    }
}
