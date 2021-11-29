using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvolucaoJiuJitsu.Dominio
{
    public class Tecnica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(80)]
        public string Nome { get; set; }
        [MaxLength(250)]
        public string Descricao { get; set; }

        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }
    }
}
