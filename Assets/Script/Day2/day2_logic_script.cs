
using UnityEngine;

public class day2_logic_script : MonoBehaviour
{
   private tree_count tree_count;
   public GameObject doorOpen;
   public GameObject doorClosed;
    // Start is called before the first frame update
    void Start()
    {
        tree_count = GameObject.FindGameObjectWithTag("countTree").GetComponent<tree_count>();
    }


    // Update is called once per frame
    void Update()
    {
        globalScript.SetDay(2);
        if(tree_count.GetTree()==1){
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
            //treesDay2.SetActive(true);
        }
        
    }
}
