using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;      
    public Transform fireSpot;          
    public float bulletSpeed = 10f;      
    public float shootCooldown = 0.25f;  
    
    private float lastShootTime;

    void Update()
    {
        if (ButtonManager.isPaused)
        {
            return;
        }
            
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.J)) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, fireSpot.position, Quaternion.identity);
        SFXManager.instance.PlaySFX("LaserSFX");
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
    }
}

