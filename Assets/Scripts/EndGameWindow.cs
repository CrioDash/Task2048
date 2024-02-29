using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class EndGameWindow:MonoBehaviour
{
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;
        [SerializeField] private Transform movingPanel;
        [SerializeField] private AnimationCurve animationCurve;
        
        private PlayerGrid _playerGrid;
        private SwipeService _swipeService;
        private CanvasGroup _canvasGroup;

        private Coroutine _runningRoutine;

        [Inject]
        public void Construct(PlayerGrid playerGrid, SwipeService swipeService)
        {
                _playerGrid = playerGrid;
                _swipeService = swipeService;
        }

        private void Awake()
        {
                _canvasGroup = GetComponent<CanvasGroup>();
                GetComponentInChildren<Button>().onClick.AddListener(()=> SceneManager.LoadScene(0));
                _playerGrid.OnGameEnd += ShowWindow;
        }

        private void ShowWindow()
        {
                if(_runningRoutine!=null) return;
                
                _swipeService.SetPause();
                _canvasGroup.blocksRaycasts = true;
                _runningRoutine = StartCoroutine(ShowWindowRoutine());
        }

        private IEnumerator ShowWindowRoutine()
        {
                float t = 0;
                while (t<1)
                {
                        movingPanel.position = Vector3.Lerp(startPos.position, endPos.position, animationCurve.Evaluate(t));
                        _canvasGroup.alpha = Mathf.Lerp(0, 1, animationCurve.Evaluate(t));
                        t += Time.deltaTime * 4;
                        yield return null;
                }
        }
        
}