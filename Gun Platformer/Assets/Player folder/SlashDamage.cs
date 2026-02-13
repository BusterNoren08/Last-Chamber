using UnityEngine;

public class SlashDamage : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 0.15f; // how long the slash hitbox exists

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
