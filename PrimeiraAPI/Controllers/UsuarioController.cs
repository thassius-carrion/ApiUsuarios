using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeiraAPI.Dtos;
using PrimeiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        [HttpGet]
        public IActionResult ObterUsuario()
        {
            var usuario = new Usuario()
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Senha = "12345ab"
            };
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(usuario);
            }
            catch (Exception excecao)
            {
                _logger.LogError($"Ocorreu um erro ao salvar o usuario: {excecao.Message}", excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu um erro ao salvar o usuario, tente novamente."
                });
            }

        }
    }
}
