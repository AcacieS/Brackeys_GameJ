
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class boss_hp_script : MonoBehaviour
{
    //public boss_script boss_script;
    public int maxHp;
    public Image hp_bar;
    //private int remainHp;
    private int hp;
    //public GameObject hpText;
    private float divide;
    
    
    
    
    // Update is called once per frame
    void Update()
    {
       
        hp = GetComponent<Enemy_hp_script>().getHealth();
        hp_bar.fillAmount = (float) hp / (float) maxHp;
        
        //hpText.text = hp.ToString();
        
    }
}
