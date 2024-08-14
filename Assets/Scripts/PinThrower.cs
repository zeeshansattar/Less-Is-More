using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinThrower : MonoBehaviour
{
    float _speed = 20f;
    Rigidbody2D rb;
    bool _isPinned;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!_isPinned)
        rb.MovePosition(rb.position + Vector2.up * _speed * Time.deltaTime);           
    }

    private void OnTriggerEnter2D(Collider2D collidedWith)
    {
        if (collidedWith.tag == "BigBlackBall")
        {
            transform.SetParent(collidedWith.transform);
            FindObjectOfType<AudioManager>().Play("Tap");
            ScoreManager.pinCount++;
            _isPinned = true;
        }
        else if (collidedWith.tag == "Pin" || collidedWith.tag == "Center")
        {
            FindObjectOfType<Gamemanager>().EndGame();
        }
    }
}
