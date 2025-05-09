using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desenvolvimento_back_end.Models
{
    [Table("Usuários")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Obrigatorio colocar o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Obrigatorio colocar a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Obrigatorio colocar o perfil")]
        public Perfil Perfil { get; set; }
    }
    public enum Perfil
    {
        Admin,
        user
    }
}
