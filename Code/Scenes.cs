using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Scenes : MonoBehaviour
{
    public bool gameovercond = true;
    private bool setactivecond = true;
    private GameObject Person;
    private Scene _scene;
    public GameObject weapon;
    public GameObject gameover;
    public GameObject crosshair;
    public GameObject pausepanel;
    private int presscount = 0;
    void Start()
    {
        _scene = SceneManager.GetActiveScene();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Person = GameObject.FindWithTag("Player");
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            presscount++;
        }

        if (presscount % 2 != 0)
        {
            if (gameovercond)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Person.GetComponent<FirstPersonController>().canrotate = false;
                weapon.GetComponent<Silah>().anothercondition = false;
                weapon.GetComponent<Silah>().canreload = false;
                setactivecond = true;
                crosshair.SetActive(false);
                weapon.GetComponent<Silah>().fireconditionforscene = false;
                pausepanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        /*if (presscount % 2 == 0) // I decided to make continue button instead of clicking escape button again.
        {
            if (gameovercond)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Person.GetComponent<FirstPersonController>().canrotate = true;
                weapon.GetComponent<Silah>().anothercondition = true;
                weapon.GetComponent<Silah>().canreload = true;
                weapon.GetComponent<Silah>().fireconditionforscene = true;

                if (setactivecond)
                {
                    crosshair.SetActive(true);
                    setactivecond = false;
                }

                pausepanel.SetActive(false);

                Time.timeScale = 1;
            }
        }*/
    }
    private void Awake()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    

    public void restartgame()
    {
        gameovercond = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("1");
        
    }

    public void exitthegame()
    {
        Application.Quit();
    }
    public void gameisover()
    {
        gameovercond = false;
        weapon.GetComponent<Silah>().canFire = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Person.GetComponent<FirstPersonController>().canrotate = false;
        weapon.GetComponent<Silah>().anothercondition = false;
        weapon.GetComponent<Silah>().canreload = false;
        crosshair.SetActive(false);
        weapon.GetComponent<Silah>().fireconditionforscene = false;
        gameover.SetActive(true);
        Time.timeScale = 0;
            
            
                
    }

    public void backtomenu()
    {
        SceneManager.LoadScene("2");
        Time.timeScale = 1;
    }

    public void continueplaying()
    {
        if (gameovercond)
        {
            presscount++;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Person.GetComponent<FirstPersonController>().canrotate = true;
            weapon.GetComponent<Silah>().anothercondition = true;
            weapon.GetComponent<Silah>().canreload = true;
            weapon.GetComponent<Silah>().fireconditionforscene = true;

            if (setactivecond)
            {
                crosshair.SetActive(true);
                setactivecond = false;
            }

            pausepanel.SetActive(false);

            Time.timeScale = 1;
        }
    }
    
}
    

    


