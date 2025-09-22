using Hospitalzinho.Entidades.PacientePasta;
using System.ComponentModel.DataAnnotations;


namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class Receita
    {
        public virtual long Id { get; set; }
        public virtual DateTime Data { get; set; }

        // FK - Paciente e Profissional que prescreveu
        [Required]
        public virtual Paciente Paciente { get; set; }
        [Required]
        public virtual ProfissionalSaude Profissional { get; set; }

        // Relacionamentos
        public virtual IList<ItemReceita> Itens { get; set; } = new List<ItemReceita>();
        public virtual HospitalUnidade Hospital { get; set; }
    }
}
