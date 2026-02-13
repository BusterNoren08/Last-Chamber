using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [Header("Slash Settings")]
    public GameObject slashPrefab;
    public Transform slashSpawnPoint;
    public float slashCooldown = 0.3f;

    private float lastSlashTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            TrySlash();
        }
    }

    void TrySlash()
    {
        if (Time.time < lastSlashTime + slashCooldown)
            return;

        Instantiate(slashPrefab, slashSpawnPoint.position, slashSpawnPoint.rotation);
        lastSlashTime = Time.time;
    }
}