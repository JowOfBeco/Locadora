using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Aluguel
    {   
     // modelo do aluguel com atributos utilizados, aah, utilizado notations como display para exibição do nome escolhido no front e 
        //Required para passar mensagem especifica quando o alert required estourar por falta de preenchimento
        // TODO: refatorar para somente 2 váriaveis de data 
        [Display(Name = "#")]
        public int id { get; set; }

        [Display(Name = "Data e hora da locação")]
        public DateTime dataHora { get; set; }

        [Display(Name = "Data de devolução")]
        public DateTime devolucao { get; set; }

        [Required(ErrorMessage = "Informe dias para devolução")]
        [Display(Name ="Qtd dias do aluguel")]
        public int devolucaoDias { get; set; }
        [Required(ErrorMessage = "Mandatório selecionar titulo")]
        [Display(Name ="Filme")]
        public int? filmeId { get; set; }

        public Filme filme { get; set; }

    }
}
