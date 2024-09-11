using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private bool isMoving;
    public Animator anim;
    float horizontalInput, verticalInput;
    Rigidbody2D rb;
    Vector2 movement;
    public SpriteRenderer spriteRenderer;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    
}
