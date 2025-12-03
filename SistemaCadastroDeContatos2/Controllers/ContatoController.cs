using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeContatos2.Models;
using SistemaCadastroDeContatos2.Repositorio;

namespace SistemaCadastroDeContatos2.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            var contatos =_contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult AvisoApagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Excluir(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Não conseguimos apagador seu contato!";
                }
                    return RedirectToAction("Index");
            }
            catch (Exception erro )
            {

                TempData["MensagemFalha"] = $"Não conseguimos apagar seu contato! ERRO:{erro.Message}";
                return RedirectToAction("Index"); ;
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemFalha"] = $"Não conseguimos cadastrar seu contato! ERRO:{erro.Message}";
                return RedirectToAction("Index"); 
            }          
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemFalha"] = $"Não conseguimos alterar seu contato! ERRO:{erro.Message}";
                return RedirectToAction("Index"); 
            }
        }

    }
}