using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenNearby : MonoBehaviour
{
    private Animator anim;

    public AudioSource openCloseSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetBool("character_nearby", true);
            openCloseSound.Play();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetBool("character_nearby", false);
            openCloseSound.Play();
        }
    }
}
