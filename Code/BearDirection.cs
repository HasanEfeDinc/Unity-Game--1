using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityStandardAssets.Characters.FirstPerson;
using Cursor = UnityEngine.Cursor;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

public class BearDirection : MonoBehaviour
{
    public GameObject button;
    public GameObject weapon;
    public GameObject person;
    public float pathEndThreshold = 0.1f;
    public NavMeshAgent bearagent;
    public Animator anim;
    public GameObject generalscript;
    private Image foto;
    public GameObject gameover;
    public GameObject crosshair;
    void Start()
    {
        foto = generalscript.GetComponent<GeneralScript>().healthbar;
        Vector3 firstpos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
        bearagent.SetDestination(firstpos);
        StartCoroutine(randomDestination());
    }
    IEnumerator randomDestination()
    {

        while (true)
        {
            yield return new WaitForSeconds(180f);
            Vector3 Randompos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
            if (Randompos.y > 200 && Randompos.y < 300 && Randompos.z < 300 && Randompos.z > 200)
            {
                Randompos = new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500));
            }
            bearagent.SetDestination(Randompos);
            
            
        }
        
    }
    private void Update()
    {


        if (bearagent.remainingDistance <= bearagent.stoppingDistance + pathEndThreshold)
        {
            anim.SetBool("walk", false);
            
        }
        if((bearagent.remainingDistance >= bearagent.stoppingDistance + pathEndThreshold))
        {
            anim.SetBool("walk", true);
        }

        if (foto.fillAmount == 0)
        {
            thegameover();
        }
    }
    void beardamage()
    {
        foto.fillAmount -= 0.5f;
    }

    void thegameover()
    {
        button.GetComponent<Scenes>().gameisover();
        
    }
    
}

    
    
    

    

