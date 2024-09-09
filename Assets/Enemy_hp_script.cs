using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_hp_script : MonoBehaviour
{
    
    public int maxHealth = 4;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

   public void TakeDamage(int damage){
    currentHealth -= damage;
    //hurt animation
    if(currentHealth <= 0 ){
        Die();
    }
   }
   void Die(){
    Debug.Log("tree dead");
    //Die animation;
    //Disable the enemy
   }
}
