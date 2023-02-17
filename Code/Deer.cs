using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Deer : MonoBehaviour
{
    
    public float pathEndThreshold = 0.1f;
    private Animator myanim;
    NavMeshAgent agent;
    public GameObject parentobject;
    public Animator deathAnim;
    private float health = 100;

    public void takendamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            deathAnim.Play("Death");


        }
    }

    void dead()
    {
        Destroy(parentobject);
    }

    private void Start()
    {
        agent = parentobject.GetComponent<NavMeshAgent>();
        myanim = gameObject.GetComponent<Animator>();
        
        


    }

    private void Update()
    {


        if (agent.remainingDistance <= agent.stoppingDistance + pathEndThreshold)
        {
            myanim.SetBool("Walk", false);
            
        }
        if((agent.remainingDistance >= agent.stoppingDistance + pathEndThreshold))
        {
            myanim.SetBool("Walk", true);
        }
    }
}


