
using UnityEngine;

public class Camera_Day3 : MonoBehaviour
{
    public Camera myCamera;
    public Transform player;
    private float cameraX;
    private float cameraY;
    //private float cameraX;
    void Start()
    {
        myCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraX = player.position.x;
        cameraY = player.position.y;

        myCamera.transform.position = new Vector3(cameraX, cameraY, myCamera.transform.position.z);
        
    }
}
