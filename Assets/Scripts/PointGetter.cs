using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointGetter : MonoBehaviour
{
    [SerializeField] private Camera _eventCamera;
    [SerializeField] private PlayerInput _playerInput;
    private Vector2 _mousePosition;
    private void Awake()
    {
        _playerInput.actions["Pointer Position"].performed += GetMousePosition;
    }
    public Vector3 GetCurrentMousePoint()
    {
        Vector3 output = Vector3.positiveInfinity;
        Ray ray = _eventCamera.ScreenPointToRay(_mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            output = hit.point;
        }
        return output;
    }
    private void GetMousePosition(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>(); 
    }
}
