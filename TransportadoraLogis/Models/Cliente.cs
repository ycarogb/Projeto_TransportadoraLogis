using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportadoraLogis.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string eMail { get; set; }
        public string Telefone { get; set; }

        [NotMapped]
        public List<Produto> produtos { get; set; }

    }
}
