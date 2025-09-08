using System;

namespace Hospitalzinho.Entidades.PacientePasta
{
    public class PacienteVacinacao
    {
        public int Id { get; set; } // Identificador único
        public int PacienteId { get; set; } // FK do paciente
        public int VacinaId { get; set; } // FK da vacina aplicada
        public Vacina Vacina { get; set; } // Referência à vacina aplicada
        public DateTime DataAplicacao { get; set; } // Data em que foi aplicada
        public int DoseNumero { get; set; } // Ex: 1, 2, reforço
        public string Observacoes { get; set; } // Observações médicas, se houver
    }
}
