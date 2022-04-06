using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterHandler : MonoBehaviour
{
    [SerializeField] private CharacterMoverAI[] _characters;
    [SerializeField] private int _activeCharacter;
    [SerializeField] private PointGetter _positionGetter;
    [SerializeField] private Transform _moveGizmo;
    [SerializeField] private PlayerInput _playerInput;
    private bool _targeting;
    public int ActiveCharacter { get => _activeCharacter; }
    private void Awake()
    {
        _playerInput.actions["Fire"].started += OnLeftMouseDown;
        _playerInput.actions["Fire"].canceled += OnLeftMouseUp;
    }
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            _targeting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Facciamo muovere il personaggio
            _targeting = false;
            Vector3 movePoint = _positionGetter.GetCurrentMousePoint();
            _characters[_activeCharacter].MoveToPoint(movePoint);
        }*/  
        if (_targeting)
        {
            //
            _moveGizmo.position = _positionGetter.GetCurrentMousePoint();
        }
    }
    private void OnLeftMouseDown(InputAction.CallbackContext context)
    {
        _targeting = true;
    }
    private void OnLeftMouseUp(InputAction.CallbackContext context)
    {
        _targeting = false;
        Vector3 movePoint = _positionGetter.GetCurrentMousePoint();
        if (_characters[_activeCharacter].TryOnCalculatePath(movePoint,out Vector3[] points, out float lenght))
        {
            _characters[_activeCharacter].MoveToPoint(movePoint);
        }
        
    }
}
