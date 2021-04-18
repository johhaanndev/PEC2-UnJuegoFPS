using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlockedByRedProjector : MonoBehaviour
{
    private Animator anim;
    public GameObject projector;

    public AudioSource openCloseSound;

    public GameObject warningText;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && projector.GetComponent<Projector>().isDestroyed)
        {
            anim.SetBool("character_nearby", true);
            openCloseSound.Play();
        }

        if (col.gameObject.CompareTag("Player") && !projector.GetComponent<Projector>().isDestroyed)
        {
            warningText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetBool("character_nearby", false);
            openCloseSound.Play();

            warningText.SetActive(false);
        }
    }
}
