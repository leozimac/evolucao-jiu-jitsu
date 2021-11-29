using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvolucaoJiuJitsu.Dominio.Enums;

namespace EvolucaoJiuJitsu.Dominio
{
    public class Progresso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime Inicio { get; set; }
        public int QtdAulasFrequentadas { get; set; }
        public EFaixa FaixaAtual { get; set; }
        public int GrauFaixaAtual { get; set; }

        public Progresso(DateTime inicio)
        {
            Inicio = inicio;
            QtdAulasFrequentadas = 0;
            FaixaAtual = EFaixa.Branca;
            GrauFaixaAtual = 0;
        }
    }
}
