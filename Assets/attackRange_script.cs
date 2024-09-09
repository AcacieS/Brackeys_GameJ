using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRange_script : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private int attackDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
        
    }
    void Attack(){
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Play an attack animation
        //Detect enemies in range of attack
        //
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy_hp_script>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
