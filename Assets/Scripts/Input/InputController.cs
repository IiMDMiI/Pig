using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Input _input;
    public event Action<Vector2> OnMoveDirectionInput;  
   

    private void Awake()
    {
        _input = new Input();
        _input.Movement.Direction.performed += direction => OnMoveDirectionInput?.Invoke(direction.ReadValue<Vector2>());       
            
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
   
}
