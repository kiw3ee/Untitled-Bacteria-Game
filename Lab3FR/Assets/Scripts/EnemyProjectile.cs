using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float life = 25f;
    public string playerTag = "Player";
    public int damageAmount = 25; 

    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthScript hs = other.GetComponent<HealthScript>();
        if (hs != null)
        {
            hs.currentHealth -= damageAmount;
        }

        Destroy(gameObject);
    }
}