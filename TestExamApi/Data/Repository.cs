using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestExamApi.Data;

namespace deseaseId.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext dbContext;

    private DbSet<T> _Table;
    public Repository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
        _Table = dbContext.Set<T>();
    }
    public async Task Delete(int Id)
    {
        T model = _Table.Find(Id);
        if (model != null)
        {
            _Table.Remove(model);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _Table.ToListAsync();
    }

    public async Task<T> GetOne(int Id)
    {
        return await _Table.FindAsync(Id);

    }

    public async Task<T> Insert(T model)
    {
        var result = await _Table.AddAsync(model);
        await dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Update(T model)
    {
        if (model != null)
        {
            _Table.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

    }


}