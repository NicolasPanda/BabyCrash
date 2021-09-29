using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player.BodyCollision(collision);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.BodyTrigger(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Player.BodyTriggerExit(collision);
    }
}
