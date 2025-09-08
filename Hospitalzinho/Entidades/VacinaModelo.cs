using System;
using System.Collections.Generic;

namespace Hospitalzinho.Entidades
{
    public class VacinaModelo
    {
        public int Id { get; set; } // Identificador único do modelo
        public string Nome { get; set; } // Nome da vacina, ex: "Covid-19 Pfizer"
        public string Fabricante { get; set; } // Ex: "Pfizer"
        public string Tipo { get; set; } // Ex: "RNA mensageiro", "Inativada"
        public string Indicacao { get; set; } // Quem deve tomar
        public int NumeroDoses { get; set; } // Total de doses previstas
        public TimeSpan IntervaloEntreDoses { get; set; } // Intervalo sugerido entre doses

        public List<Vacina> Vacinas { get; set; } = new List<Vacina>(); // Vacinas físicas produzidas a partir desse modelo
    }
}
