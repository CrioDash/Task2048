using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class IconsPanelInstaller:MonoInstaller
    {
        [SerializeField] private IconPanel iconPanel;
    
        public override void InstallBindings()
        {
            Container
                .Bind<IconPanel>()
                .FromInstance(iconPanel)
                .AsSingle();
        }
    }
}