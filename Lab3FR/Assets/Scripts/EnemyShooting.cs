using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;
    public Transform enemyBulletSpawnPoint;
    public GameObject enemyBulletPrefab;

    public float detectionRadius = 10f;
    public float bulletSpeed = 20f;
    public float fireRate = 2f;

    private float nextFireTime = 0f;

    void Update()
    {   
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius && Time.time >= nextFireTime)
        {
            var bullet = Instantiate(enemyBulletPrefab, enemyBulletSpawnPoint.position, enemyBulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = enemyBulletSpawnPoint.forward * bulletSpeed;

            nextFireTime = Time.time + fireRate;
        }
    }
}