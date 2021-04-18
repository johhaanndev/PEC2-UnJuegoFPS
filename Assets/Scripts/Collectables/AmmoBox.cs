using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public GameObject player;
    private ShootingController shootingController;
    public AudioSource pickUpSound;

    private int assaultAmmo;
    private int gunAmmo;

    // Start is called before the first frame update
    void Start()
    {
        shootingController = player.GetComponent<ShootingController>();
        assaultAmmo = Mathf.RoundToInt(Random.Range(5, 30));
        gunAmmo = Mathf.RoundToInt(Random.Range(5, 30));
    }

    private void OnTriggerEnter(Collider other)
    {
        shootingController.AddAmmo(assaultAmmo, gunAmmo);
        pickUpSound.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Light>().enabled = false;

        Invoke(nameof(DestroyGO), 0.5f);
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
