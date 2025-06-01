using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHealthDecrease : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<HealthScript>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(15);
            }
        }
    }
}
