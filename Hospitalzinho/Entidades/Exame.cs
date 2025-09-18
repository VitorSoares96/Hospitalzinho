using Hospitalzinho.Entidades.PacientePasta;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospitalzinho.Entidades
{
    public class Exame
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; } // Ex: "Sangue", "Raio-X", "Tomografia"
        public virtual string Descricao { get; set; } // Explicação do exame, quando é indicado
        public virtual string LaboratorioPadrao { get; set; } // Laboratório recomendado
        public virtual IList<PacienteExame> Exames { get; set; } = new List<PacienteExame>();
    }
}
