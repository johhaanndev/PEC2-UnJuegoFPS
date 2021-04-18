using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttachPlayer : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}
