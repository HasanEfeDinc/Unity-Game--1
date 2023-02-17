using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    private Animator animator;
    //public AudioSource audioSource;  //I decided to remove this. Running this function from another script
    public GameObject Gun;
    void Start()
    {
        animator= gameObject.GetComponent<Animator>();
        
    }

    void canfire()
    {
        Gun.GetComponent<Silah>().canFire = true;
    }

    void canzoom()
    {
        Gun.GetComponent<Silah>().zoomcondforreload = true;
    }

    
    
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Gun.GetComponent<Silah>().canFire = false;
            Gun.GetComponent<Silah>().zoomcondforreload = false;
            animator.Play("Reload");
            //audioSource.Play();
        }
    }
}
