using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.ObterPlanoContaUseCase
{
    public class ObterPlanoContaUseCase : IObterPlanoContaUseCase
    {
        private readonly IPlanoContaService _planoContaService;

        public ObterPlanoContaUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public List<PlanoContaModel> GetListaPlanoContaModel()
        {
            return _planoContaService.ListaPlanoContaModel();
        }
    }
}