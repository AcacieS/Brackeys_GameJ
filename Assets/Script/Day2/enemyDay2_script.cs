
using UnityEngine;


public class enemyDay2_script : MonoBehaviour
{
    private int hp;
    private int chooseDirX;
    private int chooseDirY;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5;

    private Animator anim;
    private bool changeDir = true;
    private Vector2 movement;
    private bool isGrowFinish = false;
    private Vector3 lScale;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        hp = GetComponent<Enemy_hp_script>().getHealth();
        anim.SetInteger("hp",hp);
        if (hp <= 3 && hp>0)
        {
            if(isGrowFinish){
                if (changeDir)
                {
                    Escape();
                    changeDir = false;
                }
                if(Mathf.Abs(rb.velocity.x) < 1 && Mathf.Abs(rb.velocity.y) < 1){
                    changeDir=true;
                }else{
                    Running();
                }
            }

        }else if(hp==0){
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
        
    }
    public void GrowFinish(){
        isGrowFinish=true;
       // anim.SetBool("isGrowFinish",isGrowFinish);
    }
    private void Escape()
    {

        chooseDirX = Random.Range(-1, 2); //-1,0,1
        chooseDirY = Random.Range(-1, 2);

        
        movement = new Vector2(chooseDirX, chooseDirY);
        rb.velocity = movement.normalized * moveSpeed;

        
    }
    private void Running(){
        anim.SetFloat("Horizontal", chooseDirX);
        anim.SetFloat("Vertical", chooseDirY);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (chooseDirX > 0.01f)
            {
                transform.localScale = new Vector3(lScale.x, lScale.y, lScale.z);
            }
            else if (chooseDirX < -0.01f)
            {
                transform.localScale = new Vector3(-lScale.x, lScale.y, lScale.z);
            }
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 3 || col.gameObject.layer == 6 || col.gameObject.tag == "player")
        { //enemy, building, player
            changeDir = true;
        }
    }


}
