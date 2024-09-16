
using UnityEngine;

public class TutoDay2_script : MonoBehaviour
{
    private text_script tutoT;
     private tree_count tree_count;
     private bool[] oneTime={true,false,false,false,false,false};

    // Start is called before the first frame update
    void Start()
    {
        tutoT = GameObject.FindGameObjectWithTag("tutoText").GetComponent<text_script>();
        tree_count = GameObject.FindGameObjectWithTag("countTree").GetComponent<tree_count>();
    
    }
    void Update(){
        if(tree_count.GetTree()==1&&!oneTime[2]){
            tutoT.whichDialogue(2);
            oneTime[2]=true;
            
        }
        if(tree_count.GetTree()==2&&!oneTime[3]){
            tutoT.whichDialogue(3);
            oneTime[3]=true;
            
        }
        if(tree_count.GetTree()==3&&!oneTime[4]){
            tutoT.whichDialogue(4);
            oneTime[4]=true;
            
        }
        if(tree_count.GetTree()==(int)tree_count.GetMaxTree()&&!oneTime[5]){
            tutoT.whichDialogue(5);
            oneTime[5]=true;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"&&!oneTime[1]){
            tutoT.whichDialogue(1);
            oneTime[1]=true;
        }
    }
}
