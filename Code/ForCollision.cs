using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Water;
using Random = UnityEngine.Random;

public class ForCollision : MonoBehaviour
{
    public GameObject detectcollider;
    private Vector3 Randompos = new Vector3();
    public GameObject foragent;
    private GameObject Human;
    private float dicplacementdistance = 5f;

    private void Start()
    {
        Human = GameObject.FindWithTag("Player");
        StartCoroutine(regularrandom());
        Vector3 Randompos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (detectcollider.GetComponent<Detect>().detectcond == true) 
            {
                foragent.GetComponent<NavMeshAgent>().speed = 11;
                foragent.GetComponent<NavMeshAgent>().SetDestination(foragent.transform.position + (dir * dicplacementdistance));
            }
        }
    }

    private void Update()
    {
        dir = (foragent.transform.position - Human.transform.position).normalized;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            foragent.GetComponent<NavMeshAgent>().SetDestination(Randompos);
            foragent.GetComponent<NavMeshAgent>().speed = 2;
            detectcollider.GetComponent<Detect>().detectcond = false; 
        }


    }
    
}
