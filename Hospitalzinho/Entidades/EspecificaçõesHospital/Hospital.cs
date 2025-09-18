using Hospitalzinho.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class Hospital
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        public string CNES { get; set; }
        public string CNPJ { get; set; }
        public TipoUnidade TipoUnidade { get; set; }
        public HospitalEndereco Endereco { get; set; }
    }
}
