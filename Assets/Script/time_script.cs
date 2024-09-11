using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UI;

public class time_script : MonoBehaviour
{
    private float maxTime = 50;
    [SerializeField] private float remainTime;
    public Image timer_med;
    // Start is called before the first frame update
    void Start()
    {
        remainTime = maxTime;
        
    }
    void Update()
    {
        if (remainTime > 0)
        {
            remainTime -= Time.deltaTime;
            timer_med.fillAmount = remainTime / maxTime;

        }else{
            globalScript.End("inondation");
        }
    }
   
}
