using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int currentHealth = 1;
    public int pointsOnDeath = 10;
    private Animator animator; 
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damageAmount)
    {
        
        currentHealth -= damageAmount;
        Debug.Log("Enemy took damage. Current health: " + currentHealth);
        if (currentHealth > 0)
        { 
            animator.SetTrigger("GetDmg");
            SFXManager.instance.PlaySFX("HitSFX");
           
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SFXManager.instance.PlaySFX("ExplosionSFX");
        Debug.Log("Enemy died!");
        PointManager.AddPoints(pointsOnDeath);
        Destroy(gameObject);
        
    }
}
