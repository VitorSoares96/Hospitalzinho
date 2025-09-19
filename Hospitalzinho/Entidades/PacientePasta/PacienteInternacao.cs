using Hospitalzinho.Entidades.EspecificaçõesHospital;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteInternacao
    {
        public virtual long Id { get; set; }
        [Required]
        public virtual PacienteProntuario Prontuario { get; set; }
        public virtual DateTime DataInternacao { get; set; }
        public virtual DateTime? DataAlta { get; set; } // Pode ser nulo enquanto o paciente estiver internado
        [Required]
        public virtual Quarto Quarto { get; set; } // Ex: "101A"
        public virtual string Motivo { get; set; }
        [Required]
        public virtual ProfissionalSaude ProfResponsavel { get; set; }
        public virtual string Observacoes { get; set; }
        [Required]
        public virtual HospitalUnidade Hospital { get; set; }
    }
}
