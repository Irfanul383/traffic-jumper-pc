using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject [] charRefrence;
    public GameObject [] DisplayChar;
    public int selectedChar=0;
    private GameObject confirmedChar;
    private GameObject MenuChar;



    
    
    // Start is called before the first frame update
    void Start()
    {
        confirmedChar = Instantiate(charRefrence[selectedChar]);   
    }

    public void nextChar(){
        Destroy(confirmedChar);
        Destroy(MenuChar);
        selectedChar = (selectedChar+1)%charRefrence.Length ;
        confirmedChar = Instantiate(charRefrence[selectedChar]);

    }
    public void prevChar(){
        Destroy(confirmedChar);
        Destroy(MenuChar);
        selectedChar --;
        if (selectedChar<0){
            selectedChar+=charRefrence.Length;
        }
        confirmedChar = Instantiate(charRefrence[selectedChar]);
    }
    
    public void CharacterConfirm(){
        Destroy(confirmedChar);
        PlayerPrefs.SetInt("CharacterConfirm",selectedChar);
        MenuChar = Instantiate(DisplayChar[selectedChar]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
