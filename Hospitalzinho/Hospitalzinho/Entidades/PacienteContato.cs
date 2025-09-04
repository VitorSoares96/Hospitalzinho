using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitalzinho.Entidades
{
    public class PacienteContato
    {
        public virtual long Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual string TelefoneResidencial { get; set; }
        public virtual string TelefoneCelular { get; set; }
        public virtual string Email { get; set; }
    }
}
