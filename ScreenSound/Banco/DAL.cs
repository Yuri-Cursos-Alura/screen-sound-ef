using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal abstract class DAL<TEntity> : IDisposable where TEntity : class
{
    protected readonly ScreenSoundContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public DAL(ScreenSoundContext? context = null)
    {
        _context = context ?? new ScreenSoundContext();
        _dbSet = _context.Set<TEntity>();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public virtual void Add(TEntity toAdd)
    {
        _dbSet.Add(toAdd);
        _context.SaveChanges();
    }
    public virtual void Add(IEnumerable<TEntity> toAdd)
    {
        foreach (var entity in toAdd)
            _dbSet.Add(entity);

        _context.SaveChanges();
    }
    public virtual void Remove(TEntity toRemove)
    {
        _dbSet.Remove(toRemove);
        _context.SaveChanges();
    }
    public virtual void Remove(IEnumerable<TEntity> toRemove)
    {
        foreach (var entity in toRemove)
            _dbSet.Remove(entity);

        _context.SaveChanges();
    }
    public virtual void Update(TEntity toUpdate)
    {
        _dbSet.Update(toUpdate);
        _context.SaveChanges();
    }
    public virtual void Update(IEnumerable<TEntity> toUpdate)
    {
        foreach (var entity in toUpdate)
            _dbSet.Update(entity);

        _context.SaveChanges();
    }
    public virtual IEnumerable<TEntity> GetAll() => _dbSet;

}
