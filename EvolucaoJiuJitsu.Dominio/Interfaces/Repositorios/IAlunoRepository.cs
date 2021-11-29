using EvolucaoJiuJitsu.Dominio.Dto;

namespace EvolucaoJiuJitsu.Dominio.Interfaces.Repositorios
{
    public interface IAlunoRepository
    {
        public void Save(AlunoDto aluno);
        public void MarcarPresenca(long idAluno);
        public void AtualizarFaixa(long idAluno);
        public Aluno GetById(long id);
    }
}
