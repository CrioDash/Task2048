using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadingScreen: MonoBehaviour
    {

        private Image _image;

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
        }

        public IEnumerator FadeRoutine()
        {
            Vector3 startScale = _image.transform.localScale;
            Vector3 endScale = startScale / 1000f;
        
            float t = 0;
            while (t<1)
            {
                _image.transform.localScale = Vector3.Lerp(startScale, endScale, t);
                t += Time.deltaTime * 4;
                yield return null;
            }

            _image.transform.localScale = endScale;
        }

        public IEnumerator ShowRoutine()
        {
            Vector3 startScale = _image.transform.localScale;
            Vector3 endScale = startScale * 1000f;
        
            float t = 0;
            while (t<1)
            {
                _image.transform.localScale = Vector3.Lerp(startScale, endScale, t);
                t += Time.deltaTime * 4;
                yield return null;
            }

            _image.transform.localScale = endScale;
        }
    
    }
}