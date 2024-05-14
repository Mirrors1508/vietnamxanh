using ENTITIES.Models;

namespace DAL.Generic
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        public static string _connection;

        public GenericService(string connection)
        {
            _connection = connection;
        }

        public int Create(TEntity entity)
        {
            try
            {
                using (var _DbContext = new PortgreDataContext(_connection))
                {
                    _DbContext.Set<TEntity>().Add(entity);
                    _DbContext.SaveChangesAsync();
                    return Convert.ToInt32(entity.GetType().GetProperty("id").GetValue(entity, null));
                }
            }
            catch
            {
                return 0;
            }
        }
        public async Task<int> CreateAsync(TEntity entity)
        {
            try
            {
                using (var _DbContext = new PortgreDataContext(_connection))
                {
                    await _DbContext.Set<TEntity>().AddAsync(entity);
                    await _DbContext.SaveChangesAsync();
                    return Convert.ToInt32(entity.GetType().GetProperty("id").GetValue(entity, null));
                }
            }
            catch
            {
                return 0;
            }
        }




        public int Update(TEntity entity)
        {
            try
            {
                using (var _DbContext = new PortgreDataContext(_connection))
                {
                    _DbContext.Set<TEntity>().Update(entity);
                    _DbContext.SaveChanges();
                    return Convert.ToInt32(entity.GetType().GetProperty("id").GetValue(entity, null));

                }
            }
            catch 
            {
                return 0;

            }
        }
        public async Task<int> UpdateAsync(TEntity entity)
        {
            try
            {
                using (var _DbContext = new PortgreDataContext(_connection))
                {
                    _DbContext.Set<TEntity>().Update(entity);
                    return Convert.ToInt32(entity.GetType().GetProperty("id").GetValue(entity, null));
                }
            }
            catch
            {
                return 0;

            }
        }




      

    }
}
