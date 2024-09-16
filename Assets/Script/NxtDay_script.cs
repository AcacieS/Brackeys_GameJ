
using UnityEngine;

public class NxtDay_script : MonoBehaviour
{
    void Update(){
        if (Input.GetKeyDown(KeyCode.E))
        {
            int nxtDay = globalScript.GetDay()+1;
            globalScript.End("Day"+ nxtDay);
        }
    }

}
