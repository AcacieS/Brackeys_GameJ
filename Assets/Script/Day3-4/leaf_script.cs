using System.Collections;
using UnityEngine;

public class leaf_script : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;
    private Vector3 directionToPlayer;
    private float speed = 3;
    private time_script playerHp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHp = GameObject.FindGameObjectWithTag("time").GetComponent<time_script>();
        StartCoroutine(Death(5));
    }

    // Update is called once per frame
    void Update()
    {
        
        directionToPlayer = (target.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            playerHp.GetHurt(10f);
            Destroy(gameObject);
        }
    }
    IEnumerator Death(int second){
         yield return new WaitForSeconds(second);
         Destroy(gameObject);
    }
}
