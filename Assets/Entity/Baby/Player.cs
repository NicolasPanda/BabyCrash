using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 1;
    public float downSpeed = 0.01f;
    public float upSpeed = -0.01f;
    public float upBoost = 10;
    public float downBoost = -10;
    public float resetTime = 0.3f;
    private float nullSpeed = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(speed, 0);

        rb.gravityScale = downSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(new Vector2(0, upBoost), ForceMode2D.Impulse);
            Invoke("ResetVelocity", resetTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddRelativeForce(new Vector2(0, downBoost), ForceMode2D.Impulse);
            Invoke("ResetVelocity", resetTime);
        }
    }

    public static void BodyCollision(Collision2D collision)
    {
        if(collision.transform.tag == "Floor")
        {
            Debug.Log("DIED");
        }
    }

    public static void BodyTrigger(Collider2D collision)
    {
        if (collision.tag == "Rattle")
        {
            Debug.Log("Collect");

            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }

    public static void BalloonCollision(Collision2D collision)
    {
        if (collision.transform.tag == "Sky")
        {
            Debug.Log("pop all ballon");
        }
    }



    void ResetVelocity()
    {
        rb.velocity = new Vector2(speed, 0);
    }
}
