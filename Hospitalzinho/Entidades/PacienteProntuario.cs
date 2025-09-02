using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hospitalzinho.Entidades
{
    public class PacienteProntuario
    {
        public virtual long Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual string TipoSanguineo { get; set; }
        public virtual string Alergias { get; set; }
        public virtual string DoencasCronicas { get; set; }
        public virtual string MedicacoesUsoContinuo { get; set; }
        public virtual string HistoricoCirurgico { get; set; }
        public virtual string Vacinas { get; set; }
        public virtual DateTime DataAbertura { get; set; }
        public virtual DateTime UltimaAtualizacao { get; set; }

        public virtual IList<PacienteConsulta> Consultas { get; set; } = new List<Consulta>();
        public virtual IList<PacienteInternacao> Internacoes { get; set; } = new List<Internacao>();
        public virtual IList<PacienteExame> Exames { get; set; } = new List<Exame>();
    }
}
