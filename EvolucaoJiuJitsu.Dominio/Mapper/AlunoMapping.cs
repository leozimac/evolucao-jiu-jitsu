using EvolucaoJiuJitsu.Dominio.Dto;
using EvolucaoJiuJitsu.Dominio.Enums;

namespace EvolucaoJiuJitsu.Dominio.Mapper
{
    public static class AlunoMapping
    {
        public static AlunoDto MapEntityToDto(Aluno aluno)
        {
            if (aluno == null)
                return null;

            var alunoDto = new AlunoDto
            {
                Nome = aluno.Nome,
                DtaNascimento = aluno.DtaNascimento,
                Email = aluno.Email
            };

            alunoDto.Progresso.FaixaAtual = aluno.Progresso.FaixaAtual switch
            {
                EFaixa.Branca => "Branca",
                EFaixa.Azul => "Azul",
                EFaixa.Roxa => "Roxa",
                EFaixa.Marrom => "Marrom",
                EFaixa.Preta => "Preta",
                _ => "",
            };
            alunoDto.Progresso.Inicio = aluno.Progresso.Inicio;
            alunoDto.Progresso.GrauFaixaAtual = aluno.Progresso.GrauFaixaAtual;
            alunoDto.Progresso.QtdAulasFrequentadas = aluno.Progresso.QtdAulasFrequentadas;

            return alunoDto;
        }
    }
}
