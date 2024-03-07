using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class LoadSceneButton:MonoBehaviour
{
    [SerializeField] private int sceneNum;
    
    private SceneSwitcher _sceneSwitcher;

    [Inject]
    public void Construct(SceneSwitcher sceneSwitcher)
    {
        _sceneSwitcher = sceneSwitcher;
    }
        
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => _sceneSwitcher.LoadNextScene(sceneNum));
    }
}