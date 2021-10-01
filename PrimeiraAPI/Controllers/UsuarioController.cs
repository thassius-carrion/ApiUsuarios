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

        [HttpGet("{id:int}")]
        public IActionResult GetUsuarioById(int id)
        {
            return Ok(_usuarioRepository.GetUsuarioById(id));
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUsuarioById(int id)
        {
            try
            {
                _usuarioRepository.DeleteUsuarioById(id);
                return Ok("Usuario de ID " + id + " foi deletado com sucesso.");
            }
            catch (Exception excecao)
            {
                //_logger.LogError($"Ocorreu um erro ao deletar o usuario: {excecao.Message}", excecao);
                return StatusCode(StatusCodes.Status404NotFound, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status404NotFound,
                    Erro = "Ocorreu um erro ao deletar, tente novamente."
                });
            }

        }

        [HttpPut("{id:int}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            try
            {
                var usuarioToChange = _usuarioRepository.GetUsuarioById(id);
                usuarioToChange.Nome = usuario.Nome;
                usuarioToChange.Email = usuario.Email;
                usuarioToChange.Senha = usuario.Senha;
                _usuarioRepository.AtualizarUsuario(usuarioToChange);
                return Ok(usuarioToChange);
            }
            catch (Exception excecao)
            {
                //_logger.LogError($"Ocorreu um erro ao salvar o usuario: {excecao.Message}", excecao);
                return StatusCode(StatusCodes.Status400BadRequest, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Erro = "Ocorreu um erro ao salvar o usuario, tente novamente."
                });
            }

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
                //_logger.LogError($"Ocorreu um erro ao salvar o usuario: {excecao.Message}", excecao);
                return StatusCode(StatusCodes.Status400BadRequest, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Erro = "Ocorreu um erro ao salvar o usuario, tente novamente."
                });
            }

        }
    }
}
