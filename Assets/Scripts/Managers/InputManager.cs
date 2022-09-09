using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Managers
{
    //CURRENTLY NOT IN USE
    public class InputManager : MonoBehaviour
    {
        public static InputManager sharedInstance;
        private TouchInput _touchInput;
        
        private void Awake()
        {
            sharedInstance = this;
            _touchInput = new TouchInput();
            
        }

        private void OnEnable()
        {
            _touchInput.Enable();
            TouchSimulation.Enable();
            
        }

        private void OnDisable()
        {
            _touchInput.Disable();
            TouchSimulation.Disable();
        }
    }
}