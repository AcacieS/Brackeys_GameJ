using UnityEngine;


public class bridge_script : MonoBehaviour
{
    private Animator anim;
    public GameObject bridgeText;
    void Start(){
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(globalScript.GetDay()==3||globalScript.GetDay()==4){
            GetComponent<BoxCollider2D>().enabled=false;
            anim.SetBool("isBroken", false);
        }else{
            anim.SetBool("isBroken", true);
        }
        
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Player"&&!(globalScript.GetDay()==3||globalScript.GetDay()==4)){
            bridgeText.SetActive(true);
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag=="Player"&&!(globalScript.GetDay()==3||globalScript.GetDay()==4)){
            bridgeText.SetActive(false);
        }
    }
}
