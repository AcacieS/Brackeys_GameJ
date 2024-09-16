using UnityEngine;

public class spawn_boss_script : MonoBehaviour
{
    public GameObject boss;
    public GameObject day3;
    public GameObject day4;
    
    public void SpawnBoss(){
        boss.SetActive(true);
        globalScript.SetDay(4);
        day3.SetActive(false);
        day4.SetActive(true);
    }
}
