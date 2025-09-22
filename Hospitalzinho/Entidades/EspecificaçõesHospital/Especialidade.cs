using System.ComponentModel.DataAnnotations;

namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class Especialidade
    {
        public virtual long Id { get; set; }
        [Required]
        public virtual string Nome { get; set; } = null!;

        // Relacionamentos
        public virtual List<ProfissionalSaude> Profissionais { get; set; } = new();
    }

}
