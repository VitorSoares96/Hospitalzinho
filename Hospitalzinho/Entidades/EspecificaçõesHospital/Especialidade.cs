using System.ComponentModel.DataAnnotations;

using FGB.Entidades;
namespace Hospitalzinho.Entidades.EspecificaçõesHospital
{
    public class Especialidade : EntidadeBase
    {
        [Required]
        public virtual string Nome { get; set; } = null!;

        // Relacionamentos
        public virtual List<ProfissionalSaude> Profissionais { get; set; } = new();
    }

}
