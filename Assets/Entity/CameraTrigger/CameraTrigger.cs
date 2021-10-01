using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject mainCamera;

    private Camera cam;

    public float newHeight = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        cam = mainCamera.GetComponent(typeof(Camera)) as Camera;
        cam.maxHeight = newHeight;
    }
}
