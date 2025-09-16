using Hospitalzinho.Entidades.PacientePasta;

public class Convenio
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Cnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Endereco { get; set; }
    public List<Paciente> Pacientes { get; set; } = new();
}
