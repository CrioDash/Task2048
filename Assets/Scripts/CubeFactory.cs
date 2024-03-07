using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class CubeFactory: MonoBehaviour
{
    [SerializeField]private GameObject cubePrefab;
    
    private DiContainer _diContainer;
    private PlayerGrid _playerGrid;
    
    [Inject]
    public void Construct(DiContainer diContainer, PlayerGrid playerGrid)
    {
        _diContainer = diContainer;
        _playerGrid = playerGrid;
        _playerGrid.OnShuffleEnd += Create;
    }
    
    private void OnDisable()
    {
        _playerGrid.OnShuffleEnd -= Create;
    }
    

    private void Start()
    {
        Create(2,4);
    }

    private void Create(int min, int max)
    {
        for(int i = 0; i< Random.Range(min, max); i++)
        {
            Vector2 spawnPos = _playerGrid.GetFreePos();
            
            if(spawnPos.x > 3) break;
            
            Cube cube = _diContainer.InstantiatePrefab(cubePrefab,
                _playerGrid.CubePoints[(int)spawnPos.x, (int)spawnPos.y],
                Quaternion.identity, _playerGrid.transform).GetComponent<Cube>();
            cube.SetStats(2);
            _playerGrid.Cubes[(int)spawnPos.x, (int)spawnPos.y] = cube;
        }
        
        
        
    }

}