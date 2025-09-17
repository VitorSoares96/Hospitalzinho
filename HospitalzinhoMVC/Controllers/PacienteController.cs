using Microsoft.AspNetCore.Mvc;

namespace HospitalzinhoMVC.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
