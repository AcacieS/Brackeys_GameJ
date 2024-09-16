using System.Collections;

using UnityEngine;

public class boss_script : MonoBehaviour
{
    [SerializeField] Transform treeLimitXL;
    [SerializeField] Transform treeLimitXR;
    [SerializeField] Transform treeLimitYL;
    [SerializeField] Transform treeLimitYH;

    [SerializeField] private int state = 0;
    [SerializeField] private GameObject leaf;
    [SerializeField] private Transform leafPos;
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject head_shadow;
    [SerializeField] private GameObject head;
    private Rigidbody2D rb;
    private Transform target;
    private Animator anim;
    private bool activateTuto;
    //treeLimitXL+miniSpace, treeLimitXR-miniSpace
    private float miniSpace = 3f;
    private float oldPosX;
    private float oldPosY;
    private bool[] isAttack = { false, false, false, false };
    private int[] waitAttTime = { 10, 4, 5, 11 };
    private bool[] isCoReady = { true, true, true, true };

   /* private bool isInvincible = true;

    private int chooseDirX;
    private int chooseDirY;*/
    [SerializeField] private float moveSpeed = 5;

    private bool changeDir = true;
    private Vector2 movement;
    private Vector3 lScale;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("whichState", state); 
        RandomState();
        /*if (state == 0 && activateTuto == true)
        {
            isInvincible = false;
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

        }*/
        if (state == 1)
        {
            //isInvincible = true;
            State1();
        }
        else if (state == 2)
        {
            //isInvincible = true;
            State2();
        }
        else if(state == 3 )
        {
            //isInvincible = true;
            State3();
        }

    }
    void RandomState(){
        if (isCoReady[0])
        {
            isCoReady[0] = false;
            state = Random.Range(1,4);
            StartCoroutine(StateTime(waitAttTime[0]));
        }
    }
    IEnumerator StateTime(int second){
        yield return new WaitForSeconds(second);
        isCoReady[0] = true;
    }
    /*private void Escape()
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
    public bool GetInvincible(){
        return isInvincible;
    }*/


    void State1() //head
    {
        if (isCoReady[1])
        {
            anim.SetBool("isAttack", false);
            isCoReady[1] = false;
            StartCoroutine(WaitAttack(waitAttTime[1]));
        }
        if (isAttack[1] == true)
        {
            isAttack[1] = false;
            anim.SetBool("isAttack", true);
            int whichHead = Random.Range(0,2);
            anim.SetInteger("whichHead",whichHead);
        }
    }
    public void SpawnHead()
    {
        anim.SetBool("isAttack", false);
        oldPosX = target.position.x;
        oldPosY = target.position.y;
        Instantiate(head_shadow, new Vector3(oldPosX, oldPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(head, new Vector3(oldPosX, treeLimitYH.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }



    void State2()
    { //leaves
        anim.SetBool("isAttack", true);
        if (isCoReady[2])
        {
            //anim.SetBool("isAttack", false);
            isCoReady[2] = false;
            StartCoroutine(WaitAttack(waitAttTime[2]));
        }
        if (isAttack[2] == true)
        {

            isAttack[2] = false;

            Instantiate(leaf, new Vector3(leafPos.position.x, leafPos.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

        }
    }
    void State3()
    { //tree
        if (isCoReady[3])
        {
            anim.SetBool("isAttack", false);
            isCoReady[3] = false;
            StartCoroutine(WaitAttack(waitAttTime[3]));
        }
        if (isAttack[3] == true)
        {
            isAttack[3] = false;
            anim.SetBool("isAttack", true);
        }
    }
    public void SpawnRandomTree()
    {
        anim.SetBool("isAttack", false);
        float treeHorizontal = RandomSpawnTreeX();
        float treeVertical = RandomSpawnTreeY();
        while ((target.transform.position.x + miniSpace < treeHorizontal && target.transform.position.x - miniSpace > treeHorizontal) || (target.transform.position.y + miniSpace < treeVertical && target.transform.position.y - miniSpace > treeVertical))
        {
            treeHorizontal = RandomSpawnTreeX();
            treeVertical = RandomSpawnTreeY();
        }

        Instantiate(tree, new Vector3(treeHorizontal, treeVertical, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    private float RandomSpawnTreeX()
    {
        return Random.Range(treeLimitXL.position.x + miniSpace, treeLimitXR.position.x - miniSpace);
    }
    private float RandomSpawnTreeY()
    {
        return Random.Range(treeLimitYL.position.y + miniSpace, treeLimitYH.position.y - miniSpace);
    }
    IEnumerator WaitAttack(int second)
    {
        yield return new WaitForSeconds(second);
        isAttack[state] = true;
        isCoReady[state] = true;

    }
    void Death()
    {
        anim.SetBool("isDead", true);

    }
    public void isAttackFinish()
    {
        anim.SetBool("isAttack", false);
    }
}
