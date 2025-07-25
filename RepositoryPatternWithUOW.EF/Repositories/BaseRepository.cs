using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        // This is a base repository class that implements the IBaseRepository interface.
        // It can be extended by other repositories to provide common functionality.

        // _context is the database context that will be used to access the database.
        // this is the only place that can access the database.
        protected ApplicationDbContext _context;

        // in the constructor, we inject the ApplicationDbContext
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // The T is the class type that will be used in the repository.
        public T GetById(int id)
        {
            // set is used to access the DbSet of the specified type T
            // then we use Find to get the entity by its id
            return _context.Set<T>().Find(id);
        }
    }
}
