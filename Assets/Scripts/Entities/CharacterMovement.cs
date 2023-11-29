using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _characterSprite;
    private Vector2 _movementDirection = Vector2.zero;
    private MoveInput _moveInput = null;
    private float moveSpeed = 5f;

    //X축 방향 데이타
    private string currentXKey = null;
    private int leftCount = 0;
    private int rightCount = 0;
    private bool isPressingBothX = false;

    //Y축 방향 데이타
    private string currentYKey = null;
    private int upCount = 0;
    private int downCount = 0;
    private bool isPressingBothY = false;

    public Vector2 MoveMentDirection
    {
        get { return _movementDirection; }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterSprite = GetComponent<SpriteRenderer>();
        _characterSprite = transform.Find("CharacterSprite").GetComponent<SpriteRenderer>();
        _moveInput = new MoveInput();
    }

    private void OnEnable()
    {
        _moveInput.Enable();
        _moveInput.Player.Move.performed += OnMoveMentPerformed;
        _moveInput.Player.Move.canceled += OnMoveMentCancelled;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementDirection * moveSpeed;
    }

    private void OnDisable()
    {
        _moveInput.Disable();
        _moveInput.Player.Move.performed -= OnMoveMentPerformed;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////


    private void OnMoveMentPerformed(InputAction.CallbackContext callbackContext)
    {
        string controlName = callbackContext.control.name;

        if (controlName == "a" || controlName == "d")
        {
            CheckDirectionPriority(controlName, "a", "d", true, ref leftCount, ref rightCount,ref currentXKey ,ref isPressingBothX, ref _movementDirection.x);
        }
        
        if (controlName == "w" || controlName == "s")
        {
            CheckDirectionPriority(controlName, "w", "s", false, ref upCount, ref downCount,ref currentYKey, ref isPressingBothY, ref _movementDirection.y);
        }

        FlipCharacterDirection();
    }

    private void OnMoveMentCancelled(InputAction.CallbackContext callbackContext)
    {
        _movementDirection = Vector2.zero;
    }

    private void FlipCharacterDirection()
    {
        if (_movementDirection.x > 0)
        {
            _characterSprite.flipX = false;
        }
        else if (_movementDirection.x < 0)
        {
            _characterSprite.flipX = true;
        }
    }

    private void CheckDirectionPriority(string controlName, string compareA, string compareB, bool isXAxis, ref int countA, ref int countB, ref string currentKey, ref bool isPressingBoth, ref float direction)
    {
        //compare A,B 둘 다 누루고 있는 상황에서 A가 입력으로 들어올 때
        if (controlName == compareA)
        {
            if (isPressingBoth) currentKey = compareB;

            countA++;
            if (countA == 1) currentKey = controlName;
            if (countA == 2) countA = 0;
        }

        //compare A,B 둘 다 누루고 있는 상황에서 B가 입력으로 들어올 때
        if (controlName == compareB)
        {
            if (isPressingBoth) currentKey = compareA;

            countB++;
            if (countB == 1) currentKey = controlName;
            if (countB == 2) countB = 0;
        }

        //A, B 둘 다 떼어져 있을 때는 0 아니면 방향 설정
        if (countB == 0 && countA == 0) direction = 0;
        else
        {
            if (currentKey == compareA) direction = isXAxis ? -1 : 1;
            else direction = isXAxis ? 1 : -1;
        }

        isPressingBoth = countA == 1 && countB == 1;
    }
}
