
using UnityEngine;

public class head_script : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private time_script playerHp;

    
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 5;
        playerHp = GameObject.FindGameObjectWithTag("time").GetComponent<time_script>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="head_shadow"&&!col.GetComponent<Animator>().enabled == true){

            anim.SetBool("isFinish",true);
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            col.GetComponent<Animator>().enabled = true;
        }
        if(col.gameObject.tag=="Player"){
            playerHp.GetHurt(10f);
        }
    }
    public void Death(){
        Destroy(gameObject);
    }
}
