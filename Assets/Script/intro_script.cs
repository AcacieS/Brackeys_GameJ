
using UnityEngine;

public class intro_script : MonoBehaviour
{
    public GameObject[] pairScene;
    private int whichElement;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (whichElement >= pairScene.Length - 1)
            {
                globalScript.NxtScene();
            }
            else
            {
                pairScene[whichElement].SetActive(false);
                whichElement++;
                pairScene[whichElement].SetActive(true);
            }
        }
    }
}
