using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class enemyDay3_script : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    [SerializeField] private float speed;

    private int hp;
    private int attackDamage = 1;
    private Rigidbody2D rb;
    private Transform target;
    private float chooseDirX;
    private float chooseDirY;
    private Vector3 directionToPlayer;

    private bool isAttacking = false;
    private Animator anim;
    private bool oneTime = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(anim.GetBool("isAttack")+"isAaaaaaaaa");
        
        hp = GetComponent<Enemy_hp_script>().getHealth();
        if (hp <= 3 && hp > 0)
        {
            if (oneTime)
            {
                StartCoroutine(WaitFirstRun(1));
            }
            else
            {
                Running();
            }
        }

        else if (hp == 0)
        {
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }


        if(!(Mathf.Abs(rb.velocity.x) < 0.01 && Mathf.Abs(rb.velocity.y) < 0.01)){
            chooseDirX = Math.Abs(rb.velocity.x)>0.01? rb.velocity.x*(1/Math.Abs(rb.velocity.x)): 0;
            chooseDirY = Math.Abs(rb.velocity.y)>0.01? rb.velocity.y*(1/Math.Abs(rb.velocity.y)): 0;
           //anim.SetFloat("LastMovex", rb.velocity.x);
           //anim.SetFloat("LastMovey", rb.velocity.y);
           attackPoint.transform.position = new Vector3(transform.position.x+chooseDirX, transform.position.y+chooseDirY, 0);
       }
    }
    void Running()
    {
        
        if (!isAttacking)
        {
           // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            directionToPlayer = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;
        }

        if (rb.velocity.x > 0.01f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                anim.SetFloat("whichSide",2);
            }
            else if (rb.velocity.x < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                anim.SetFloat("whichSide",2);
            }
        if (rb.velocity.y > 0.01f)
            {
                anim.SetFloat("whichSide",1);
            }
            else if (rb.velocity.y < -0.01f)
            {
                anim.SetFloat("whichSide",0);
            }
    
        ///anim.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (oneTime == false && col.gameObject.tag == "Player")
        {
            isAttacking = true;
            anim.SetBool("isAttack", isAttacking);
            Attack();
        }
    }
    private void Attack()
    {
        //it check for collider2d
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (i != 0 && hitEnemies[i - 1] != hitEnemies[i])
            {
                Debug.Log("enemy");
                hitEnemies[i].GetComponent<Enemy_hp_script>().TakeDamage(attackDamage);
            }
        }
        
        StartCoroutine(WaitRunning(2));
    }
    IEnumerator WaitFirstRun(int second)
    {
        yield return new WaitForSeconds(second);

        oneTime = false;
    }
    IEnumerator WaitRunning(int second)
    {
        yield return new WaitForSeconds(second);
        isAttacking = false;
        anim.SetBool("isAttack", isAttacking);

    }
}
