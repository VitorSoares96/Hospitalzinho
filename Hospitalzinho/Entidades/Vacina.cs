using System;

namespace Hospitalzinho.Entidades
{
    public class Vacina
    {
        public int Id { get; set; } // Identificador único do lote
        public string Lote { get; set; } // Lote da vacina
        public DateTime DataProducao { get; set; }
        public DateTime DataValidade { get; set; }
        public int QuantidadeDisponivel { get; set; } // Quantidade disponível no estoque
        public int VacinaModeloId { get; set; } // FK para o modelo da vacina
        public VacinaModelo VacinaModelo { get; set; } // Referência ao modelo
    }
}
