using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportadoraLogis.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Display(Name = "Código do Produto")]
        public int Codigo { get; set; }
        [Display(Name = "Destino Final")]
        public string Destino { get; set; }
        [Display(Name = "Cliente")]
        public string Cliente { get; set; }
        [Display(Name = "Data de saída")]
        [DataType(DataType.Date)]
        public DateTime DataSaida { get; set; }
        [Display(Name = "Qtde")]
        public int Quantidade { get; set; }

    }
}
