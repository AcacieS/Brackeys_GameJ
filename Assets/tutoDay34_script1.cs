
using UnityEngine;

public class TutoDay34_script : MonoBehaviour
{
     public GameObject boss_hp;
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
         if(tree_count.GetTree()==1&&!oneTime[1]){
            tutoT.whichDialogue(1);
            oneTime[1]=true;
            
        }
        if(tree_count.GetTree()==3&&!oneTime[2]){
            tutoT.whichDialogue(2);
            oneTime[2]=true;
            
        }
        if(tree_count.GetTree()==5&&!oneTime[3]){
            tutoT.whichDialogue(3);
            oneTime[3]=true;
            
        }
        if(boss_hp.activeInHierarchy&&!oneTime[4]){
            tutoT.whichDialogue(4);
            oneTime[4]=true;
        }
    
    }

   
}
