using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

public class ForScene2 : MonoBehaviour
{
    
   
    private void Awake()
    {
        Time.timeScale = 1;
    }
    
    void Update()
    {
        Debug.Log(Time.timeScale);
    }

    public void startgame()
    {
        
        SceneManager.LoadScene("1");

    }

    public void exitapp()
    {
        Application.Quit();
    }
}
