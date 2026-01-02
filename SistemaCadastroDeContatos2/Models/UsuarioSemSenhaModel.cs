using SistemaCadastroDeContatos2.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroDeContatos2.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Login é obrigatório.")]
        public string Login { get; set; } = string.Empty;
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Perfil do usuário é obrigatório.")]
        public PerfilEnum Perfil { get; set; }
        
    }
}
