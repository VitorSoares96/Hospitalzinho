using Hospitalzinho.Entidades.EspecificaçõesHospital;
using Hospitalzinho.Entidades.PacientePasta;
using System.ComponentModel.DataAnnotations;

public class Convenio
{
    public virtual int Id { get; set; }
    [Required]
    public virtual string Nome { get; set; } = null!;
    public virtual string? Cnpj { get; set; }
    public virtual string? Telefone { get; set; }
    public virtual string? Endereco { get; set; }
    public virtual List<Paciente> Pacientes { get; set; } = new();
    [Required]
    public virtual Hospital Hospital { get; set; }
}
