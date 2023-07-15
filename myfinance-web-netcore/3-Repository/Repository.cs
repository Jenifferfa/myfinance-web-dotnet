using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Repository
{
    public abstract class Repository<TEntity> : IRespository<TEntity> where TEntity: EntityBase, new()
    {
        protected DbContext Db;
        protected DbSet<TEntity> DbSetContext;

        protected Repository(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<TEntity>();
        }

        public void Cadastrar(TEntity Entidade)
        {
            if(Entidade.Id == null)
                DbSetContext.Add(Entidade);
            else{
                DbSetContext.Attach(Entidade);
                Db.Entry(Entidade).State = EntityState.Modified;
            }
            Db.SaveChanges();
        }

        public void Excluir(int Id)
        {   
            var entidade = new TEntity() {Id = Id};
            Db.Attach(entidade);
            Db.Remove(entidade);
            Db.SaveChanges();
        }

        public List<TEntity> ListarRegistros()
        {
            return DbSetContext.ToList();
        }

        public TEntity RetornarRegistro(int Id)
        {
            return DbSetContext.Where(x => x.Id == Id).First();
        }
        
    }
}