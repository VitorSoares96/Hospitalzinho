using Hospitalzinho.Entidades.PacientePasta;
using System.ComponentModel.DataAnnotations;

public class PacienteConvenio
{
    public virtual long Id { get; set; }
    [Required]
    public virtual Paciente Paciente { get; set; }
    [Required]

    public virtual Convenio Convenio { get; set; }
    [Required]
    public virtual string NumeroCarteirinha { get; set; }
    public virtual DateTime? Validade { get; set; }
    public virtual bool Ativo { get; set; }
}
