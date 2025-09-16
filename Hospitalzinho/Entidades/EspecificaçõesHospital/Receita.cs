using Hospitalzinho.Entidades.PacientePasta;


namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class Receita
    {
        public virtual long Id { get; set; }
        public virtual DateTime Data { get; set; }

        // FK - Paciente e Profissional que prescreveu
        public virtual Paciente Paciente { get; set; }
        public virtual ProfissionalSaude Profissional { get; set; }

        // Relacionamentos
        public virtual IList<ItemReceita> Itens { get; set; } = new List<ItemReceita>();
    }
}
