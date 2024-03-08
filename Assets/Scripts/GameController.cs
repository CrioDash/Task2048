using Entitas;
using Sources.Systems;
using UnityEngine;

public class GameController:MonoBehaviour
{
    [SerializeField] private Transform _currentTransform;

    public static Transform CurrentTransform;
    
    private Systems _systems;
    private Contexts _contexts;

    void Start()
    {
        CurrentTransform = _currentTransform;
        _contexts = Contexts.sharedInstance;
        SetGameSystem system = new SetGameSystem(_contexts);
        system.Initialize();
    }
}