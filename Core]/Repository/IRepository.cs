using Core.Entity;

namespace Core.Repository;

public interface IRepository<T> where T: EntityBase
{
    IList<T> ObterTodos();
    T ObterPorID(int id);
    void Cadastrar(T entidade);
    void Alterar (T entidade);
    void Deletar (int  id);

}
