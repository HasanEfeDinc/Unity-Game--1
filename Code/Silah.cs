using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityStandardAssets.Characters.FirstPerson;

public class Silah : MonoBehaviour
{
    public GameObject Deer;
    public bool zoomcondforreload = true;
    public bool fireconditionforscene = true;
    public bool canreload = true;
    public bool anothercondition = true;
    public int totaldeernum = 13;
    private int deercounter;
    public int HuntedDeer;
    public TextMeshProUGUI HuntedDeerNum;
    public bool canFire;
    private float fireDuration;
    public float fireduration1;
    public float range;
    public Camera Cam;
    public AudioSource FireSound;
    public AudioSource OutOfAmmo;
    public AudioSource Reload;
    public ParticleSystem FireEffect;
    public ParticleSystem BloodEffect;
    private Animator[] MyAnimator;
    public int AmmoNumber = 6;
    private GameObject[] Ammo;
    public GameObject emptyshell;
    public GameObject shellCreateLocation;
    private float camfieldofwiev;
    private float zoomPosition = 10;
    public GameObject corsshair;
    public GameObject Scope;
    public GameObject Hands;
    public GameObject Weapon;
    public GameObject FirstPerson;
    
    
    void Start()
    
    {
        MyAnimator = GetComponentsInChildren<Animator>();
        Ammo = GameObject.FindGameObjectsWithTag("Ammo Image");
        camfieldofwiev = Cam.fieldOfView;
        HuntedDeerNum.text = HuntedDeer.ToString();
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                
                if (canFire && Time.time > fireDuration && fireconditionforscene)
                {
                    fireDuration = Time.time + fireduration1;
                    
                    fire();
                }

                if (AmmoNumber == 0)
                {
                    canFire = false;
                    OutOfAmmo.Play();
                }
                
            }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            zoomCamerain(true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            zoomCamerain(false);
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            if(canreload){
                AmmoNumber = 5;
                Ammo[0].SetActive(true);
                Ammo[1].SetActive(true);
                Ammo[2].SetActive(true);
                Ammo[3].SetActive(true);
                Ammo[4].SetActive(true);
                //MyAnimator[2].Play("Reload");
                Reload.Play();
            }
        }
        void fire()
        {
            
            GameObject force = Instantiate(emptyshell, shellCreateLocation.transform.position, shellCreateLocation.transform.rotation);
            Rigidbody rigidbody = force.GetComponent<Rigidbody>();
            rigidbody.AddRelativeForce(new Vector3(5f,1,0)*100);
            FireSound.Play();
            FireEffect.Play();
            MyAnimator[1].Play("Fire");
            AmmoNumber--;
            Ammo[AmmoNumber].SetActive(false);
            
            RaycastHit hit;

            
            if (Physics.Raycast(Cam.transform.position,Cam.transform.forward, out hit ,range,~LayerMask.GetMask("Ignore Raycast")))
            {
                if (hit.transform.gameObject.CompareTag("Deer"))
                {
                    deercounter++;
                    if (deercounter % 2 == 0)
                    {
                        totaldeernum--;
                        HuntedDeer++;
                        HuntedDeerNum.text = HuntedDeer.ToString();
                        Vector3 position1 = new Vector3(Random.Range(300,495), 1, Random.Range(5, 495)); // Respawn 
                        position1.y = Terrain.activeTerrain.SampleHeight(position1) + Terrain.activeTerrain.GetPosition().y;
                        position1.y += 0.2f;
                        Instantiate(Deer, position1, Quaternion.identity);
                        if (totaldeernum == 0)
                        {
                            totaldeernum = 13; // 1000 iq
                        }
                    }
                    Instantiate(BloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    hit.transform.gameObject.GetComponent<Deer>().takendamage(50);
                }
            }

            
        }

        void zoomCamerain(bool condition)
        {
            if (condition && anothercondition && zoomcondforreload)
                {
                    FirstPerson.GetComponent<FirstPersonController>().m_UseHeadBob = false;
                    FirstPerson.GetComponent<FirstPersonController>().m_UseFovKick = false;
                    //FirstPerson.GetComponent<CharacterController>().enabled = false; //I decided to remove this
                    FirstPerson.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                    FirstPerson.GetComponent<FirstPersonController>().m_RunSpeed = 0;
                    FirstPerson.GetComponent<FirstPersonController>().m_JumpSpeed = 0;
                    FirstPerson.GetComponent<AudioSource>().enabled = false;
                    corsshair.SetActive(false);
                    Hands.SetActive(false);
                    Weapon.SetActive(false);
                    FireEffect.gameObject.SetActive(false);
                    emptyshell.SetActive(false);
                    Scope.SetActive(true);
                    //MyAnimator[0].SetBool("Zoom", condition); //I decided to remove this
                    Cam.fieldOfView = zoomPosition;
                }
            else
            {
                if (anothercondition && zoomcondforreload)
                {
                    //FirstPerson.GetComponent<CharacterController>().enabled = true; //I decided to remove this
                    FirstPerson.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                    FirstPerson.GetComponent<FirstPersonController>().m_RunSpeed = 8;
                    FirstPerson.GetComponent<FirstPersonController>().m_JumpSpeed = 10;
                    FirstPerson.GetComponent<AudioSource>().enabled = true;
                    corsshair.SetActive(true);
                    Hands.SetActive(true);
                    Weapon.SetActive(true);
                    FireEffect.gameObject.SetActive(true);
                    emptyshell.SetActive(true);
                    Scope.SetActive(false);
                    //MyAnimator[0].SetBool("Zoom", condition); //I decided to remove this
                    Cam.fieldOfView = camfieldofwiev;
                    FirstPerson.GetComponent<FirstPersonController>().m_UseHeadBob = true;
                }
            }
            
        }
        
        
    }
    
    
}
