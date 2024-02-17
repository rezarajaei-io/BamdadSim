using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using Mapster;
using Repository.DTO;

namespace Repository.Services
{
    public class GenericRepository<TEntity, TViewModel> where TEntity : class
    {
        public BamdadSimEntities _dbContext;

        DbSet<TEntity> _dbset;
        public GenericRepository(BamdadSimEntities context)
        {
            _dbContext = context;
            _dbset = context.Set<TEntity>();
        }

        public virtual IEnumerable<TViewModel> ShowGrid()
        {
           // IQueryable<TEntity> query = _dbset;
            //if (where != null)
            //{
            //    query = query.Where(where);
            //}

            //if (orderby != null)
            //{
            //    query = orderby(query);
            //}
            //if (includes != "")
            //{
            //    foreach (var include in includes.Split(','))
            //    {
            //        query = query.Include(include);
            //    }
            //}
            IEnumerable<TViewModel> query = _dbset.ProjectToType<TViewModel>();
            return query;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }
        public virtual void Add(TViewModel vm)
        {
            var items = vm.Adapt<TEntity>();
            _dbset.Add(items);
            this.Save();
        }
        public virtual void Update(TViewModel vm)
        {
            var items = vm.Adapt<TEntity>();

            _dbset.Attach(items);
            _dbContext.Entry(items).State = EntityState.Modified;
        }
        public virtual void Delete(TViewModel vm)
        {
            var entity = vm.Adapt<TEntity>();

            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
            this.Save();

        }
        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
            this.Save();

        }
        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
