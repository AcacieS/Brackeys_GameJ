using System.Collections;

using UnityEngine;

public class head_shadow_script : MonoBehaviour
{
    private Animator anim;
    private time_script playerHp;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerHp = GameObject.FindGameObjectWithTag("time").GetComponent<time_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.enabled == true){
            StartCoroutine(Disappear(5));
        }
    }
    IEnumerator Disappear(int second){
         yield return new WaitForSeconds(second);
         Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag=="Player"&&anim.enabled==true){
            playerHp.GetHurt(0.2f);
        }
    }
   

}
