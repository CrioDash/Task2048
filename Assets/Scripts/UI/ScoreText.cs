using TMPro;
using UnityEngine;
using Zenject;

public class 
    ScoreText:MonoBehaviour
{
    private int _score = 0;
    private TextMeshProUGUI _text;
    private PlayerGrid _playerGrid;

    [Inject]
    public void Construct(PlayerGrid playerGrid)
    {
        _playerGrid = playerGrid;
        _playerGrid.OnCubeAdded += UpdateText;
    }
    
    private void OnDisable()
    {
        _playerGrid.OnCubeAdded -= UpdateText;
    }

    private void UpdateText()
    {
        _text.text = $"Score: {++_score}";
    }

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
}