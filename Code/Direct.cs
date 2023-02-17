using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Direct : MonoBehaviour
{
    
    public NavMeshAgent myNavMeshAgent;
    void Start()
    {
        Vector3 firstpos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
        myNavMeshAgent.SetDestination(firstpos);
        StartCoroutine(randomDestination());
    }

    IEnumerator randomDestination()
    {

        while (true)
        {
            yield return new WaitForSeconds(60f);
            Vector3 Randompos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
            if (Randompos.y > 200 && Randompos.y < 300 && Randompos.z < 300 && Randompos.z > 200)
            {
                Randompos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
            }
            myNavMeshAgent.SetDestination(Randompos);
        }
    }
    
}