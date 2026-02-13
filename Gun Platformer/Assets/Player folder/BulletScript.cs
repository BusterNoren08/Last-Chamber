using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifetime = 2f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
        Debug.Log("Bullet layer = " + LayerMask.LayerToName(gameObject.layer));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // PLAYER bullet hits enemy
        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullet") &&
            other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            Destroy(gameObject);
        }

        // ENEMY bullet hits player
        if (gameObject.layer == LayerMask.NameToLayer("EnemyBullet") &&
            other.CompareTag("Player"))
        {
            PlayerHealthScript Player = other.GetComponentInParent<PlayerHealthScript>();
            if (Player != null)
                Player.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
