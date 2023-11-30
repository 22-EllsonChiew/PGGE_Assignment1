using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundSystem : MonoBehaviour
{

    public AudioSource Sound;

    
    public AudioClip concrete;
    public AudioClip dirt;
    public AudioClip metal;
    public AudioClip sand;
    public AudioClip wood;
    public AudioClip water;
   
    public Transform RayCastShot;
    public float range;
    public LayerMask layerMask;

    RaycastHit hit;

    // private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        

        

        if(Sound == null)
        {
            Sound = GetComponent<AudioSource>();
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
            

    }

    public void FootStepSound()
    {
         //ray cast shot from the origin, then shot the direction * -1, which the ray cast will face upside down, then detech the layermask which is mask
         

        RaycastHit hit;
        if (Physics.Raycast(RayCastShot.position, RayCastShot.transform.up * -1, out hit, range))
        {
            // Play different footstep sounds based on the detected layer
            switch (hit.collider.gameObject.tag)
            {
                case "concrete":  //each case holds the tag name
                    PlayFootStepSound(concrete);
                    break;

                case "dirt":
                    PlayFootStepSound(dirt);
                    break;

                case "metal":
                    PlayFootStepSound(metal);
                    break;

                case "sand":
                    PlayFootStepSound(sand);
                    break;

                case "wood":
                    PlayFootStepSound(wood);
                    break;

                case "water":
                    PlayFootStepSound(water);
                    break;

            }
        }


    }


    void PlayFootStepSound(AudioClip audio)
    {

        Sound.volume = Random.Range(0.5f, 1f);
        Sound.pitch = Random.Range(0.8f, 1f);
        Sound.PlayOneShot(audio);
        
    }
}
