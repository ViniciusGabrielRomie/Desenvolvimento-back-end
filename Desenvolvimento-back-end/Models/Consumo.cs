using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desenvolvimento_back_end.Models
{
    [Table("Consumo")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar a data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar o valor pago")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar a quilometragem percorrida")]
        public decimal Km { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar o tipo de combustivel")]
        [Display(Name ="Tipo de Combustivel")]
        public Combustivel Tipo { get; set; }
        [Required(ErrorMessage = "Obrigatorio informar o veiculo")]
        [Display(Name ="Veiculo")]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }
    }

    public enum Combustivel
    {
        Gasolina,
        Etanol
    }
}
