using Hospitalzinho.Entidades.EspecificaçõesHospital;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hospitalzinho.Entidades.Medicacao
{
    public class Medicamento
    {
        public virtual long Id { get; set; }
        [Required]
        public virtual MedicamentoModelo Modelo { get; set; }
        public virtual string Lote { get; set; }
        public virtual DateTime DataFabricacao { get; set; }
        public virtual DateTime DataValidade { get; set; }
        public virtual int QuantidadeDisponivel { get; set; } // Quantidade em estoque
        public virtual HospitalUnidade Hospital { get; set; }
    }
}
