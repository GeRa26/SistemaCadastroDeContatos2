using SistemaCadastroDeContatos2.Models;

namespace SistemaCadastroDeContatos2.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Excluir(int id);

    }
}
