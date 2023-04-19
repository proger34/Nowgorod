using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PistolFire : MonoBehaviour
{
    public AudioSource audioSource; 
    public Animator anim;
    public AudioClip fireClip;

    Interactable interactable;
    public SteamVR_Action_Boolean fireAction;
    public Transform barel;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

            if (fireAction[hand].stateDown)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        audioSource.PlayOneShot(fireClip);
        anim.Play("Fire");

        if (Physics.Raycast(barel.position, barel.forward, out hit, 300))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
