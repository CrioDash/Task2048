using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ChangeIconPanel:MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener( () => _diContainer.Resolve<IconPanel>().ChangeState());
        }
    }
}