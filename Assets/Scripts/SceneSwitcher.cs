using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneSwitcher : MonoBehaviour
{
    private bool _isLoading;

    private LoadingScreen _loadingScreen;

    [Inject]
    public void Construct(LoadingScreen screen)
    {
        _loadingScreen = screen;
    }

    public void LoadNextScene(int num)
    {
        StartCoroutine(LoadSceneRoutine(num));
    }

    private IEnumerator LoadSceneRoutine(int num)
    {
        if(_isLoading)
            yield break;

        _isLoading = true;
        
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(num);
        
        sceneLoad.allowSceneActivation = false;

        yield return StartCoroutine(_loadingScreen.FadeRoutine());

        sceneLoad.allowSceneActivation = true;
        
        yield return StartCoroutine(_loadingScreen.ShowRoutine());
        
        _isLoading = false;
        

    }
}