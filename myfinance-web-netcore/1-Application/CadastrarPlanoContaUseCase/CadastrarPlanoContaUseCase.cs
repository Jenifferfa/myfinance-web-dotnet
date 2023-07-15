using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;
using myfinance_web_netcore.Application.Interfaces;

namespace myfinance_web_netcore.Application.CadastrarPlanoContaUseCase
{
    public class CadastrarPlanoContaUseCase : ICadastrarPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;

        public CadastrarPlanoContaUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public void CadastrarPlanoConta(PlanoContaModel input)
        {
            _planoContaService.CadastrarPlanoConta(input);
        }
    }
}