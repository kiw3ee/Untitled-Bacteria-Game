using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life = 3;
    public string enemyTag = "EnemyLevelOne";

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(enemyTag))
        {
            //kill counter - adds 1 kill
            if (KillCounter.instance != null)
            {
                KillCounter.instance.AddKill();
            }

            Destroy(other.gameObject); //destroys enemy
            Destroy(gameObject); //destroys projectile
        }  
    }
}
