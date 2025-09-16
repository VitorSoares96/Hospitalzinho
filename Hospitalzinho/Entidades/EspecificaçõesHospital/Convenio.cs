using Hospitalzinho.Entidades.PacientePasta;

public class Convenio
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; } = null!;
    public virtual string? Cnpj { get; set; }
    public virtual string? Telefone { get; set; }
    public virtual string? Endereco { get; set; }
    public virtual List<Paciente> Pacientes { get; set; } = new();
}
