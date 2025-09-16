using Hospitalzinho.Entidades.EspecificaçõesHospital;
using System;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteVacinacao
    {
        public virtual long Id { get; set; }
        public virtual PacienteProntuario Prontuario { get; set; }
        public virtual Vacina Vacina { get; set; }
        public virtual ProfissionalSaude ProfResponsavel { get; set; }
        public virtual DateTime DataAplicacao { get; set; }
        public virtual int DoseNumero { get; set; }
        public virtual string Observacoes { get; set; }

    }
}
