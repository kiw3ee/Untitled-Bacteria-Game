using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life = 3;
    public string enemyTag = "EnemyLevelOne";
    public GameObject Consumable;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(enemyTag))
        {
            Destroy(other.gameObject); //destroys enemy
            Destroy(gameObject); //destroys projectile

            DropItem();
        }  
    }

    private void DropItem()
    {
        if (Consumable != null)
        {
            Instantiate(Consumable, transform.position, Quaternion.identity);
        }        
    }
}
