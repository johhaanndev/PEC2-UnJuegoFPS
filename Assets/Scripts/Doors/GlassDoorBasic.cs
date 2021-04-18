using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorBasic : MonoBehaviour
{
    private Animator anim;

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
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetBool("character_nearby", false);
        }
    }
}
