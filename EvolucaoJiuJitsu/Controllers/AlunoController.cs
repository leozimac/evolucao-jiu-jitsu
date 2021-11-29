using System;
using EvolucaoJiuJitsu.Dominio.Dto;
using EvolucaoJiuJitsu.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvolucaoJiuJitsu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlunoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNovoAluno([FromBody] AlunoDto novoAluno)
        {
            if (novoAluno == null)
                return BadRequest("Favor informar as informações do aluno.");

            if (novoAluno.DtaNascimento == null || novoAluno.DtaNascimento.Equals(new DateTime(0001, 01, 01)))
                return BadRequest("Favor informar a data de nascimento do aluno.");

            if (string.IsNullOrEmpty(novoAluno.Nome))
                return BadRequest("Favor informar o nome do aluno.");

            var result = _alunoService.AdicionarAluno(novoAluno);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlunoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAluno([FromQuery] long idAluno)
        {
            var aluno = _alunoService.BuscarAlunoPorId(idAluno);

            return Ok(aluno);
        }

        [HttpPost]
        [Route("marcar-presenca")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlunoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult MarcarPresencaAluno([FromBody] long idAluno)
        {
            if (idAluno < 1)
                return BadRequest("Favor informar o aluno.");

            var result = _alunoService.MarcarPresenca(idAluno);

            if (result == null)
                return Ok("Nenhum aluno encontrado com o id informado.");

            return Ok(result);
        }

        [HttpPatch]
        [Route("atualizar-faixa")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlunoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarFaixaAluno([FromBody] long idAluno)
        {
            if (idAluno == 0)
                return BadRequest("Favor informar o aluno para atualizar a faixa.");

            var result = _alunoService.AtualizarFaixa(idAluno);

            if (result == null)
                return Ok("Nenhum aluno encontrado.");

            return Ok(result);
        }
    }
}
