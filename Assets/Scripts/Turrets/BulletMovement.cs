using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public float sizeMultiplier = 1f; // Multiplier to adjust the size of the bullet

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Adjust the bullet's velocity
            rb.velocity = transform.up * speed;
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
}
