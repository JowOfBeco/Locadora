using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Filme
    { // modelo do filme com atributos utilizados, aah, utilizado notations como display para exibição do nome escolhido no front e 
        //Required para passar mensagem especifica quando o alert required estourar por falta de preenchimento
        [Display(Name = "#")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um titulo para o filme!")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "Obrigatório adicionar um preço.")]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento.")]
        [Display(Name = "Data de Lançamento")] //Notations para exibição dos nomes conforme transcritos no objeto.
        [DataType(DataType.Date)]
        public DateTime? DataLancamento { get; set; }

        [Required(ErrorMessage = "Informe a duração do filme!")]
        [Display(Name = "Duração")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar um link para o filme!")]
        [Display(Name = "URL do filme")]
        public string? Url { get; set; }

        public List<Aluguel> Alugueis { get; set; }

//Nada demais, construtor padrão e outro vazio logo a baixo para que seja possivel trabalhar demais atributos do objeto
//sem precisar passar todos os demais parametros
        public Filme(int id, string titulo, string sinopse, double preco,  DateTime dataLancamento, int duracao, string url = "https://www.youtube.com/embeded")
        {
            Id = id;
            Titulo = titulo;
            Sinopse = sinopse;
            Preco = preco;
            DataLancamento = dataLancamento;
            Duracao = duracao;
            Url = url;
        }

        public Filme() 
        {              
        }
    }
}
