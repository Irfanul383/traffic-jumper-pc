using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject [] playerCarRefrence;
    private GameObject playerCar;

    void Start()
    {
        playerCar = Instantiate(playerCarRefrence[PlayerPrefs.GetInt("CharacterConfirm",0)]);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
