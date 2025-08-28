using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f; 
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    GameObject shield;

    void Start()
    {
        shield = transform.Find("Shield").gameObject;

        rb = GetComponent<Rigidbody2D>();
              Move();
    }

    void Update()
    {
        //if (ButtonManager.isPaused)
            //return;
             ProcessInput();
       
    }

    void FixedUpdate()
    {   
        //if (ButtonManager.isPaused)
           // return;

  
    }
    
  

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");   

        moveDirection = new Vector2(moveX, moveY).normalized;
        Move();
    }

    void Move()
    {
        rb.velocity = moveDirection * moveSpeed;
        Debug.Log("Move");
    }


    void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        return shield.activeSelf;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
            {
            if (HasShield())
            {
                DeactivateShield();
            }
            else
            {
                Destroy(gameObject);
            }
             Destroy(destructable.gameObject);

        }
    }
   
}
