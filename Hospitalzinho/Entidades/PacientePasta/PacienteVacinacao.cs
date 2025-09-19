using Hospitalzinho.Entidades.EspecificaçõesHospital;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteVacinacao
    {
        public virtual long Id { get; set; }
        [Required]
        public virtual PacienteProntuario Prontuario { get; set; }
        [Required]
        public virtual Vacina Vacina { get; set; }
        [Required]
        public virtual ProfissionalSaude ProfResponsavel { get; set; }
        public virtual DateTime DataAplicacao { get; set; }
        public virtual int DoseNumero { get; set; }
        public virtual string Observacoes { get; set; }
        [Required]
        public virtual HospitalUnidade Hospital { get; set; }

    }
}
