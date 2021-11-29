using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvolucaoJiuJitsu.Dominio
{
    public class Aluno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        public DateTime DtaNascimento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public long IdProgresso { get; set; }
        [ForeignKey("IdProgresso")]
        public Progresso Progresso { get; set; }
        public List<Tecnica> TecnicasAprendidas { get; set; }
    }
}
