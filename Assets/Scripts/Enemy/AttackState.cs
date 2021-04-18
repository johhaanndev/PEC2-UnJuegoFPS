using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    EnemyAI myEnemy;
    float actualTimeBetweenShots = 0;

    float timeChasing = 0f;

    public AttackState(EnemyAI enemy)
    {
        myEnemy = enemy;
    }


    public void UpdateState()
    {
        myEnemy.spotlight.color = Color.red;
        myEnemy.spotlight.spotAngle = 60;
        actualTimeBetweenShots += Time.deltaTime;

        if (!Physics.CheckSphere(myEnemy.transform.position, myEnemy.sightRange, myEnemy.playerMask))
        {
            Debug.Log("Chase the player");
            myEnemy.navMeshAgent.Resume();
            myEnemy.navMeshAgent.SetDestination(myEnemy.player.transform.position);
        }
        else
        {
            Debug.Log("Shoot the player");
            myEnemy.navMeshAgent.Stop();
            myEnemy.transform.LookAt(myEnemy.player.transform);
        }

        if (!Physics.CheckSphere(myEnemy.transform.position, myEnemy.sightRange * 2, myEnemy.playerMask))
        {
            timeChasing += Time.deltaTime;
            Debug.Log("Time chasing: " + timeChasing);
            if (timeChasing >= 2)
            {
                Debug.Log("Time exceeded");
                GoToPatrolState();
            }
        }

        Shoot();
    }


    public void Impact() { }

    public void GoToAlertState() { }

    public void GoToAttackState() { }
    public void GoToPatrolState()
    {
        timeChasing = 0;
        myEnemy.currentState = myEnemy.patrolState;
    }    

    public void OnTriggerEnter(Collider col) { }


    public void OnTriggerStay(Collider col)
    {
        myEnemy.navMeshAgent.Stop();
        myEnemy.transform.LookAt(myEnemy.player.transform);

        Shoot();
        
    }

    public void OnTriggerExit(Collider col) { }

    private void Shoot()
    {
        if (actualTimeBetweenShots > myEnemy.timeBetweenShoots)
        {
            actualTimeBetweenShots = 0;
            // shoot code
            myEnemy.Shoot();
        }
    }

    
}
