using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SwipeService : MonoBehaviour
{
    [SerializeField] [Range(0, 1f)] private float posDiff;
    
    public event Action<SwipeType> OnSwipe;

    private bool _isPaused = false;
    private Vector3 _touchDown = Vector3.zero;
    private Vector3 _touchMove = Vector3.zero;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void SetPause()
    {
        _isPaused = true;
    }

    private void Update()
    {
        if(_isPaused) return;
        
        // Sets the down touch pos
        if (Input.GetMouseButtonDown(0) ||
            (Input.touchCount != 0 && Input.touches[0].phase == TouchPhase.Began))
            _touchDown = InputPos();
        
        // Sets the current touch pos
        if ( _touchDown != Vector3.zero && (Input.GetMouseButton(0) || (Input.touchCount!=0 && Input.touches[0].phase == TouchPhase.Moved)))
            _touchMove = InputPos();

        // Clear pos when up or already 
        if (Input.GetMouseButtonUp(0) || (Input.touchCount != 0 && Input.touches[0].phase == TouchPhase.Ended) || RecognizeSwipe())
            _touchMove = _touchDown = Vector3.zero;

        // If pos not cleared try to recognize the swipe
        if(_touchDown != Vector3.zero && _touchMove != Vector3.zero)
        {
            RecognizeSwipe();
        }
    }

    private Vector3 InputPos()
    {
        return SystemInfo.deviceType == DeviceType.Desktop
            ? _camera.ScreenToWorldPoint(Input.mousePosition)
            : _camera.ScreenToWorldPoint(Input.touches[0].position);
    }

    private bool RecognizeSwipe()
    {
        Vector3 touchVector = _touchDown - _touchMove;
        
        if (!(touchVector.x <= -posDiff) && !(touchVector.x >= posDiff) &&
            !(touchVector.y >= posDiff) && !(touchVector.y <= -posDiff))
            return false;
        
        if(touchVector.x <= -posDiff)
            OnSwipe?.Invoke(SwipeType.Right);
        else if(touchVector.x >= posDiff)
            OnSwipe?.Invoke(SwipeType.Left);
        else if(touchVector.y >= posDiff)
            OnSwipe?.Invoke(SwipeType.Down);
        else if(touchVector.y <= -posDiff)
            OnSwipe?.Invoke(SwipeType.Top);
        return true;
    }
}