using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    EnemyAI myEnemy;
    private int nextWayPoint = 0;

    public PatrolState(EnemyAI enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        myEnemy.spotlight.color = Color.green;
        myEnemy.spotlight.spotAngle = 30;

        myEnemy.navMeshAgent.destination = myEnemy.wayPoints[nextWayPoint].position;

        if (myEnemy.navMeshAgent.remainingDistance <= myEnemy.navMeshAgent.stoppingDistance)
        {
            //nextWayPoint = (nextWayPoint + 1) % myEnemy.wayPoints.Length;
            nextWayPoint += 1;
            if (nextWayPoint >= myEnemy.wayPoints.Length)
            {
                nextWayPoint = 0;
            }
        }
        

        if (Physics.CheckSphere(myEnemy.transform.position, myEnemy.sightRange, myEnemy.playerMask))
        {
            myEnemy.navMeshAgent.Stop();
            GoToAlertState();
        }
    }

    public void Impact()
    {
        Debug.Log("Bullet impact!");
        GoToAttackState();
    }

    public void GoToAlertState()
    {
        myEnemy.navMeshAgent.Stop();
        myEnemy.currentState = myEnemy.alertState;
    }

    public void GoToAttackState()
    {
        myEnemy.currentState = myEnemy.attackState;
    }

    public void GoToPatrolState()
    {
        throw new System.NotImplementedException();
    }

    //public void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        GoToAlertState();
    //    }
    //}

    //public void OnTriggerStay(Collider col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        GoToAlertState();
    //    }
    //}

    //public void OnTriggerExit(Collider col)
    //{
    //    Debug.Log("Trigger exit");
    //}

    
}
