using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_scroll : MonoBehaviour
{
    public float BaseSpeed;
    public float score;
    public float acceleration;
    public Vector3 Start_position;
    
    // Start is called before the first frame update
    void Start()
    {
        Start_position = transform.position; 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*BaseSpeed*Time.deltaTime);
        progress();
        if (transform.position.y < -4.86f)
        {
            transform.position = Start_position;

        }
        acceleration*=Time.timeScale;
    }

    void progress(){
        
        BaseSpeed += (acceleration*Time.deltaTime);
        
    }
    
}
