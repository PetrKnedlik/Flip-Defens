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
         OnDeath();
         Destroy(gameObject);
     }
 }


    public void OnDeath() // Or a similar method that's called when the enemy dies
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.EnemyDestroyed();
        }
    }

}