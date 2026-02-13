using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public float lifeTime = 0.2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Example: damage enemy
            // collision.GetComponent<EnemyHealth>()?.TakeDamage(1);
            Debug.Log("Enemy hit!");
        }
    }
}