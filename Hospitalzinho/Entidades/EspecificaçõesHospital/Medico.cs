using System;
using System.Collections.Generic;

namespace Hospitalzinho.Entidades
{
    public class Medico
    {
        public virtual long Id { get; set; } // Identificador único
        public virtual string Nome { get; set; } // Nome completo
        public virtual string CRM { get; set; } // Registro no conselho médico
        public virtual EspecialidadeMedica Especialidade { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Email { get; set; }
    }
}
