using EvolucaoJiuJitsu.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EvolucaoJiuJitsu.Infra.Contexts
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Progresso> Progressos { get; set; }
        public DbSet<Tecnica> Tecnicas { get; set; }
    }
}
