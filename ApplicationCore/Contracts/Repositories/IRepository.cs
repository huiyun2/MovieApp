namespace ApplicationCore.Contracts.Repositories;

// we are gonna create a generic repository interface where T is gonna be class of entities
// Base repository is gonna have commonly used CRUD methods
public interface IRepository<T> where T: class
{
   Task<T> GetById(int id);
   Task<IEnumerable <T>> GetAll();
   Task<T> Add(T entity);
   Task<T> Update(T enitity);
   Task<T> Delete(T entity);

}