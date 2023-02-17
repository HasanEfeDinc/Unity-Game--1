using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class Attack : MonoBehaviour
{
    public AudioSource attack;
    public GameObject parent;
    private Animator anim;

    void Start()
    {
        anim = parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.Play("Bear_Attack1");
            attack.Play();
            
        }
    }
    
}
