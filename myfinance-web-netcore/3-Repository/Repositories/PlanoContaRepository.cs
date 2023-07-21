using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Repository.Interfaces;

namespace myfinance_web_netcore.Repository
{
    public class PlanoContaRepository  : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(MyFinanceDbContext myFinanceDbContext): base(myFinanceDbContext)
        {}
    }
}