using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class InitCubeData:MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = int.MaxValue;
        
        CubeVariables.CubeData = new Dictionary<int, CubeData>();
        const string cubes = "Cubes/";
        CubeData[] info = Resources.LoadAll<CubeData>(cubes);
        foreach (var data in info)
        {
            CubeVariables.CubeData.Add(data.Score, data);
        }
    }
}