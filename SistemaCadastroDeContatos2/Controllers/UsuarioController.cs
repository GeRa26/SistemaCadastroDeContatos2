using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeContatos2.Models;
using SistemaCadastroDeContatos2.Repositorio;

namespace SistemaCadastroDeContatos2.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {

                TempData["MensagemFalha"] = $"Não conseguimos cadastrar seu usuário! ERRO:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
