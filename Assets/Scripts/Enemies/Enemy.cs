using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; // Number of hits the enemy can take before being destroyed

    // Method to call when the enemy takes a hit
    public void TakeHit()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the enemy GameObject
        }
    }
}
