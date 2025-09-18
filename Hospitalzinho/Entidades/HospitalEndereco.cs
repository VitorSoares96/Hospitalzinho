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
        [Required]
        public long Id { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Rua {  get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
