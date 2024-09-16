
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class time_script : MonoBehaviour
{
    public float maxTime;
    private float remainTime;
    public Image timer_med;
    public Text getHurtUI;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        remainTime = maxTime;
    }
    void Update()
    {

        if (remainTime > 0)
        {
            TimeDecount();
        }
        else
        {
            anim.SetBool("isDead", true);
        }
       
    }
    
    public void SetRemainTime(int number){
        remainTime = number;
        timer_med.fillAmount = remainTime / maxTime;
    }
    public void GetHurt(float hurtDmg)
    {
        remainTime -=hurtDmg;
        timer_med.fillAmount = remainTime / maxTime;
        getHurtUI.text=(-hurtDmg).ToString();
        StartCoroutine(getHurtUIfinish(1));
    }
    public void TimeDecount(){
        remainTime -= Time.deltaTime;
        timer_med.fillAmount = remainTime / maxTime;
    }
    IEnumerator getHurtUIfinish(int second){
        yield return new WaitForSeconds(second);
        getHurtUI.text="";
    }

}
