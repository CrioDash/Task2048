using System;
using UnityEngine;

namespace UI
{
    public class IconPanel:MonoBehaviour
    {

        public Transform currentTransform;
        public Transform[] iconTransforms;
        public Sprite[] iconSprites;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            ChangeState();
        }

        public void ChangeState()
        {
            _canvasGroup.alpha = _canvasGroup.alpha ==0 ? 1 : 0;
            _canvasGroup.blocksRaycasts = !_canvasGroup.blocksRaycasts;
        }
    }
}