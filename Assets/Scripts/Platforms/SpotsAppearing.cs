using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsAppearing : MonoBehaviour
{
    public GameObject nextSpot;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            nextSpot.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit");
            DestroyObject(gameObject);
        }
    }
}
