using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BearCollision : MonoBehaviour
{
    public AudioSource detection;
    private Vector3 Randompos = new Vector3();
    public GameObject foragent;
    public GameObject Human;
    private float dicplacementdistance = 5f;
    private Animator parentanim;
    
    void Start()
    {
        StartCoroutine(regularrandom());
        Vector3 Randompos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
        parentanim = foragent.GetComponent<Animator>();
    }
    IEnumerator regularrandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Vector3 Randompos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
        }
    }
    Vector3 dir = new Vector3();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detection.Play();
        }
    }


    void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                dir = -(foragent.transform.position - Human.transform.position).normalized;
                foragent.GetComponent<NavMeshAgent>().speed = 11;
                foragent.GetComponent<NavMeshAgent>().SetDestination(foragent.transform.position +(dir*dicplacementdistance));
                parentanim.SetBool("Bear_RunForward",true);
                
                
            }
            
            
        }

        

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                foragent.GetComponent<NavMeshAgent>().SetDestination(Randompos);
                foragent.GetComponent<NavMeshAgent>().speed = 4;
                parentanim.SetBool("Bear_RunForward",false);
                
                
            }
        }
    
}
