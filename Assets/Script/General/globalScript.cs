
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalScript : MonoBehaviour
{
    // Start is called before the first frame update
    private static int currentScene;
    private static int day = 1;

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public static int GetDay(){
        return day;
    }
    
    public static void SetDay(int setDay){
        day = setDay;
        
    }
    public static void NxtScene(){
         SceneManager.LoadScene(currentScene+1);
    }
    public static void End(string whichEnd){
       
         SceneManager.LoadScene("Scenes/"+whichEnd);
    }
}
