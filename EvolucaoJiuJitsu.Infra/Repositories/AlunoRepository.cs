using System;
using EvolucaoJiuJitsu.Dominio;
using EvolucaoJiuJitsu.Dominio.Dto;
using EvolucaoJiuJitsu.Dominio.Interfaces.Repositorios;
using EvolucaoJiuJitsu.Infra.Contexts;

namespace EvolucaoJiuJitsu.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoContext _alunoContext;

        public AlunoRepository(AlunoContext alunoContext)
        {
            _alunoContext = alunoContext;
        }

        public void AtualizarFaixa(long idAluno)
        {
            throw new NotImplementedException();
        }

        public Aluno GetById(long id)
        {
            var aluno = _alunoContext.Alunos.Find(id);
            return aluno;
        }

        public void MarcarPresenca(long idAluno)
        {
            throw new NotImplementedException();
        }

        public void Save(AlunoDto aluno)
        {
            var entity = new Aluno
            {
                Nome = aluno.Nome,
                Email = aluno.Email,
                DtaNascimento = aluno.DtaNascimento
            };
            entity.Progresso = new Progresso(aluno.Progresso.Inicio);

            _alunoContext.Alunos.Add(entity);
            _alunoContext.SaveChanges();
        }
    }
}
