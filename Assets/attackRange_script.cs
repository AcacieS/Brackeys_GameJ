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
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
            if (Time.time >= nextAttackTime&&Input.GetKeyDown(KeyCode.Space))
            {
                nextAttackTime = Time.time + 1f / attackRate;
                Attack();
            }
        


    }
    void Attack()
    {
        
        anim.SetTrigger("isAttack");
        //it check for collider2d
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        for(int i = 0; i < hitEnemies.Length; i++){
            if(i!=0&&hitEnemies[i-1]!=hitEnemies[i]){
                Debug.Log("enemy");
                hitEnemies[i].GetComponent<Enemy_hp_script>().TakeDamage(attackDamage);
            }
        }
        /*foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("here"+enemy);
            
        }*/
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
