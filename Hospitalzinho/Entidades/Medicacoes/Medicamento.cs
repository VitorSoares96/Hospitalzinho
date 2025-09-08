using System;

namespace Hospitalzinho.Entidades.Medicacao
{
    public class Medicamento
    {
        public virtual long Id { get; set; }
        public virtual MedicamentoModelo Modelo { get; set; }
        public virtual string Lote { get; set; }
        public virtual DateTime DataFabricacao { get; set; }
        public virtual DateTime DataValidade { get; set; }
        public virtual int QuantidadeDisponivel { get; set; } // Quantidade em estoque
    }
}
