using Hospitalzinho.Entidades.PacientePasta;
using System;
using System.Collections.Generic;

namespace Hospitalzinho.Entidades
{
    public class Quarto
    {
        public virtual long Id { get; set; }
        public virtual string Numero { get; set; } // Ex: "101A"
        public virtual Ala Ala { get; set; } // Ala onde o quarto está localizado
        public virtual TipoQuarto Tipo { get; set; } // Enum: Enfermaria, UTI, Isolamento
        public virtual int Capacidade { get; set; } // Quantas camas
        public virtual IList<PacienteInternacao> Internacoes { get; set; } = new List<PacienteInternacao>();
    }
}
