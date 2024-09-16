
using UnityEngine;

public class home_script : MonoBehaviour
{
    private tree_count tree_count;

    // Start is called before the first frame update
    void Start()
    {
        tree_count = GameObject.FindGameObjectWithTag("countTree").GetComponent<tree_count>();
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(tree_count.GetEnd()==true&&col.gameObject.tag=="Player"){
            globalScript.End("DaySleep");
        }
    }
}
