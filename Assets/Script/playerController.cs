
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private bool isMoving;
    private Animator anim;
    public GameObject attackPoint;
    float horizontalInput, verticalInput;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 lScale;
    

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lScale = transform.localScale;
        
    }

    
    private void Update(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        movement.x = horizontalInput;
        movement.y = verticalInput;

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        //spriteRenderer.flipX = movement.x< 0.01 ? true: false;

        if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(lScale.x, lScale.y, lScale.z);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-lScale.x, lScale.y, lScale.z);
            }
         if(!(horizontalInput == 0 && verticalInput == 0)){
            anim.SetFloat("LastMovex", horizontalInput);
            anim.SetFloat("LastMovey", verticalInput);
            attackPoint.transform.position = new Vector3(transform.position.x+horizontalInput, transform.position.y+verticalInput, 0);
        }
        
    }
    public float getHorizontal(){
        return horizontalInput;
    }
    public float getVertical(){
        return verticalInput;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D col){
        /*if(col.gameObject.tag=="tree"&&""){

        }*/
    }
    
    
}
