using Unity.Cinemachine;
using UnityEngine;

public class KamikazeDrone : MonoBehaviour
{
    public float speed = 3f;
    public float explodeDistance = 1.5f;

    public float explosionRadius = 2f;
    public int explosionDamage = 1;

    private Transform player;
    private EnemyHealth health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (player == null) return;

        // Move toward player
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        // Explode if close enough
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= explodeDistance)
        {
            Explode();
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

        GetComponent<CinemachineImpulseSource>().GenerateImpulse();

        // Kill drone
        Destroy(gameObject);
    }

    // Draw explosion radius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
