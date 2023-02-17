using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

using Random = UnityEngine.Random;

public class GeneralScript : MonoBehaviour
{
    
    public GameObject Bear;
    public GameObject SilahSc;
    public GameObject Deer;
    private int deernum1 = 0;
    private int deernum2 = 7;
    public UnityEngine.UI.Image healthbar;



    private bool cond1 = true;
    private bool cond2 = true;
    
    
    void Start()
    {
        
        StartCoroutine(spawnanimalsatposition1());
        StartCoroutine(spawnanimalsatposition2());
        Vector3 bearpos1 = new Vector3(Random.Range(300,495), 1, Random.Range(5, 495));
        bearpos1.y = Terrain.activeTerrain.SampleHeight(bearpos1) + Terrain.activeTerrain.GetPosition().y;
        bearpos1.y += 0.1f;
        Instantiate(Bear, bearpos1, Quaternion.identity);
        Vector3 bearpos2 = new Vector3(Random.Range(5, 195), 1, Random.Range(5, 495));
        bearpos2.y = Terrain.activeTerrain.SampleHeight(bearpos2) + Terrain.activeTerrain.GetPosition().y;
        bearpos2.y += 0.1f;
        Instantiate(Bear, bearpos2, Quaternion.identity);
        

    }

    IEnumerator spawnanimalsatposition1()
    {
        yield return new WaitForSeconds(3f);
        while (cond1)
        {
            Vector3 position1 = new Vector3(Random.Range(300,495), 1, Random.Range(5, 495));
            position1.y = Terrain.activeTerrain.SampleHeight(position1) + Terrain.activeTerrain.GetPosition().y;
            position1.y += 0.2f;
            Instantiate(Deer, position1, Quaternion.identity);
            
            
            deernum1++;
            if (deernum1 > 6)
            {
                cond1 = false;
            }
            

        }
    }

    IEnumerator spawnanimalsatposition2()
        {
            yield return new WaitForSeconds(3f);
            while (cond2)
            {
                
                Vector3 position2 = new Vector3(Random.Range(5, 195), 1, Random.Range(5, 495));
                position2.y = Terrain.activeTerrain.SampleHeight(position2) + Terrain.activeTerrain.GetPosition().y;
                position2.y += 0.2f;
                Instantiate(Deer, position2, Quaternion.identity);
                deernum2++;
                if (deernum2 > 12)
                {
                    cond2 = false;
                }
                
                
            
        }
            
    }

   
        
    
}
