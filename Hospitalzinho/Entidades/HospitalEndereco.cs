using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hospitalzinho.Entidades
{
    public class HospitalEndereco
    {
        public long Id { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua {  get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
