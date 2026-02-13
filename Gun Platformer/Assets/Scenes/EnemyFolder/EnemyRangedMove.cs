using UnityEngine;

public class EnemyRangedMove : MonoBehaviour
{
    public float moveSpeed = 2f;

    // Distance where enemy stops approaching
    public float stopDistance = 4f;

    // Distance where enemy runs away if player gets too close
    public float retreatDistance = 2f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            // Move toward player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
        else if (distance < retreatDistance)
        {
            // Move away from player
            Vector2 direction = (transform.position - player.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
        // If between retreatDistance and stopDistance ? stay still and shoot
    }
}
