using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MoveCharacterController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue inputValue)
    {
        Vector2 moveInput = inputValue.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue inputValue)
    {
        Vector2 lookInput = inputValue.Get<Vector2>();
        Vector2 worldPoint = _camera.ScreenToWorldPoint(lookInput);
        Vector2 lookIDirection = (worldPoint - (Vector2)transform.position).normalized;

        CallLookEvent(lookIDirection);
    }
}
