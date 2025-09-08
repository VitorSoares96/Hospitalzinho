using System;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteCirurgia
    {
        public virtual long Id { get; set; }
        public virtual PacienteProntuario Prontuario { get; set; }
        public virtual string Nome { get; set; } // Ex: "Apendicectomia"
        public virtual DateTime DataCirurgia { get; set; }
        public virtual Medico MedicoResponsavel { get; set; }
        public virtual string Hospital { get; set; }
        public virtual string Observacoes { get; set; }
    }
}
