using UnityEngine;
using System.Collections;

public class EnemyMoveDownn : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float destroy = 1f;
    public int damage = 1;
    void Start()
    {
        GetComponent<SpriteRenderer>().flipY = true;
    }
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHp playerHp = other.GetComponent<PlayerHp>();
            if (playerHp != null)
            {
                playerHp.TakeDamage(damage);
            }
        }
        
        if (other.CompareTag("wall"))
        {
            StartCoroutine(DestroyAfterDelay(destroy));
        }
    }
    
    
    
    IEnumerator DestroyAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    

}
