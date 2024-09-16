using UnityEngine;

public class attackRange_tree : MonoBehaviour
{
    private bool isPlayerIn = false;
    public Animator anim;
   
    void Update(){
        //Debug.Log(isPlayerIn);
    }
    void OnTriggerStay2D(Collider2D col){
        
        if(col.gameObject.tag=="Player"){
            isPlayerIn = true;
            anim.SetBool("isStaying",isPlayerIn);
        }else{
            isPlayerIn = false;
            anim.SetBool("isStaying",false);

        }
       
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            isPlayerIn = false;
            anim.SetBool("isStaying",false);
        }
    }
    public bool playerIn(){
        return isPlayerIn;
    }
    
}
