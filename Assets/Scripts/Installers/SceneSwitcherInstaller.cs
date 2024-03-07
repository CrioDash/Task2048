using UnityEngine;
using Zenject;

namespace Installers
{
    public class SceneSwitcherInstaller:MonoInstaller
    {
        [SerializeField] private SceneSwitcher sceneSwitcher;
    
        public override void InstallBindings()
        {
            Container
                .Bind<SceneSwitcher>()
                .FromInstance(sceneSwitcher)
                .AsSingle();
        }
    }
}