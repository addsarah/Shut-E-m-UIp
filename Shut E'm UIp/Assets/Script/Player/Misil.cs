using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    public int damage = 1; 
    void Start()
    {
        Destroy(gameObject, lifeTime); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        EnemyHp enemyHealth = other.GetComponent<EnemyHp>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
        
        
        Destroy(gameObject);  
    }
}
