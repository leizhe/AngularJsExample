using Example.Domain.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
namespace Example.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity FindSingle(Expression<Func<TEntity, bool>> exp = null);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> exp = null);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);

        int GetCount(Expression<Func<TEntity, bool>> exp = null);

        void Add(TEntity entity);
        
        void Update(TEntity entity);

        void Delete(TEntity entity);
        
        void Delete(ICollection<TEntity> entityCollection);

        void Commit();
    }
}
