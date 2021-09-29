using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float _startingPosition;
    private float _size;
    public GameObject camera;
    public float speed;

    private void Start()
    {
        _startingPosition = transform.position.x;
        _size = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    private void Update()
    {
        var tempSpeed = camera.transform.position.x * (1 - speed);
        var distance = camera.transform.position.x * speed;
        transform.position = new Vector3(_startingPosition + distance, transform.position.y, transform.position.z);

        if (tempSpeed > _startingPosition + _size) _startingPosition += _size;
        else if (tempSpeed < _startingPosition - _size) _startingPosition -= _size;

        


    }
}
