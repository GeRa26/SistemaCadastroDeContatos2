using SistemaCadastroDeContatos2.Models;

namespace SistemaCadastroDeContatos2.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);

    }
}
