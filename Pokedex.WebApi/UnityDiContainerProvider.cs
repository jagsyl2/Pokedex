using Pokedex.BusinessLayer;
using Pokedex.DataLayer;
using System;
using Unity;
using Unity.Injection;

namespace Pokedex.WebApi
{
    public class UnityDiContainerProvider
    {
        public IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IPokemonService, PokemonService>();
            container.RegisterType<IDatabaseManagementService, DatabaseManagementService>();

            container.RegisterFactory<Func<IPokedexDbContext>>((ctx => new Func<IPokedexDbContext>(() => new PokedexDbContext())));

            return container;
        }
    }
}
