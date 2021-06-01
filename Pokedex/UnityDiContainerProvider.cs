using Pokedex.BusinessLayer;
using Pokedex.DataLayer;
using System;
using Unity;

namespace Pokedex
{
    public class UnityDiContainerProvider
    {
        public IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IIoHelper, IoHelper>();
            container.RegisterType<IPokemonService, PokemonService>();
            container.RegisterType<IDatabaseManagementService, DatabaseManagementService>();

            container.RegisterFactory<Func<IPokedexDbContext>>((ctx => new Func<IPokedexDbContext>(() => new PokedexDbContext())));

            return container;
        }
    }
}
