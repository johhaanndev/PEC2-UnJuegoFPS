using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projector : MonoBehaviour
{
    public GameObject stars;
    public GameObject pointLight;
    public GameObject lod0;
    public GameObject lod1;

    public GameObject explosionParticles;

    public float life = 100f;
    [HideInInspector] public bool isDestroyed = false;

    public void Hit(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Instantiate(explosionParticles, transform);
            GetComponent<MeshCollider>().enabled = false;

            stars.SetActive(false);
            pointLight.SetActive(false);
            lod0.SetActive(false);
            lod1.SetActive(false);

            isDestroyed = true;
        }
    }
}
