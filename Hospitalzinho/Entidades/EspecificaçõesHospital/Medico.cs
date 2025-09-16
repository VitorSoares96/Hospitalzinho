using Hospitalzinho.Entidades.PacientePasta;

namespace Hospitalzinho.Entidades.EspecificaçõesHospital;
public class ProfissionalSaude
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; } = null!;
    public virtual string? RegistroProfissional { get; set; } // CRM, COREN etc.

    // FK
    public virtual int EspecialidadeId { get; set; }
    public virtual Especialidade Especialidade { get; set; } = null!;

    // Relacionamentos
    public virtual List<PacienteConsulta> Consultas { get; set; } = new();
    public virtual List<Exame> ExamesSolicitados { get; set; } = new();
    public virtual List<PacienteInternacao> Internacoes { get; set; } = new();
    public virtual List<PacienteVacinacao> VacinacoesAdministradas { get; set; } = new();
    public virtual List<Receita> ReceitasPrescritas { get; set; } = new();
}
