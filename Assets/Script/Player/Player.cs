using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f; 
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    void Start()
    {
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
}
