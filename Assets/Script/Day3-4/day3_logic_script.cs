using UnityEngine;

public class day3_logic_script : MonoBehaviour
{
   
   private tree_count tree_count;
   public GameObject NightFilter;
   public GameObject boss;
   public GameObject limitBoss;
   public Camera myCamera;
   public int numbTree;
    // Start is called before the first frame update
    void Start()
    {
        tree_count = GameObject.FindGameObjectWithTag("countTree").GetComponent<tree_count>();
        myCamera = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("daaaaaaaaaaaay"+globalScript.GetDay());
        if(tree_count.GetTree()>=numbTree){
            //tutorial to return home
            NightFilter.SetActive(true);
            limitBoss.SetActive(true);
            globalScript.SetDay(4);
            
        }else{
            globalScript.SetDay(3);
        }
    }
}
