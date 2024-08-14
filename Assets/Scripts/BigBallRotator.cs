using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallRotator : MonoBehaviour
{
    [SerializeField]
    float _speed = 200f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, _speed * Time.deltaTime);
    }
}
