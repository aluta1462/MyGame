using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStatus
    {
        public float Health = 100f;
        
    }

    public EnemyStatus enemyStatus = new EnemyStatus();


    public void DamageEnemy(int dmg)
    {
        enemyStatus.Health -= dmg;
        if (enemyStatus.Health <= 0)
        {
            Debug.Log("KILL Enemy");
            GameMaster.KillEnemy(this);
        }
    }
}
