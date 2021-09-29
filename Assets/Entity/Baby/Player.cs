using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class Player : MonoBehaviour
{
    private static Rigidbody2D rb;

    public static bool dead = false;
    public float playerSpeed = 3;
    public static float speed;
    public float downSpeed = 0.01f;
    public float upSpeed = -0.01f;
    public float upBoost = 10;
    public float downBoost = -10;
    public float resetTime = 0.3f;
    private float nullSpeed = 0;

    public Text inputCount;

    public static Text rattleCount;
    public static int balloonCount = 1;


    private void Awake()
    {
        rattleCount = inputCount;
        speed = playerSpeed;
    }

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
        if (balloonCount <= 0)
        {
            rb.gravityScale = 10;
        }
        if (balloonCount == 1)
        {
            rb.gravityScale = downSpeed;
        }
        if (balloonCount == 2)
        {
            rb.gravityScale = nullSpeed;
        }
        if (balloonCount == 3)
        {
            rb.gravityScale = upSpeed;
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
            int newValue = GameManager.rattle + 1;
            GameManager.SetRattle(newValue);
            rattleCount.text = newValue.ToString();

            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        if (collision.tag == "Balloon")
        {
            if(balloonCount < 3)
            {
                rb.velocity = new Vector2(speed, 0);
                balloonCount++;
            }
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }

    public static void BalloonCollision(Collision2D collision)
    {
        if (collision.transform.tag == "Sky")
        {
            balloonCount = 0;
        }
    }

    public static void BalloonTrigger(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            balloonCount--;
            Destroy(collision.gameObject);
        }
    }



    public void ResetVelocity()
    {
        rb.velocity = new Vector2(speed, 0);
        if (balloonCount <= 0)
        {
            rb.gravityScale = 10;
        }
        if (balloonCount == 1)
        {
            rb.gravityScale = downSpeed;
        }
        if (balloonCount == 2)
        {
            rb.gravityScale = nullSpeed;
        }
        if (balloonCount == 3)
        {
            rb.gravityScale = upSpeed;
        }
    }
}
