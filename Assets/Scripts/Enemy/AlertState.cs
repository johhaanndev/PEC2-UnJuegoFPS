using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : IEnemyState
{
    EnemyAI myEnemy;
    float currentRotationTime = 0;

    public AlertState(EnemyAI enemy)
    {
        myEnemy = enemy;
       
    }

    public void UpdateState()
    {
        myEnemy.spotlight.color = Color.yellow;
        myEnemy.spotlight.spotAngle = 30;

        myEnemy.transform.rotation *= Quaternion.Euler(0f,
                                                       Time.deltaTime * 360 * 1.0f / myEnemy.rotationTime,
                                                       0f);
        
        
        if (currentRotationTime > myEnemy.rotationTime)
        {
            currentRotationTime = 0;
            GoToPatrolState();
        }
        else
        {
            RaycastHit hit;

            if (Physics.Raycast(
                new Ray(
                    new Vector3(myEnemy.transform.position.x, myEnemy.transform.position.y + 0.5f, myEnemy.transform.position.z),
                    myEnemy.transform.forward * 100f),
                    out hit))
            {
                //Debug.Log(hit.collider.gameObject.name);
                //Debug.DrawRay(new Vector3(myEnemy.transform.position.x, myEnemy.transform.position.y + 0.5f, myEnemy.transform.position.z), myEnemy.transform.forward * 10, Color.red);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    GoToAttackState();
                }
            }
        }

        currentRotationTime += Time.deltaTime;
    }

    public void GoToAlertState() { }

    public void GoToAttackState()
    {
        myEnemy.currentState = myEnemy.attackState;
    }

    public void GoToPatrolState()
    {
        myEnemy.navMeshAgent.Resume();
        myEnemy.currentState = myEnemy.patrolState;
    }

    public void Impact()
    {
        GoToAttackState();
    }

    public void OnTriggerEnter(Collider col) { }

    public void OnTriggerExit(Collider col) { }

    public void OnTriggerStay(Collider col) { }

}
