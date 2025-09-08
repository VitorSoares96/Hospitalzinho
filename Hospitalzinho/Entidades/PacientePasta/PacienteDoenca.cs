using System;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteDoencaCronica
    {
        public virtual long Id { get; set; }
        public virtual PacienteProntuario Prontuario { get; set; }
        public virtual DoencaCronicaModelo Modelo { get; set; }
        public virtual DateTime DataDiagnostico { get; set; }
        public virtual string Estagio { get; set; } // Ex: "Leve", "Moderada", "Avançada"
        public virtual string Observacoes { get; set; }
        public virtual bool EmTratamento { get; set; }
    }
}
