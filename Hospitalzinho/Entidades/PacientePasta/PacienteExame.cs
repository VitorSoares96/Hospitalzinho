using System;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteExame
    {
        public virtual long Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual DateTime DataExame { get; set; }
        public virtual Exame tipoExame { get; set; } // Ex: "Sangue", "Raio-X"
        public virtual string Laboratorio { get; set; }
        public virtual string Resultados { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual Medico MedicoResponsavel { get; set; }
    }
}
