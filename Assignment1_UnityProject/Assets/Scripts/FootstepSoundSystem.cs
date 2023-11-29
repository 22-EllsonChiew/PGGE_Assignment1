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
        /*isMoving = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

        // Play footstep sound when moving
        if (isMoving)
        {
            RaycastHit hit;
            if (Physics.Raycast(RayCastShot.position, RayCastShot.transform.up * -1, out hit, range))
            {
                // Play different footstep sounds based on the detected layer
                switch (hit.collider.gameObject.layer)
                {
                    case 9:  // Replace these numbers with the actual layer indices in your project
                        PlayFootStepSound(concrete);
                        break;

                    case 10:
                        PlayFootStepSound(dirt);
                        break;

                    case 11:
                        PlayFootStepSound(metal);
                        break;

                    case 12:
                        PlayFootStepSound(sand);
                        break;

                    case 13:
                        PlayFootStepSound(wood);
                        break;

                    default:
                        PlayFootStepSound(Footstep);
                        break;
                }
            }
        }*/

    }

    public void FootStepSound()
    {
        //ray cast shot from the origin, then shot the direction * -1, which the ray cast will face upside down, then detech the layermask which is mask
        if (Physics.Raycast(RayCastShot.position, RayCastShot.transform.up * -1, out hit, range, layerMask))
        {

            Debug.Log("Raycast hit Ground");

            if (hit.collider.CompareTag("concrete"))
            {
                PlayFootStepSound(concrete);
            }
            if(hit.collider.CompareTag("dirt"))
            {
                PlayFootStepSound(dirt);
            }
            if(hit.collider.CompareTag("metal"))
            {
                PlayFootStepSound(metal);
            }
            if(hit.collider.CompareTag("sand"))
            {
                PlayFootStepSound(sand);
            }
            if (hit.collider.CompareTag("wood"))
            {
                PlayFootStepSound(wood);
            }
            if(hit.collider.CompareTag("water"))
            {
                PlayFootStepSound(water);
            }
            else
            {
                Debug.Log("Raycast did not hit anything.");
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
