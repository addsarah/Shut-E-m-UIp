using UnityEngine;

public class InfiniteScrollPairWithMin : MonoBehaviour
{
    public float scrollSpeed = 2f;       
    public float yMin = -10f;           
    public Transform otherBackground;    


    private float spriteHeight;


    void Start()
    {


        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            spriteHeight = sr.bounds.size.y;
        }
        else
        {
            Debug.LogError("SpriteRenderer tidak ditemukan!");
        }
    }


    void Update()
    {


        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        if (transform.position.y <= yMin)
        {
            transform.position = new Vector3(
                transform.position.x,
                otherBackground.position.y + spriteHeight,
                transform.position.z
            );
        }
    }


}