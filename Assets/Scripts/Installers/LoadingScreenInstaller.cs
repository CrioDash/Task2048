using System.ComponentModel;
using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LoadingScreenInstaller:MonoInstaller
    {
        [SerializeField] private LoadingScreen loadingScreen;
    
        public override void InstallBindings()
        {
            Container
                .Bind<LoadingScreen>()
                .FromInstance(loadingScreen)
                .AsSingle();
        }
    }
}