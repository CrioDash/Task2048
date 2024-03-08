using System;
using System.Collections;

using Entitas;
using Sources.Systems;
using UI;
using UnityEngine;
using Zenject;

public class MenuController : MonoBehaviour
{
    [Inject] private IconPanel _iconPanel;

    public static IconPanel IconPanel;
    
    
    private Systems _systems;
    private Contexts _contexts;

    void Start()
    {
        IconPanel = _iconPanel;
        _contexts = Contexts.sharedInstance;
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new ViewSystems(contexts));

    }
    
}
