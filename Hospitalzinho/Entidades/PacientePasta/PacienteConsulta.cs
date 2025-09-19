using Hospitalzinho.Entidades.EspecificaçõesHospital;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteConsulta
    {
        public virtual long Id { get; set; }
        [Required]
        public virtual PacienteProntuario Prontuario { get; set; }
        public virtual DateTime DataConsulta { get; set; }
        [Required]
        public virtual ProfissionalSaude ProfResponsavel { get; set; }
        public virtual string Observacoes { get; set; }
        [Required]
        public virtual Sala Sala { get; set; }
        public virtual IList<PacienteExame> Exames { get; set; } = new List<PacienteExame>();
        public virtual HospitalUnidade Hospital { get; set; }
    }
}
