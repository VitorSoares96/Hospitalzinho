using System;
using System.Collections.Generic;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteConsulta
    {
        public virtual long Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual DateTime DataConsulta { get; set; }
        public virtual Medico MedicoResponsavel { get; set; }
        public virtual string Observacoes { get; set; }

        public virtual Sala Sala { get; set; }
        public virtual IList<PacienteExame> Exames { get; set; } = new List<PacienteExame>();
    }
}
