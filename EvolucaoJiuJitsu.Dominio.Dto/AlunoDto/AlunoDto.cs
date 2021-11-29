using System;

namespace EvolucaoJiuJitsu.Dominio.Dto
{
    public class AlunoDto
    {
        public string Nome { get; set; }
        public DateTime DtaNascimento { get; set; }
        public string Email { get; set; }
        public ProgressoDto Progresso { get; set; }
    }
}
