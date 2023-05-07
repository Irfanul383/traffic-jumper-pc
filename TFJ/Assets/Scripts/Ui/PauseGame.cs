using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public static bool IsPaused = false;
    public GameObject PauseUI;
    public GameObject DeathUI;
    private test_movement MainGame;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(IsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
        death();

    }

    public void Resume(){
        PauseUI.SetActive(false);
        Time.timeScale=1f;
        IsPaused = false;

    }
    public void Pause(){
        PauseUI.SetActive(true);
        Time.timeScale=0f;
        IsPaused = true;
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale=1f;
    }
    public void RestartGame(){
        DeathUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }
    void death(){
        MainGame = FindObjectOfType<test_movement>();
        if(MainGame.alive==false){
            Time.timeScale = 0f;
            DeathUI.SetActive(true);
        }
    }

    public void Settings(){
        SceneManager.LoadScene(2);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
