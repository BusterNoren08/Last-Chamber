using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    
    public GameObject bulletPrefab;      // Prefab of the bullet
    public Transform firePoint;          // Point where bullets are spawned
    public float bulletSpeed = 10f;      // Speed of bullet
    public float fireRate = 0.2f;        // Time between shots
    float angle;
    bool isReloading= false;
    [SerializeField] int currentAmmo;
    [SerializeField] int maxAmmo = 3;
    [SerializeField] float reloadTime = 5f;
    [SerializeField] float HitStopTime = 0.01f;
    [SerializeField] float airControl = 4f; 
    SoundEfect1 ShootSoundEfect;

    private void Awake()
    {
        ShootSoundEfect = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEfect1>();
    }

    Vector2 direction;

    Rigidbody2D KnockbackRB;
    [SerializeField] int knockbackForce =10;
    private float nextFireTime;

    private void Start()
    {
        KnockbackRB = GetComponent<Rigidbody2D>();
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        AimAtMouse();

        if (Input.GetMouseButton(0) && Time.time > nextFireTime && currentAmmo !=0 ) 
        {
            Shoot();
            currentAmmo--;
            Knockback();
            nextFireTime = Time.time + fireRate;
            Debug.Log(currentAmmo);
            float moveInput = Input.GetAxisRaw("Horizontal");

            if (Mathf.Abs(KnockbackRB.linearVelocity.y) > 0.1f)
            {
                KnockbackRB.AddForce(
                    Vector2.right * moveInput * airControl,
                    ForceMode2D.Force
                );
            }
        }
    }

    void AimAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - transform.position).normalized;

        // Rotate firePoint to face the mouse
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        Debug.Log("fghj");
        ShootSoundEfect.playSFX(ShootSoundEfect.Gunshots);
        FindFirstObjectByType<hitStop>().stop(HitStopTime);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed; // Move bullet forward
        if (isReloading == false)
        {
            Invoke("Reload", reloadTime);
            isReloading = true;   

        }
    }

        
    

    void Knockback()
    {
        Vector2 knockbackDir = -direction.normalized;
        KnockbackRB.linearVelocity = Vector2.zero;

        float verticalBoost = Mathf.Clamp01(-direction.y);

        float finalForce = knockbackForce * (1f + verticalBoost * 0.6f);

        KnockbackRB.AddForce(knockbackDir * finalForce, ForceMode2D.Impulse);

        KnockbackRB.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
    }
    void Reload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reload!");
    }
}

