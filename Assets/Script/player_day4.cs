
using UnityEngine;
//using UnityEngine.camera;

public class player_day4 : MonoBehaviour
{
    private Camera myCamera;
    public Transform pointCamera;
    public Transform pointPlayer;
    private bool isSpawnBoss = false;
    public GameObject[] limit;
    public GameObject boss_hp;
    public GameObject boss;
    public time_script time;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawnBoss==true){
            
            myCamera.transform.position = pointCamera.position;
            transform.position = Vector2.MoveTowards(transform.position, pointPlayer.position, 3 * Time.deltaTime);
            boss.SetActive(true);
            if(isNear(transform.position,pointPlayer.position)){
                isSpawnBoss=false;
                boss_hp.SetActive(true);
                
                time.SetRemainTime(240);
                GetComponent<playerController>().enabled = true;
                for(int i=0; i<limit.Length; i++){
                limit[i].GetComponent<PolygonCollider2D>().enabled=true;
                }
                //tuto activate so for now we will do ;
                this.enabled = false;
                
            }else{
                GetComponent<playerController>().enabled = false;
            }
        } 
    }
    private bool isNear(Vector3 from, Vector3 target){
        bool isNear = false;
        if(from.x<=target.x+0.01&&from.x>target.x-0.01&&from.y<=target.y+0.01&&from.y>target.y-0.01){
            isNear = true;
        }
        return isNear;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="spawnBossArea"){
            myCamera.orthographicSize = 8;
            myCamera.GetComponent<Camera_Day3>().enabled = false;
            isSpawnBoss = true;
        }
        
        
    }
}
