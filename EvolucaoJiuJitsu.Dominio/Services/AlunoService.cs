using System;
using System.Collections.Generic;
using System.Linq;
using EvolucaoJiuJitsu.Dominio.Dto;
using EvolucaoJiuJitsu.Dominio.Interfaces;
using EvolucaoJiuJitsu.Dominio.Interfaces.Repositorios;
using EvolucaoJiuJitsu.Dominio.Mapper;

namespace EvolucaoJiuJitsu.Dominio.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly List<Aluno> alunosMatriculados;
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
            //if (alunosMatriculados == null)
            //    alunosMatriculados = new List<Aluno>();

            //alunosMatriculados.Add(new Aluno()
            //{
            //    Id = 1,
            //    DtaNascimento = new DateTime(1998, 06, 18),
            //    Nome = "Leonardo",
            //    Progresso = new Progresso(DateTime.Now),
            //});

            //alunosMatriculados.Add(new Aluno()
            //{
            //    Id = 2,
            //    DtaNascimento = new DateTime(1998, 01, 29),
            //    Nome = "Ana Flávia",
            //    Progresso = new Progresso(DateTime.Now),
            //});
        }

        public AlunoDto AdicionarAluno(AlunoDto novoAluno)
        {
            try
            {
                novoAluno.Progresso = new ProgressoDto(DateTime.Now);
                _alunoRepository.Save(novoAluno);
                return novoAluno;
            }
            catch
            {
                return null;
            }

        }

        public Aluno AtualizarFaixa(long id)
        {
            var alunos = from a in alunosMatriculados
                         where a.Id == id
                         select a;

            if (alunos.Count() < 1)
                return null;

            var aluno = alunos.First();

            if (aluno.Progresso.GrauFaixaAtual == 4)
            {
                aluno.Progresso.FaixaAtual += 1;
                aluno.Progresso.GrauFaixaAtual = 0;
            }
            else if (aluno.Progresso.GrauFaixaAtual < 4)
                aluno.Progresso.GrauFaixaAtual += 1;

            return aluno;
        }

        public AlunoDto BuscarAlunoPorId(long id)
        {
            try
            {
                var aluno = _alunoRepository.GetById(id);
                var alunoDto = AlunoMapping.MapEntityToDto(aluno);
                return alunoDto;
            }
            catch
            {
                return null;
            }
        }

        public Aluno MarcarPresenca(long id)
        {
            var alunos = from a in alunosMatriculados
                         where a.Id == id
                         select a;

            if (alunos.Count() < 1)
                return null;

            var aluno = alunos.First();
            aluno.Progresso.QtdAulasFrequentadas += 1;

            return aluno;
        }
    }
}
