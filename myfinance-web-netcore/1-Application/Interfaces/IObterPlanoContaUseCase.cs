using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Application.Interfaces
{
    public interface IObterPlanoContaUseCase
    {
        List<PlanoContaModel> GetListaPlanoContaModel();
    }
}