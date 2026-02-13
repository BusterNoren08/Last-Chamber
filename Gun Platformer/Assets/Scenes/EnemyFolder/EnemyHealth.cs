using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public bool explode = false;
    public float explosionRadius = 2f;
    public int explosionDamage = 1;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
  
            if (explode)
            {
                Explode();
            }
            else
            {
                Die();
            }
            
                
        }
    }
    void Explode()
    {

        // Damage anything in radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHealthScript ph = hit.GetComponent<PlayerHealthScript>();
                if (ph != null)
                    ph.TakeDamage(explosionDamage);
            }
        }

        // Trigger screen shake
        //CameraShake.Instance.Shake();

        // Kill drone
        Destroy(gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
