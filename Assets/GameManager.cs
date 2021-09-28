using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int rattle = 0;
    private static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void setRattle(int value)
    {
        rattle = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
