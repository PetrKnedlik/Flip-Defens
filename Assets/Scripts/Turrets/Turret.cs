using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f; // Bullets per second
    public float detectionRange = 10f; // Range to detect enemies
    private float fireCooldown = 0;
    private Transform target;

    void Update()
    {
        FindClosestEnemy();
        if (target != null)
        {
            RotateTowardsTarget();
            if (fireCooldown <= 0)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
        }

        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies"); // Replace "Enemy" with your enemy tag
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= detectionRange)
        {
            target = closestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

void RotateTowardsTarget()
{
    if (target == null) return;

    // Calculate direction from the turret to the target
    Vector2 direction = target.position - transform.position;

    // Calculate the angle needed to rotate towards the target
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    // Set the turret's rotation towards that angle, considering the sprite's default facing direction
    // Adjust the '- 90' if your sprite's default orientation is different
    Quaternion targetRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    // Apply the rotation
    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
}


    void Shoot()
    {
        // Instantiate the projectile at the turret's position and rotation
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
