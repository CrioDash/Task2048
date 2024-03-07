using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

public class PlayerGrid:MonoBehaviour
{
    public event Action<int, int> OnShuffleEnd;
    public event Action OnGameEnd;
    public event Action OnCubeAdded;

    private SwipeService _swipeService;

    public Vector3[,] CubePoints { get; private set; } = new Vector3[3, 3];
    public Cube[,] Cubes { get; private set; } = new Cube[3, 3];

    [Inject]
    public void Construct(SwipeService swipeService)
    {
        _swipeService = swipeService;

        _swipeService.OnSwipe += ShuffleCubes;
    }

    private void OnDisable()
    {
        _swipeService.OnSwipe -= ShuffleCubes;
    }

    private void Awake()
    {
        Image[] points = GetComponentsInChildren<Image>();
        for(int i = 0; i<3; i++)
            for (int j = 0; j < 3; j++)
                CubePoints[i,j] = points[i * 3 + j].transform.position;
    }

    public Vector2 GetFreePos()
    {
        List<Cube> tempCubes = new List<Cube>();
        foreach (Cube cube in Cubes)
        {
            tempCubes.Add(cube);
        }
        int row = Random.Range(0, 3);
        int column = Random.Range(0, 3);
        while (Cubes[row, column] != null)
        {
            tempCubes.Remove(Cubes[row, column]);
            
            if(tempCubes.Count==0)
            {
                if(!IsGameEnd()) OnGameEnd?.Invoke();
                return new Vector2(100, 100);
            }
            
            row = Random.Range(0, 3);
            column = Random.Range(0, 3);
        }

        return new Vector2(row, column);
    }

    private bool IsGameEnd()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j >= 0; j--)
            {
                if (Cubes[i, j] == null)
                    continue;
                Cube cube = Cubes[i, j];
                for (int k = j + 1; k < 3; k++)
                {
                    if (Cubes[i, k] != null)
                    {
                        if (cube.Score == Cubes[i, k].Score)
                        {
                            return true;
                        }
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < 3; j++)
            {
                if (Cubes[i, j] == null)
                    continue;
                Cube cube = Cubes[i, j];
                for (int k = j - 1; k >= 0; k--)
                {
                    if (Cubes[i, k] != null)
                    {
                        if (cube.Score == Cubes[i, k].Score)
                        {
                            return true;
                        }
                        break;
                    }
                }
            }
        }
        for (int i = 1; i >= 0; i--)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Cubes[i, j] == null)
                    continue;
                Cube cube = Cubes[i, j];
                for (int k = i + 1; k < 3; k++)
                {
                    if (Cubes[k, j] != null)
                    {
                        if (cube.Score == Cubes[k, j].Score)
                        {
                            return true;
                        }
                        break;
                    }
                }
            }
        }
        for (int i = 1; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Cubes[i, j] == null)
                    continue;
                Cube cube = Cubes[i, j];
                for (int k = i - 1; k >= 0; k--)
                {
                    if (Cubes[k, j] != null)
                    {
                        if (cube.Score == Cubes[k, j].Score)
                        {
                            return true;
                        }
                        break;
                    }
                }
            }
        }

        return false;
    }

    private void ShuffleCubes(SwipeType type)
        {
            StartCoroutine(ShuffleCubesRoutine(type));
        }

        private IEnumerator ShuffleCubesRoutine(SwipeType type)
        {
            switch (type)
            {
                case SwipeType.Right:
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 1; j >= 0; j--)
                        {
                            if(Cubes[i,j] == null)
                                continue;
                            Cube cube = Cubes[i, j];
                            int column = j;

                            bool eat = false;
                            for (int k = j+1; k < 3; k++)
                            {
                                if(Cubes[i,k] !=null)
                                {
                                    if (cube.Score == Cubes[i, k].Score)
                                    {
                                        eat = true;
                                        cube.MoveEat(CubePoints[i,k]);
                                        Cubes[i,k].Die();
                                        Cubes[i, k] = cube;
                                        OnCubeAdded?.Invoke();
                                    }
                                    break;
                                }
                                column = k;
                            }
                            Cubes[i, j] = null;
                            if(eat) continue;
                            Cubes[i, column] = cube;
                            cube.Move(CubePoints[i,column]);
                        }
                    }
                    break;
                }
                case SwipeType.Left:
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 1; j < 3; j++)
                        {
                            if(Cubes[i,j] == null)
                                continue;
                            Cube cube = Cubes[i, j];
                            int column = j;
                        
                            bool eat = false;
                            for (int k = j-1; k >= 0; k--)
                            {
                                if(Cubes[i,k] !=null)
                                {
                                    if (cube.Score == Cubes[i, k].Score)
                                    {
                                        eat = true;
                                        cube.MoveEat(CubePoints[i,k]);
                                        Cubes[i,k].Die();
                                        Cubes[i, k] = cube;
                                        OnCubeAdded?.Invoke();
                                    }
                                    break;
                                }
                                column = k;
                            }
                            Cubes[i, j] = null;
                            if(eat) continue;
                            Cubes[i, column] = cube;
                            cube.Move(CubePoints[i,column]);
                        }
                    }
                    break;
                }
                case SwipeType.Down:
                {
                    for (int i = 1; i >= 0; i--)
                    {
                        for (int j = 0; j <3; j++)
                        {
                            if(Cubes[i,j] == null)
                                continue;
                            Cube cube = Cubes[i, j];
                            int row = i;

                            bool eat = false;
                            for (int k = i+1; k < 3; k++)
                            {
                                if(Cubes[k,j] !=null)
                                {
                                    if (cube.Score == Cubes[k, j].Score)
                                    {
                                        eat = true;
                                        cube.MoveEat(CubePoints[k, j]);
                                        Cubes[k, j].Die();
                                        Cubes[k, j] = cube;
                                        OnCubeAdded?.Invoke();
                                    }
                                    break;
                                }
                                row = k;
                            }
                            Cubes[i, j] = null;
                            if(eat) continue;
                            Cubes[row, j] = cube;
                            cube.Move(CubePoints[row,j]);
                        }
                    }
                    break;
                }
                case SwipeType.Top:
                {
                    for (int i = 1; i < 3; i++)
                    {
                        for (int j = 0; j <3; j++)
                        {
                            if(Cubes[i,j] == null)
                                continue;
                            Cube cube = Cubes[i, j];
                            int row = i;

                            bool eat = false;
                            for (int k = i-1; k >= 0; k--)
                            {
                                if(Cubes[k,j] !=null)
                                {
                                    if (cube.Score == Cubes[k, j].Score)
                                    {
                                        eat = true;
                                        cube.MoveEat(CubePoints[k, j]);
                                        Cubes[k, j].Die();
                                        Cubes[k, j] = cube;
                                        OnCubeAdded?.Invoke();
                                    }
                                    break;
                                }
                                row = k;
                            }
                            Cubes[i, j] = null;
                            if(eat) continue;
                            Cubes[row, j] = cube;
                            cube.Move(CubePoints[row,j]);
                        }
                    }
                    break;
                }
            }

            yield return new WaitForSeconds(0.25f);
            OnShuffleEnd?.Invoke(1, 3);
        }
    
}