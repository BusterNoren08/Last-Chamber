using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    
    public GameObject bulletPrefab;      // Prefab of the bullet
    public Transform firePoint;          // Point where bullets are spawned
    public float bulletSpeed = 10f;      // Speed of bullet
    public float fireRate = 0.2f;        // Time between shots
    private int bulletCounter = 0;
    float angle;
    bool isReloading= false;
    [SerializeField] int currentAmmo;
    [SerializeField] int maxTotalAmmo = 6;
    [SerializeField] float reloadTime = 5f;
    [SerializeField] float HitStopTime = 0.01f;
    [SerializeField] float airControl = 4f;
    [SerializeField] int currentClipAmmo;
    [SerializeField] int clipSize = 3;
    [SerializeField] int totalAmmo;
    [SerializeField] Transform aim;

    [SerializeField] float clipReloadTime = 2f;
    bool isReloadingClip;

    private float currentAngle = 0f;


    //SoundEfect1 ShootSoundEfect;

    private void Awake()
    {
        
    }

    Vector2 direction;

    Rigidbody2D KnockbackRB;
    [SerializeField] int knockbackForce =10;
    private float nextFireTimeReload;
    private float nextFireTime;

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxTotalAmmo);
    }

    private void Start()
    {
        KnockbackRB = GetComponent<Rigidbody2D>();
        //ShootSoundEfect = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEfect1>();
        totalAmmo = maxTotalAmmo;
        currentClipAmmo = clipSize;
        currentAmmo = maxTotalAmmo;

        nextFireTimeReload = Time.time;
        nextFireTime = Time.time;

        Cursor.visible = false;

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;


    }
    void Update()
    {
        AimAtMouse();

        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTimeReload && currentAmmo > 0f /*&& Time.time > nextFireTime /*&& currentAmmo !=0*/ ) 
        {

            Debug.Log("Shoot");
            Shoot();
            currentAmmo--;
            Knockback();

            bulletCounter++;
            if (bulletCounter >= 3)
            {
                nextFireTimeReload = Time.time + 3f;
                Debug.Log("Reloding");
                bulletCounter = 0;
            }

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
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        direction = ((Vector2)mousePos - (Vector2)firePoint.transform.position).normalized;

        //firePoint.right = (Vector2)direction;

        // Rotate firePoint to face the mouse
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        */

        direction = ((Vector2)aim.position - (Vector2)transform.position).normalized;
        firePoint.right = direction;

        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.nearClipPlane;
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //direction = ((Vector2)mousePos - (Vector2)firePoint.position).normalized;  // Player Gun Rotation Varible

        //angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //firePoint.rotation = Quaternion.Euler(0, 0, angle);
        

    }

    void Shoot()
    {
        //Debug.Log("fghj");
        //ShootSoundEfect.playSFX(ShootSoundEfect.Gunshots);
        //FindFirstObjectByType<hitStop>().stop(HitStopTime);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed; // Move bullet forward
        if (isReloading == false)
        {
           // Invoke("Reload", reloadTime);
            isReloading = true;   

        }
    }

        
    

    void Knockback()
    {
        Vector2 knockbackDir = -direction.normalized;
        KnockbackRB.linearVelocity = Vector2.zero;

        float verticalBoost = Mathf.Clamp01(-direction.y);

        float finalForce = knockbackForce * (1f + verticalBoost * 0.6f);

        //KnockbackRB.AddForce(knockbackDir * finalForce, ForceMode2D.Impulse);

        KnockbackRB.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
    }
    //void Reload()
   // {
        
       // isReloading = false;
       // Debug.Log("Reload!");
   // }
}

