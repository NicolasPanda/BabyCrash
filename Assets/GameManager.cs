using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static Player playerRefs;
    public SceneAsset[] levelList;
    public static int rattle = 0;
    private static GameManager instance;
    public static SceneAsset currentScene;

    private void Awake()
    {
        instance = this;
        playerRefs = player;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void SetRattle(int value)
    {
        rattle = value;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public static void GoToSceneName(String name)
    {
        SceneManager.LoadScene(name);
    }
    

    public static void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Player.SetPlayerDead(false);
        Player.ResetBalloon();
        rattle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
