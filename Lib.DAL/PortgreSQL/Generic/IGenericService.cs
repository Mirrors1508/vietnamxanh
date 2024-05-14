using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generic
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Insert data into a table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Create(TEntity entity);
        Task<int> CreateAsync(TEntity entity);

        /// <summary>
        ///  Update data in a table
        /// </summary>
        /// <param name="entity"></param>
        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);

      
    }
}
