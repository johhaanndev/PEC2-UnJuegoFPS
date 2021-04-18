using UnityEngine;

public interface IEnemyState 
{
    void UpdateState();
    void GoToAttackState();
    void GoToAlertState();
    void GoToPatrolState();
    void Impact();
}
