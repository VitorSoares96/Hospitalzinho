using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitalzinho.Entidades
{
    public class Paciente
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CNS { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string NomePai { get; set; }
        public virtual string NomeMae { get; set; }
        public virtual string CpfPai { get; set; }
        public virtual string CpfMae { get; set ; }
        public virtual bool Atividade { get; set; }


    }
}
