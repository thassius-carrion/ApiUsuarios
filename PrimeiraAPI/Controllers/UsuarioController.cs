using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeiraAPI.Dtos;
using PrimeiraAPI.Models;
using PrimeiraAPI.Repository;
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
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(_usuarioRepository.GetUsuarios());
        }

        [HttpPost]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.Salvar(usuario);
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
