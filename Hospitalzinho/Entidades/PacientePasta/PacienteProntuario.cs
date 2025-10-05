using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using FGB.Entidades;
namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteProntuario : EntidadeBase
    {
        [Required]
        public virtual Paciente Paciente { get; set; }
        [Required]
        public virtual TipoSanguineo TipoSangue { get; set; }
        public virtual IList<Alergia> Alergias { get; set; } = new List<Alergia>();
        public virtual IList<PacienteDoencaCronica> DoencasCronicas { get; set; } = new List<PacienteDoencaCronica>();

        public virtual IList<PacienteMedicacao> MedicacoesContinuas { get; set; } = new List<PacienteMedicacao>();
        public virtual IList<PacienteCirurgia> Cirurgias { get; set; } = new List<PacienteCirurgia>();
        public virtual IList<PacienteVacinacao> Vacinacoes { get; set; } = new List<PacienteVacinacao>();
        public virtual DateTime DataAbertura { get; set; }
        public virtual DateTime UltimaAtualizacao { get; set; }

        public virtual IList<PacienteConsulta> Consultas { get; set; } = new List<PacienteConsulta>();
        public virtual IList<PacienteInternacao> Internacoes { get; set; } = new List<PacienteInternacao>();
        public virtual IList<PacienteExame> Exames { get; set; } = new List<PacienteExame>();
    }
}
