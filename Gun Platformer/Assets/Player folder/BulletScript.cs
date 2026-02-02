using UnityEngine;

public class BulletScript : MonoBehaviour
{


    public float lifetime = 2f; // Destroy bullet after 2 seconds

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Example: Destroy bullet on collision
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}