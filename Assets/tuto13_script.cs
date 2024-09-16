using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto13_script : MonoBehaviour
{
    private text_script tutoT;
    private tree_count tree_count;

    // Start is called before the first frame update
    void Start()
    {
        tutoT = GameObject.FindGameObjectWithTag("tuto").GetComponent<text_script>();
        tree_count = GameObject.FindGameObjectWithTag("countTree").GetComponent<tree_count>();
    }
    void Update(){
        if(tree_count.GetTree()==1){
            tutoT.NxtDialogue();
            this.enabled = false;
        }
    }
}
