using EvolucaoJiuJitsu.Dominio.Dto;

namespace EvolucaoJiuJitsu.Dominio.Interfaces
{
    public interface IAlunoService
    {
        #region Command
        public AlunoDto AdicionarAluno(AlunoDto novoAluno);
        public Aluno MarcarPresenca(long id);
        public Aluno AtualizarFaixa(long id);
        #endregion

        #region Query
        public AlunoDto BuscarAlunoPorId(long id);
        #endregion
    }
}
