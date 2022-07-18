using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class CameraController : MonoBehaviour
{
    private bool _canCameraMove = false;
    [SerializeField] private float _touchSpeed = 0.1f;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        Touch.onFingerDown += Move;
        Touch.onFingerUp += StopMove;
    }
    

    private void OnDisable()
    {
        Touch.onFingerDown -= Move;
        Touch.onFingerUp -= StopMove;
        TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();
    }

    
    private void Move(Finger finger)
    {
        if(!_canCameraMove)
            _canCameraMove = true;
    }
    
    private void StopMove(Finger finger)
    {
        if (_canCameraMove)
            _canCameraMove = false;
    }
  
    void Update()
    {
        if (!_canCameraMove && Touch.activeTouches.Count != 1) return;
        if (Touch.activeTouches[0].phase != TouchPhase.Began)
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x += Touch.activeTouches[0].delta.y * _touchSpeed;
            rotation.x = Mathf.Clamp(rotation.x, 10f, 45f);
            transform.localRotation = Quaternion.Euler(rotation);
        }
        
    }
}
