using UnityEngine;
using UnityEngine.UI;

public class day_script : MonoBehaviour
{
    private Animator anim;
    void Start(){
        GetComponent<RawImage>().texture = Resources.Load<Texture>("Img/calendar"+globalScript.GetDay()+1);
        anim = GetComponent<Animator>();
    }
    
    void Update(){
        //anim.SetInteger("whichDay",globalScript.GetDay());
    }
    
    
}
