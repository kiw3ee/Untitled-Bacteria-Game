using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShot : MonoBehaviour
{
    public GameObject projectilePrefab;   // Your 3D projectile prefab (with a Rigidbody)
    public int numberOfProjectiles = 12;  // How many projectiles per burst
    public float projectileSpeed = 10f;   // Initial speed of each projectile

    public float cooldownTime = 10f;      // Time between bursts
    private bool canShoot = true;

    void Update()
    {
        // On R key, if not cooling down, fire
        if (Input.GetKeyDown(KeyCode.R) && canShoot)
            StartCoroutine(ShootRadialBurst());
    }

    private IEnumerator ShootRadialBurst()
    {
        canShoot = false;

        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            // Calculate direction in XZ plane
            float dirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float dirZ = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector3 dir = new Vector3(dirX, 0f, dirZ);

            // Spawn and fire
            GameObject proj = Instantiate(
                projectilePrefab,
                transform.position,
                Quaternion.LookRotation(dir)
            );
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = dir * projectileSpeed;

            angle += angleStep;
        }

        // Wait cooldown before next burst
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
}

