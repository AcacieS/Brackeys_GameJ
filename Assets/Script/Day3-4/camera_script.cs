
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    public Camera myCamera;
    public Transform player;
    public Transform limitCamYH;
    public Transform limitCamYL;
    public Transform limitCamXR;
    public Transform limitCamXL;
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
            
            /*if (cameraX < limitCamXL.position.x)
            {
                cameraX = limitCamXL.position.x;
            }
            else if (cameraX > limitCamXR.position.x)
            {
                cameraX = limitCamXR.position.x;
            }
            
            else if (cameraY < limitCamYL.position.y)
            {
                cameraY = limitCamYL.position.y;
            }
            else if (cameraY > limitCamYH.position.y)
            {
                cameraY = limitCamYH.position.y;
            }
            */
            myCamera.transform.position = new Vector3(cameraX, cameraY, myCamera.transform.position.z);
    }
}


