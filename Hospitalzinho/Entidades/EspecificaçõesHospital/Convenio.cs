using Hospitalzinho.Entidades.EspecificaçõesHospital;
using Hospitalzinho.Entidades.PacientePasta;
using System.ComponentModel.DataAnnotations;

public class Convenio
{
    public virtual int Id { get; set; }
    public virtual string? CNPJ { get; set; }
    [Required]
    public virtual string Nome { get; set; } = null!;
    public virtual IList<PacienteConvenio> PacienteConvenios { get; set; } = new List<PacienteConvenio>();
    public virtual IList<HospitalUnidade> HospitaisAtentidos { get; set; }
}
