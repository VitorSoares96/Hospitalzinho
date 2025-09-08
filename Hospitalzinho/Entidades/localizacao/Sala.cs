using Hospitalzinho.Entidades.PacientePasta;
using System.Collections.Generic;

namespace Hospitalzinho.Entidades
{
    public class Sala
    {
        public virtual long Id { get; set; }
        public virtual string Numero { get; set; } // Ex: "Consultório 12", "Sala 305"
        public virtual Ala Ala { get; set; } // Ala/setor da sala
        public virtual string Tipo { get; set; } // Ex: "Consultório", "Sala de Exames", "Sala de Procedimentos"

        public virtual IList<PacienteConsulta> Consultas { get; set; } = new List<PacienteConsulta>();
    }
}
