using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy2 : MonoBehaviour
{

    public EnemyGround golem;

    public int enemyLife;

    public bool isAlive = true;

    private void Start()
    {

    }

    public void TakeDamage(int damagePoint)
    {
        if (isAlive)
        {
            enemyLife -= damagePoint;
            if (enemyLife <= 0)
            {
                isAlive = false;
                golem.Die();
                return;
            }
            golem.TakeDamage(10);
        }
    }
}

