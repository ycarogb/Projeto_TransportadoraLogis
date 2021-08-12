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

        [Required(ErrorMessage = "Informe um Código do Produto!")]
        [Display(Name = "Código do Produto")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Informe um Destino Final!")]
        [Display(Name = "Destino Final")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Informe uma Data de saída!")]
        [Display(Name = "Data de saída")]
        [DataType(DataType.Date)]
        public DateTime DataSaida { get; set; }

        [Required(ErrorMessage = "Informe a quantidade solicitade pelo cliente!")]
        [Display(Name = "Qtde")]
        public int Quantidade { get; set; }

        public List<Cliente> listaclientes { get; set; }

        [Required(ErrorMessage = "Informe um cliente!")]
        [Display(Name = "Cliente")]
        public int? clienteId { get; set; }
        public Cliente cliente { get; set; }

    }
}
