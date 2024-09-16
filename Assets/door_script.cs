
using UnityEngine;


public class door_script : MonoBehaviour
{
    public GameObject doorClosedT;

    void Start(){
        //doorClosedT = GameObject.
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Player"){
            //doorClosedT.text = "It is locked";
            doorClosedT.SetActive(true);
        }

    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag=="Player"){
            //doorClosedT.text = "";
            doorClosedT.SetActive(false);
        }

    }
}
