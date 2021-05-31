using Pokedex.DataLayer;
using System;

namespace Pokedex.BusinessLayer
{
    public interface IDatabaseManagementService
    {
        void EnsureDatabaseCreation();
    }

    public class DatabaseManagementService : IDatabaseManagementService
    {
        private Func<IPokedexDbContext> _dbContextFactoryMethod;

        public DatabaseManagementService(Func<IPokedexDbContext> dbContextFactoryMethod)
        {
            _dbContextFactoryMethod = dbContextFactoryMethod;
        }

        public void EnsureDatabaseCreation()
        {
            using (var context = _dbContextFactoryMethod())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
