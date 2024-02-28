using UnityEngine;
using Zenject;

namespace Installers
{
    public class SwipeServiceInstaller: MonoInstaller
    {
        [SerializeField] private SwipeService swipeService;
        
        public override void InstallBindings()
        {
            Container
                .Bind<SwipeService>()
                .FromInstance(swipeService)
                .AsSingle();
        }
    }
}