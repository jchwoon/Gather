using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private MoveCharacterController _controller;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _characterSprite;
    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<MoveCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterSprite = GetComponent<SpriteRenderer>();
        _characterSprite = transform.Find("CharacterSprite").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMove(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        FlipCharacterDirection(direction);
        _movementDirection = direction;
    }

    private void FlipCharacterDirection(Vector2 direction)
    {
        if (direction.x == 1)
        {
            _characterSprite.flipX = false;
        }

        if (direction.x == -1)
        {
            _characterSprite.flipX = true;
        }
    }

    private void ApplyMove(Vector2 direction)
    {
        _rigidbody.velocity = direction;
    }
}
