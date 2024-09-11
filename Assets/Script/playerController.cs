using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private bool isMoving;
    public Animator anim;
    public GameObject attackPoint;
    float horizontalInput, verticalInput;
    Rigidbody2D rb;
    Vector2 movement;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    private void Update(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput =Input.GetAxisRaw("Vertical");
        movement.x = horizontalInput;
        movement.y = verticalInput;

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        //spriteRenderer.flipX = movement.x< 0.01 ? true: false;

        Debug.Log(horizontalInput+"input:"+verticalInput);
        if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            
        if(!(horizontalInput == 0 && verticalInput == 0)){
            anim.SetFloat("LastMovex", horizontalInput);
            anim.SetFloat("LastMovey", verticalInput);
            attackPoint.transform.position = new Vector3(transform.position.x+horizontalInput, transform.position.y+verticalInput, 0);
        }

        
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    
}
