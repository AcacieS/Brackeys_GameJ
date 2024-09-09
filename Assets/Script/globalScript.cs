
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void End(string whichEnd){
         SceneManager.LoadScene("Scenes/"+whichEnd);
    }
}
