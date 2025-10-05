using FGB.Entidades;

namespace Hospitalzinho.Entidades
{
    public class Alergia : EntidadeBase
    {
        public virtual string Nome { get; set; }
        public virtual TipoAlergia Tipo { get; set; }
    }
}