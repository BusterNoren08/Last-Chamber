using UnityEngine;

public class DroneHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public bool explode = false;

    public GameObject explosionPrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            if (explode)
            {
                ExplodeAndDie();
            }
        }
    }

    void ExplodeAndDie()
    {
        if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
