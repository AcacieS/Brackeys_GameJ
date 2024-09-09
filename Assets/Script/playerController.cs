using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private bool isMoving;
    float speedX, speedY;
    Rigidbody2D rb;
    Vector2 movement;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void Update(){
        speedX = Input.GetAxisRaw("Horizontal");
        speedY =Input.GetAxisRaw("Vertical");
        
        movement = new Vector2(speedX, speedY);
        rb.velocity =  movement.normalized * moveSpeed;
        if(speedY>0){
            //go front
        }else if(speedY<0){
            //go behind
        }
        //movement != Vector2.zero
        
    }
    
}
