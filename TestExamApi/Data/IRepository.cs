using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestExamApi.Data;
public interface IRepository<T>
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetOne(int Id);
    public Task<T> Insert(T model);
    public Task Update(T model);
    public Task Delete(int Id);
}

