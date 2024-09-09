using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;

public class time_script : MonoBehaviour
{
    [SerializeField] public int medTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MedTime(medTime));
    }
    IEnumerator MedTime(int time){
        yield return new WaitForSeconds(time);
        globalScript.End("inondation");
    }
}
