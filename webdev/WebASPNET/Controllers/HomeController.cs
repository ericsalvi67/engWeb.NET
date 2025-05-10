using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebASPNET.Models;

namespace WebASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private List<PessoaModel> ObterPessoas() 
        {
            List<PessoaModel> listaDePessoas = new List<PessoaModel>();

            for (int i = 0; i <= 10; i++)
            {
                listaDePessoas.Add(new PessoaModel()
                {
                    Id = i,
                    Nome = " Pessoa " + i
                });
            }

            return listaDePessoas;
        }
        public IActionResult Index()
        {
            var pessoasQueVaoParaTela = ObterPessoas();

            return View(pessoasQueVaoParaTela);
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var modeloParaTela = new AboutViewModel();
            modeloParaTela.Nome = "Nome do usuário";
            modeloParaTela.Idade = 30;
            modeloParaTela.DataNascimento = DateTime.Now.AddYears(-modeloParaTela.Idade);
            modeloParaTela.Description = "Adipisicing adipisicing et excepteur irure laborum laboris irure reprehenderit cupidatat id amet ex. Duis ipsum consectetur et proident adipisicing consectetur sint nostrud aliquip eiusmod ut et laboris. Velit amet excepteur officia culpa nostrud minim. Exercitation et duis et laboris.";


            return View(modeloParaTela);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
