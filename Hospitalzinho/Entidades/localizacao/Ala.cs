using System.Collections.Generic;

namespace Hospitalzinho.Entidades
{
    public class Ala
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; } // Ex: "Ala Norte", "Ala Pediatria"
        public virtual IList<Quarto> Quartos { get; set; } = new List<Quarto>();
    }
}
