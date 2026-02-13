using UnityEngine;

public class LightDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthScript health = collision.GetComponent<PlayerHealthScript>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
