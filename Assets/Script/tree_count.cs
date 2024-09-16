
using UnityEngine;
using UnityEngine.UI;

public class tree_count : MonoBehaviour
{
    public float maxTree = 3;
    private int treeNb = 0;
    public Image treeImg;
    private bool isEnd = false;
    
    // Start is called before the first frame update
    void Start()
    {
        treeImg.fillAmount = treeNb / maxTree;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(treeNb==maxTree){
            isEnd = true;
        }
    }
    public void AddTree(){
        treeNb++;
        treeImg.fillAmount = treeNb / maxTree;
    }
    public int GetTree(){
        return treeNb;
    }
    public float GetMaxTree(){
        return maxTree;
    }
    public bool GetEnd(){
        return isEnd;
    }
}
