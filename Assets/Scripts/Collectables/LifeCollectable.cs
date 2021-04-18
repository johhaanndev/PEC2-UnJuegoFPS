using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollectable : MonoBehaviour
{
    public PlayerController player;
    public GameObject lifeFrame;
    public int addlife = 20;

    private void OnTriggerEnter(Collider other)
    {
        lifeFrame.GetComponent<Animator>().SetTrigger("Show");
        
        player.life += addlife;
        if (player.life >= 100)
            player.life = 100;

        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;


        Invoke(nameof(DestroyGO), 2f);

        transform.position = Vector3.zero;
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
