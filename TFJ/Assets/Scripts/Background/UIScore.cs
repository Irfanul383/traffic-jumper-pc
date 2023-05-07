using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScore : MonoBehaviour
{
    public TMP_Text currentScore;
    public TMP_Text currentSpeed;
    public TMP_Text highscore;
    private float speedUI;
    private float score;
    
    // Start is called before the first frame update
    void Start()
    {
        highscore.text="Highscore: " + PlayerPrefs.GetInt("Highscore",0).ToString();

    }

    // Update is called once per frame
    void Update()
    {   
        score+= .5f*Time.timeScale;
        speedUI += 0.04f*Time.timeScale*.3f;
        currentScore.text = "Score: "+score.ToString("0");
        currentSpeed.text = "Speed: "+(speedUI).ToString("0")+"km/h";
        
    }
    public void SetHighscore(){
        if(score >PlayerPrefs.GetInt("Highscore",0)){
            PlayerPrefs.SetInt("Highscore",(int)score);
        }
    }
    public void resetHighscore(){
        PlayerPrefs.SetInt("Highscore",0);
        highscore.text="Highscore: " + PlayerPrefs.GetInt("Highscore",0).ToString();
    }
}
