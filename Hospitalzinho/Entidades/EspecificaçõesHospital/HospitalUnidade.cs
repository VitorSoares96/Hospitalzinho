using Hospitalzinho.Entidades.PacientePasta;
using Hospitalzinho.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class HospitalUnidade
    {
        public virtual long Id { get; set; }
        [Required]
        public virtual string Nome { get; set; }
        public TipoUnidade TipoUnidade { get; set; }
        public HospitalEndereco Endereco { get; set; }
        
        public virtual List<Ala> Alas { get; set; } = new();
        public virtual List<ProfissionalSaude> ProfissionaisSaude { get; set; } = new();
        public virtual List<Convenio> Convenios { get; set; } = new();
        public virtual List<PacienteCirurgia> PacientesCirurgia { get; set; } = new();
        public virtual List<PacienteExame> PacienteExames { get; set; } = new();
        public virtual List<PacienteInternacao> PacientesInternacao { get; set; } = new();
        public virtual List<PacienteConsulta> PacientesConsulta { get; set; } = new();  
        public virtual List<PacienteVacinacao> PacientesVacinacao { get; set; } = new();
        public virtual List<Receita> Receitas { get; set; } = new();
        public virtual Hospital InstituicaoPai { get; set; }
    }
}
