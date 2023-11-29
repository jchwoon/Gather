using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAni : MonoBehaviour
{
    private Animator _animator;
    CharacterMovement _characterMovement;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterMovement = transform.parent.GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (_characterMovement.MoveMentDirection == Vector2.zero) _animator.SetBool("isMove", false);
        else _animator.SetBool("isMove", true);
    }
}
