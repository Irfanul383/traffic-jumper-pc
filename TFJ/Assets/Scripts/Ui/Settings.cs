using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float vol ){
        audioMixer.SetFloat("Volume",vol);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

}
