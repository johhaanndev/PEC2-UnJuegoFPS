using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorAppearer : MonoBehaviour
{
    public GameObject nextObject;

    private void Start()
    {
        nextObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            nextObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
