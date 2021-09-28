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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private readonly string loginTeste = "adm@adm.com";
        private readonly string senhaTeste = "senha";

        public LoginController (ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto requisicao)
        {
            try
            {
                if (requisicao == null
                    || string.IsNullOrEmpty(requisicao.Login) || string.IsNullOrWhiteSpace(requisicao.Login)
                    || string.IsNullOrEmpty(requisicao.Senha) || string.IsNullOrWhiteSpace(requisicao.Senha)
                    || requisicao.Login != loginTeste || requisicao.Senha != senhaTeste)
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erro = "Parametros de entrada invalidos"
                    });
                }
                return Ok(new LoginRespostaDto()
                {
                    Email = loginTeste,
                    Nome = "Usuario de teste",
                    Token = ""
                });
            }
            catch(Exception excecao)
            {
                _logger.LogError($"Ocorreu um erro ao efetuar o login: {excecao.Message}", excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu um erro ao efetuar o login, tente novamente."
                });
            }
        }

    }
}
