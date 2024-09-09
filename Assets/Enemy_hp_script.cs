using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_hp_script : MonoBehaviour
{
    
    public int maxHealth = 4;
    public Animator anim;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

   public void TakeDamage(int damage){
        currentHealth -= damage;
        anim.SetTrigger("isHurt");
        //hurt animation
        if(currentHealth == 0 ){
            Die();
        }
   }
   void Die(){
    Debug.Log("tree dead");
    anim.SetBool("isDead", true);
    this.enabled = false;
   }
}
