
using UnityEngine;

public class end_script : MonoBehaviour
{

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.E))
        {
            globalScript.SetDay(1);
            globalScript.End("Intro");
        }
    }
}
