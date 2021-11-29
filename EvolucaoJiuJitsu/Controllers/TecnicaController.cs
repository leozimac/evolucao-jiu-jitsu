using System;
using System.Collections.Generic;
using EvolucaoJiuJitsu.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvolucaoJiuJitsu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicaController : ControllerBase
    {
        private List<Tecnica> tecnicas;

        public TecnicaController()
        {
            if (tecnicas == null)
            {
                tecnicas = new List<Tecnica>();

                tecnicas.Add(new Tecnica()
                {
                    Id = 1,
                    Nome = "Americano",
                    Descricao = "Submissao"
                });
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tecnica))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdicionarTecnica([FromBody] Tecnica tecnica)
        {
            if (tecnica == null)
                return BadRequest(new { mensagem = "É obrigatório enviar um objeto tecnica." });

            var random = new Random();
            tecnica.Id = random.Next();

            tecnicas.Add(tecnica);

            return Ok(tecnica);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tecnica>))]
        public IActionResult GetTecnicas()
        {
            return Ok(tecnicas);
        }

    }
}
