using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IServives
{
    public interface IGenericRepositoryService<TEntity, TViewModel> where TEntity : class
    {
        IEnumerable<TViewModel> ShowGrid();
       
       TEntity GetById(object id);

       TEntity Add(TViewModel entity);

        void Delete(TViewModel entity);

        void Delete(object id);
      
        void Save();
       
    }
}
