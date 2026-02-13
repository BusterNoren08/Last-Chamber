using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAim player = other.GetComponentInParent<PlayerAim>();

            if (player != null)
            {
                player.AddAmmo(ammoAmount);
            }

            Destroy(gameObject);
        }
    }
}
