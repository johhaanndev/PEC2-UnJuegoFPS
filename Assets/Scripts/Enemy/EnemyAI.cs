using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Light spotlight;

    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public AlertState alertState;
    [HideInInspector] public AttackState attackState;

    [HideInInspector] public NavMeshAgent navMeshAgent;

    public AudioSource fireSound;

    public float life = 100;
    public float timeBetweenShoots = 0.5f;
    public int damageForce = 10;
    public float shootHeight = 0.5f;
    public float rotationTime = 3.0f;
    private bool isDead = false;
    public Transform[] wayPoints;

    public float sightRange = 10f;

    public GameObject player;
    public GameObject droneObject;
    public Transform firePoint;

    public Transform particleFirePoint;
    public GameObject fireParticles;

    public LayerMask playerMask;
    public LayerMask enemyLayer;

    public GameObject explosionParticles;

    public int randomHit;

    // Start is called before the first frame update
    void Start()
    {
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        attackState = new AttackState(this);

        currentState = patrolState;

        navMeshAgent = GetComponent<NavMeshAgent>();
        life = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (life >= 0)
        {
            currentState.UpdateState();
        }
    }

    public void Hit(float damage)
    {
        Debug.Log("Damage dealt: " + damage);
        life -= damage;
        if (life <= 0)
        {
            Instantiate(explosionParticles, firePoint);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke(nameof(DestroyGO), 2f);
            spotlight.enabled = false;
            droneObject.SetActive(false);
            isDead = true;
        }
        else
        {
            currentState.Impact();
        }
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }

    public void Shoot()
    {
        Instantiate(fireParticles, particleFirePoint);
        RaycastHit hit;

        Vector3 dir = player.transform.position - firePoint.position;

        int prob = Random.Range(1, 100);

        if (!isDead)
        {
            fireSound.Play();
            if (Physics.Raycast(firePoint.position, dir, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Player") && prob >= randomHit)
                {
                    hit.collider.gameObject.GetComponent<PlayerController>().TakeDamage(damageForce);
                    Debug.Log("Player Hit");
                }
            }   
        }
    }


    public void Death()
    {
        Destroy(gameObject);
    }
}
