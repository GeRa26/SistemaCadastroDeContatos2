using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeContatos2.Models;
using SistemaCadastroDeContatos2.Repositorio;

namespace SistemaCadastroDeContatos2.Controllers
{   
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null && usuario.SenhaValida(loginModel.Senha))
                    {
                        return RedirectToAction("Index", "Home");
                    }   
                        TempData["MensagemErro"] = "Login ou senha inválidos!";    
                }               
                return View("Index");
            }           
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro! Detalhes: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
