
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class text_script : MonoBehaviour
{
    public GameObject NPC_dialogue;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    private bool continueE = false;
    void Start(){
        StartCoroutine(Typing());
        /*if(globalScript.tutoActive==false){
            
            SoundManagerScript.instance.PlaySound(dialogueSound[index]);
        }*/
    }
    // Update is called once per frame
    void Update()
    {

        /*if(globalScript.tutoActive==false){
            if(NPC_dialogue.activeInHierarchy == true){
                if(Input.GetKeyDown(KeyCode.E)&&continueE==true){
                        if(dialogueText.text == dialogue[index]){
                            NextLine();
                        }else{
                            StartCoroutine(Typing());
                        }
                }
            }
        }*/
    }
    public void NxtDialogue(){
        if(continueE==true){
            if(dialogueText.text == dialogue[index]){
                    NextLine();
                }else{
                    StartCoroutine(Typing());
            }
        }
    }
    public void whichDialogue(int i){
        dialogueText.text = "";
        index = i;
        StartCoroutine(Typing());
    }
    public IEnumerator Typing(){
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        if(dialogueText.text == dialogue[index]){
            continueE = true;
            StartCoroutine(Disappear(5,index));
        }
    }
     IEnumerator Disappear(int seconds,int i){
        yield return new WaitForSeconds(seconds);
        if(index==i){
            zeroText();
        }
     }
    public void NextLine(){
        continueE = false;
        if(index<dialogue.Length-1){
            index++;
            dialogueText.text="";
            //SoundManagerScript.instance.PlaySound(dialogueSound[index]);
            StartCoroutine(Typing());
       }else{
            NPC_dialogue.SetActive(false);
            continueE=false;
            zeroText();
        }
    }
    public void zeroText(){
        dialogueText.text = "";
        index=0;
    }
   
}

