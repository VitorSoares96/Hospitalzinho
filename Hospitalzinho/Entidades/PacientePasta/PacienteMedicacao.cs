using Hospitalzinho.Entidades.Medicacao;
using System;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteMedicacao
    {
        public virtual long Id { get; set; }
        public virtual PacienteProntuario Prontuario { get; set; }
        public virtual MedicamentoModelo Modelo { get; set; } // Tipo do remédio
        public virtual string DosagemPrescrita { get; set; } // Ex: "1 comprimido 2x ao dia"
        public virtual string Frequencia { get; set; } // Ex: "12 em 12 horas"
        public virtual string ViaAdministracao { get; set; } // Oral, Injetável
        public virtual string Observacoes { get; set; }
        public virtual DateTime DataInicio { get; set; }
        public virtual DateTime? DataFim { get; set; } // Se for uso contínuo pode ficar null
    }
}
