using Pokedex.BusinessLayer;
using Pokedex.DataLayer;
using System;
using Unity;
using Unity.Injection;

namespace Pokedex
{
    public class UnityDiContainerProvider
    {
        public IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IPokemonService, PokemonService>();

            container.RegisterType<Func<IPokedexDbContext>>(
                new InjectionFactory(ctx => new Func<IPokedexDbContext>(() => new PokedexDbContext())));

            return container;
        }
    }
}
