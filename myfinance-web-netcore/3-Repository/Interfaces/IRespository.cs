namespace myfinance_web_netcore.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Cadastrar(TEntity Entidade);
        void Excluir(int id);
        List<TEntity> ListarRegistros();
        TEntity RetornarRegistro(int Id);
    }
}