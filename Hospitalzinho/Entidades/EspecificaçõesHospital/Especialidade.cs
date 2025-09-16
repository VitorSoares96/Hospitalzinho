public class Especialidade
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;

    // Relacionamentos
    public List<ProfissionalSaude> Profissionais { get; set; } = new();
}
