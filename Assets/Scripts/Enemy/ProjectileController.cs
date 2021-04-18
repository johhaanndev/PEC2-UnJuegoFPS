using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 20f;
    public GameObject player;

    private Rigidbody rb;
    private Vector3 dir;

    public GameObject enemyFirePoint;

    public LayerMask enemyMask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        dir = player.transform.position - enemyFirePoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
