using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSpot : MonoBehaviour
{
    public GameObject previousPath;
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(previousPath);
            wall.SetActive(true);
        }
    }
}
