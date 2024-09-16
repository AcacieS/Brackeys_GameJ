using System.Collections;
using UnityEngine;

public class tree_boss_script : MonoBehaviour
{
    /*hp = GetComponent<Enemy_hp_script>().getHealth();
            if (oneTime)
            {
                StartCoroutine(WaitFirstRun(2));
            }
            else
            {
                Running();
            }
        
        if (hp == 0)
        {
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }*/
     //public Transform attackPoint;
    public float attackRange = 0.5f;
    [SerializeField] private float speed;

    public attackRange_tree attRange_script;  
    private int hp;
    private Rigidbody2D rb;
    private Transform target;
    private Vector3 directionToPlayer;
    private bool isAttacking = false;
    private Animator anim;
    private bool oneTime = true;
    private Vector3 lScale;
    private bool isGrowFinish=false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lScale = transform.localScale;
    }
    

    // Update is called once per frame
    void Update()
    {
            hp = GetComponent<Enemy_hp_script>().getHealth();
            if(isGrowFinish){
                if (oneTime)
                {
                    StartCoroutine(WaitFirstRun(2));
                }
                else
                {
                    Running();
                }
            }

        if (hp == 0)
        {
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
    

       /* if(!(Mathf.Abs(rb.velocity.x) < 0.01 && Mathf.Abs(rb.velocity.y) < 0.01)){
            chooseDirX = Math.Abs(rb.velocity.x)>0.01? rb.velocity.x*(1/Math.Abs(rb.velocity.x)): 0;
            chooseDirY = Math.Abs(rb.velocity.y)>0.01? rb.velocity.y*(1/Math.Abs(rb.velocity.y)): 0;
           //attackPoint.transform.position = new Vector3(transform.position.x+chooseDirX, transform.position.y+chooseDirY, 0);
       }*/
    }
    public void GrowFinish(){
        isGrowFinish=true;
    }
    void Running()
    {
        
        if (!isAttacking)
        {
           // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            directionToPlayer = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;

            if (rb.velocity.x > 0.01f)
            {
                transform.localScale = new Vector3(lScale.x, lScale.y, lScale.z);
                anim.SetFloat("whichSide",2);
            }
            else if (rb.velocity.x < -0.01f)
            {
                transform.localScale = new Vector3(-lScale.x, lScale.y, lScale.z);
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
        }else{
            rb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (oneTime == false && col.gameObject.tag == "Player" && isAttacking==false)
        {
            isAttacking = true;
            anim.SetBool("isAttack", isAttacking);
        }
    }
    IEnumerator WaitFirstRun(int second)
    {
        yield return new WaitForSeconds(second);
        oneTime = false;
    }

    public void WaitAttFinish(){
        
        isAttacking = false;
        anim.SetBool("isAttack", isAttacking);
        anim.SetBool("AttackReady", isAttacking);
        
    }
    
     public void HitPlayer(){
        if(attRange_script.playerIn()){
            Debug.Log("gothit");
            GameObject.FindGameObjectWithTag("time").GetComponent<time_script>().GetHurt(10f);
        }
    }
    
}

