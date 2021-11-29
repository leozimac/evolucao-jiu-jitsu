using System;

namespace EvolucaoJiuJitsu.Dominio.Dto
{
    public class ProgressoDto
    {
        public DateTime Inicio { get; set; }
        public int QtdAulasFrequentadas { get; set; }
        public string FaixaAtual { get; set; }
        public int GrauFaixaAtual { get; set; }

        public ProgressoDto(DateTime inicio)
        {
            Inicio = inicio;
        }
    }
}
