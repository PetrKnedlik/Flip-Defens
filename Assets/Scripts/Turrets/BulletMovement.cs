using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float Bulletspeed = 10f; // Speed of the bullet
    public float sizeMultiplier = 1f; // Multiplier to adjust the size of the bullet

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Adjust the bullet's velocity
            rb.velocity = transform.up * Bulletspeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component missing from bullet prefab.");
        }

        // Adjust the bullet's size based on the sizeMultiplier
        transform.localScale = new Vector3(transform.localScale.x * sizeMultiplier,
                                           transform.localScale.y * sizeMultiplier,
                                           transform.localScale.z); // Z remains unchanged for 2D
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet collided with an enemy
        if (collision.gameObject.CompareTag("Enemies")) // Make sure your enemy GameObjects are tagged as "Enemy"
        {
            // Call the TakeHit method on the enemy
            collision.gameObject.GetComponent<Enemy>().TakeHit();

            // Optionally, destroy the bullet upon hitting an enemy
            Destroy(gameObject);
        }
    }
void Update()
{
    Vector2 position = transform.position;
    // Example boundaries - adjust to match your game's visible area
    if (position.x < -10f || position.x > 10f || position.y < -10f || position.y > 10f)
    {
        Destroy(gameObject); // Destroy the bullet if it's outside these boundaries
    }
}

    bool RendererIsVisible()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer)
        {
            return renderer.isVisible;
        }
        return false;
    }

}
