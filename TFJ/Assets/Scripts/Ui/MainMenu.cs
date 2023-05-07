using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public GameObject [] tempCarRefrence;
    private GameObject tempCar;

    void Start()
    {
        tempCar = Instantiate(tempCarRefrence[PlayerPrefs.GetInt("CharacterConfirm",0)]);   
    }
    
    public GameObject CharSelection;

    public void PlayGame(){
        SceneManager.LoadScene(1);

    }
    public void Settings(){
        SceneManager.LoadScene(2);
    }

    public void SelectChar(){
        CharSelection.SetActive(true);
        if (tempCar){
            Destroy(tempCar);
        }
    }
    public void Back(){
        CharSelection.SetActive(false);
    }
    public void QuitGame(){
        Application.Quit();
    }

}
