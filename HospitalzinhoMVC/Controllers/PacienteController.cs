using Microsoft.AspNetCore.Mvc;

namespace HospitalzinhoMVC.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consulta(string cpfPaciente)
        {
            if (String.IsNullOrWhiteSpace(cpfPaciente))
            {
                Console.WriteLine("CPF inválido ou vazio");
                return View();
            }

            cpfPaciente = cpfPaciente.Replace(".", "").Replace("-", "");

            if (cpfPaciente.Any(char.IsLetter))
            {
                Console.WriteLine("CPF não pode conter letras");
                return View();
            }

            return View();
        }
    }
}
    