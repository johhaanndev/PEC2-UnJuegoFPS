using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectable : MonoBehaviour
{
    public PlayerController player;
    public GameObject shieldFrame;
    public int addShield = 20;

    private void OnTriggerEnter(Collider other)
    {
        shieldFrame.GetComponent<Animator>().SetTrigger("Show");

        player.shield += addShield;
        if (player.shield >= 100)
            player.shield = 100;

        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        Invoke(nameof(DestroyGO), 2f);
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
