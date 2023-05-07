using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedCars : MonoBehaviour
{
    private BG_scroll BG;
    private test_movement player;
    private float speed;
    public float typeSpeed;
    //private List<float> spawnCoords = new List<float>();

    private Rigidbody2D rb;
    private float trig;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        BG = FindObjectOfType<BG_scroll>();
        player = FindObjectOfType<test_movement>();
        speed = BG.BaseSpeed+typeSpeed;

        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        y = Input.GetAxis("Jump");
        mech(y);
        rb.velocity = new Vector2(0,-speed);
        if (transform.position.y<-6){
            Destroy(this.gameObject);
        }
        if(transform.position.y<-4.2){
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void mech(float x) {
        if(x>.65 && player.currentBoost>0){
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else{
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
