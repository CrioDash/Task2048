using UnityEngine;
using Zenject;

namespace Installers
{
    public class GridInstaller : MonoInstaller
    {
        [SerializeField] private PlayerGrid playerGrid;
    
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerGrid>()
                .FromInstance(playerGrid)
                .AsSingle();
        }
    }
}