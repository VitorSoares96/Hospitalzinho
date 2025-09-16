namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class Especialidade
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; } = null!;

        // Relacionamentos
        public virtual List<ProfissionalSaude> Profissionais { get; set; } = new();
    }

}
