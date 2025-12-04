using SistemaCadastroDeContatos2.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroDeContatos2.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Login é obrigatório.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Perfil do usuário é obrigatório.")]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatória.")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
