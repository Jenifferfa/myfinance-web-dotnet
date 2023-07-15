using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Repository.Interfaces;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Services.PlanoContaServices
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly IPlanoContaRepository _planoContaRepository;

        public PlanoContaService(IPlanoContaRepository planoContaRepository)
        {
            _planoContaRepository = planoContaRepository;
        }

        public void CadastrarPlanoConta(PlanoContaModel input)
        {
            var planoConta = new PlanoConta()
            {
                Id = input.Id,
                Descricao = input.Descricao,
                Tipo = input.Tipo
            };

            _planoContaRepository.CadastrarPlanoConta(planoConta);
        }

        public List<PlanoContaModel> ListaPlanoContaModel()
        {
            var lista = new List<PlanoContaModel>();
            var listaPlanoContas = _planoContaRepository.PlanoContas();    

            foreach(var item in listaPlanoContas)
            {
                var planoContaModel = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                lista.Add(planoContaModel);
            }
            return lista;
        } 
    }
}