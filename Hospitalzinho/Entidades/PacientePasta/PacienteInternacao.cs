using Hospitalzinho.Entidades.EspecificaçõesHospital;
using System;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteInternacao
    {
        public virtual long Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual DateTime DataInternacao { get; set; }
        public virtual DateTime? DataAlta { get; set; } // Pode ser nulo enquanto o paciente estiver internado
        public virtual Quarto Quarto { get; set; } // Ex: "101A"
        public virtual string Motivo { get; set; }
        public virtual ProfissionalSaude ProfResponsavel { get; set; }
        public virtual string Observacoes { get; set; }
    }
}
