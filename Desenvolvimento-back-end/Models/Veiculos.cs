using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desenvolvimento_back_end.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Obrigatorio inserir o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatorio inserir a Placa")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Obrigatorio inserir o Ano de Fabricação")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Obrigatorio inserir o Ano do Modelo")]
        [Display(Name = "Ano do Modelo")]
        public int AnoModelo { get; set; }

        public ICollection<Consumo> Consumos{ get; set; }
    }
}
