using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject baby;

    public float leftMargin = 10;
    public float minHeight = 10;
    public float maxHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = new Vector2(baby.transform.position.x - leftMargin, baby.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(baby.transform.position.x - leftMargin, Mathf.Clamp(baby.transform.position.y, minHeight, maxHeight), -10);
    }
}
