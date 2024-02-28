using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CubeInfo", menuName = "Gameplay/New Cube Info")]
    public class CubeData: ScriptableObject
    {
        [SerializeField] private Color color;
        [SerializeField] private int score;

        public Color Color => color;
        public int Score => score;
    }
}