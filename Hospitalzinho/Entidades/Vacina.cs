using Hospitalzinho.Entidades.EspecificaçõesHospital;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hospitalzinho.Entidades
{
    public class Vacina
    {
        public virtual int Id { get; set; } // Identificador único do lote
        public virtual string Lote { get; set; } // Lote da vacina
        public virtual DateTime DataProducao { get; set; }
        public virtual DateTime DataValidade { get; set; }
        public virtual int QuantidadeDisponivel { get; set; } // Quantidade disponível no estoque
        [Required]
        public virtual VacinaModelo VacinaModelo { get; set; } // Referência ao modelo
        [Required]
        public virtual HospitalUnidade Hospital { get; set; }
    }
}
