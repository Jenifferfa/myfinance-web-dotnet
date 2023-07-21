using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Application.Interfaces;

namespace myfinance_web_netcore.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IObterPlanoContaUseCase _obterPlanoContaUseCase;
        private readonly ICadastrarPlanoContaUseCase _cadastrarPlanoContaUseCase;

        public PlanoContaController(
            ILogger<PlanoContaController> logger,
            MyFinanceDbContext myFinanceDbContext,
            IObterPlanoContaUseCase obterPlanoContaUseCase,
            ICadastrarPlanoContaUseCase cadastrarPlanoContaUseCase
        )
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
            _obterPlanoContaUseCase = obterPlanoContaUseCase;
            _cadastrarPlanoContaUseCase = cadastrarPlanoContaUseCase;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.listaPlanoConta = _obterPlanoContaUseCase.ListaPlanoContaModel();
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            var planoConta = new PlanoContaModel();

            if (id != null)
            {
                var PlanoContaDomain = _myFinanceDbContext.PlanoConta
                .Where(x => x.Id == id)
                .FirstOrDefault();

                planoConta.Id = PlanoContaDomain.Id;
                planoConta.Descricao = PlanoContaDomain.Descricao;
                planoConta.Tipo = PlanoContaDomain.Tipo;
            }

            return View(planoConta);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel input)
        {
            var planoConta = new PlanoConta(){
                Id = input.Id,
                Descricao = input.Descricao,
                Tipo = input.Tipo
            };

            if (planoConta.Id == null)
                _myFinanceDbContext.PlanoConta.Add(planoConta);
            else{
                _myFinanceDbContext.PlanoConta.Attach(planoConta);
                _myFinanceDbContext.Entry(planoConta).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var planoConta = new PlanoConta() { Id = id };
            _myFinanceDbContext.PlanoConta.Remove(planoConta);
            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}