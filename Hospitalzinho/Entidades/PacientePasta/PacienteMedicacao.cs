using Hospitalzinho.Entidades.Medicacao;
using Hospitalzinho.Entidades.PacientePasta;
using System.ComponentModel.DataAnnotations;

public class PacienteMedicacao
{
    public virtual long Id { get; set; }
    [Required]
    public virtual PacienteProntuario Prontuario { get; set; }
    [Required]
    public virtual MedicamentoModelo Modelo { get; set; } // Tipo do remédio prescrito
    public virtual string DosagemPrescrita { get; set; } // Ex: "1 comprimido 2x ao dia"
    public virtual string Frequencia { get; set; } // Ex: "12 em 12 horas"
    public virtual string ViaAdministracao { get; set; } // Oral, Injetável
    public virtual string Observacoes { get; set; }
    public virtual DateTime DataInicio { get; set; }
    public virtual DateTime? DataFim { get; set; } // null = uso contínuo
}
