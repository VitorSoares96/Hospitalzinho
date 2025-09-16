using Hospitalzinho.Entidades.EspecificaçõesHospital;
using Hospitalzinho.Entidades.Medicacao;

namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class ItemReceita
    {
        public virtual long Id { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual string Posologia { get; set; } // Ex: "1 comprimido a cada 12h"

        // FK - Receita
        public virtual Receita Receita { get; set; }

        // FK - MedicamentoModelo (não lote específico)
        public virtual MedicamentoModelo Modelo { get; set; }
    }
}
