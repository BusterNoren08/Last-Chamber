using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
    public GameObject[] enemies;   // enemies to activate
    private bool activated = false;

    private void Start()
    {
        // Make sure enemies start disabled
        foreach (GameObject e in enemies)
            e.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;

            foreach (GameObject e in enemies)
                e.SetActive(true);
        }
    }
}
