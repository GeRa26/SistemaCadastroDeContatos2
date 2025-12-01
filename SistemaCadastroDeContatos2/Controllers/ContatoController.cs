using Microsoft.AspNetCore.Mvc;

namespace SistemaCadastroDeContatos2.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult AvisoApagar()
        {
            return View();
        }

    }
}