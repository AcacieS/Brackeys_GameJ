
using UnityEngine;

public class Enemy_hp_script : MonoBehaviour
{
    
    public int maxHealth = 4;
    public Animator anim;
    public int currentHealth;
    public tree_count tree_count;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        tree_count = GameObject.FindGameObjectWithTag("countTree").GetComponent<tree_count>();
        
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        anim.SetInteger("whichDay",globalScript.GetDay());
    }

   public void TakeDamage(int damage){
        currentHealth -= damage;
        anim.SetTrigger("isHurt");
        //hurt animation
        if(currentHealth == 0 ){
            Die();
        }
   }
   private void Die(){
    anim.SetBool("isDead", true);
    this.enabled = false;
    rb.constraints = RigidbodyConstraints2D.FreezeAll;
    if(gameObject.tag!="tree_boss"){
        tree_count.AddTree();
    }
   }
   public int getHealth(){
        return currentHealth;
   }
}
