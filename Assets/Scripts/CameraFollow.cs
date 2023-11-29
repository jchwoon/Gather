using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private void Awake()
    {
        
    }

    private void Update()
    {
        if (_player != null)
        {
            transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        }
    }
}
