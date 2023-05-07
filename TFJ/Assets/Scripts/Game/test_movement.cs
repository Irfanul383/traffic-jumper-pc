using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour
{   
    public Animator animControl;
    public Health healthBar; 
    public Boost boostBar;
    private UIScore scoreUI;
    [SerializeField] private float speed;
    [SerializeField] private float boostage= 100f;
    [SerializeField] private float maxHealth = 100f; 
    [SerializeField] private float maxBoost = 100f;
    public float currentHealth;
    public float currentBoost;
    private Rigidbody2D myBody;
    private Vector2 movement;
    public bool onGround=true;
    public bool getInput=true;
    public bool alive = true;

    private void Awake()
    {
        healthBar = FindObjectOfType<Health>();
        boostBar = FindObjectOfType<Boost>();
        scoreUI = FindObjectOfType<UIScore>();
        myBody = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
        boostBar.SetMaxBoost(maxBoost);

    
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentBoost = maxBoost;
        Time.timeScale=1f;
        alive=true;
        
    }

                                                                                            // Update is called once per frame
    void Update()
    {        
        movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        keepInBounds();
        moveCar(movement);
        carJump();
        if(Input.GetAxis("Jump")==1){
            Debug.Log("sda");
            currentBoost -= boostage*Time.deltaTime;
            boostBar.SetBoost(currentBoost);
            if(currentBoost<=0){
                currentBoost=0;
                animControl.SetBool("up",false);
                animControl.SetBool("down",true);
                myBody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        
       
    }
    void moveCar(Vector2 direction){                                                        //MOVEMENT AND BOUNDS
        myBody.MovePosition((Vector2)transform.position+(direction*speed*Time.deltaTime));
    }

    void keepInBounds(){
        if (transform.position.x>1.2){
            transform.position =new Vector3(1.2f,transform.position.y,transform.position.z);
        }
        else if (transform.position.x<-1.2){
            transform.position =new Vector3(-1.2f,transform.position.y,transform.position.z);
        }
        else if (transform.position.y<-5){
            transform.position =new Vector3(transform.position.x,-5f,transform.position.z);
        }
        else if (transform.position.y>5){
            transform.position =new Vector3(transform.position.x,5f,transform.position.z);
            
        }
    }

    void carJump(){                                                               //JUMPING
        if(Input.GetAxisRaw("Jump")==1){
            animControl.SetBool("up",true);
            animControl.SetBool("down",false);
            myBody.bodyType = RigidbodyType2D.Kinematic;
        }

        else{
            animControl.SetBool("up",false);
            animControl.SetBool("down",true);
            if(Input.GetAxis("Jump")==0){
                myBody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D col){                                               //DAMAGE                                                 
        if(col.gameObject.tag == "car"){
            currentHealth-= .5f*col.relativeVelocity.magnitude*4f;
            //Debug.Log(.5f*col.relativeVelocity.magnitude*4);
        }
        if(col.gameObject.tag == "Scar"){
            currentHealth-= .5f*col.relativeVelocity.magnitude*4f;
            //Debug.Log(.5f*col.relativeVelocity.magnitude*4f);
        }
        if(col.gameObject.tag == "Trucks"){
            currentHealth-= .5f*col.relativeVelocity.magnitude*10f;
            //Debug.Log(.5f*col.relativeVelocity.magnitude*10);
        }
        if(col.gameObject.tag == "STrucks"){
            currentHealth-= .5f*col.relativeVelocity.magnitude*8f;
            //Debug.Log(.5f*col.relativeVelocity.magnitude*8);
        }
        if(col.gameObject.tag == "others"){
            currentHealth-= .5f*col.relativeVelocity.magnitude*6f;
            //Debug.Log(.5f*col.relativeVelocity.magnitude*6);
        }        
        healthBar.SetHealth(currentHealth);
        if(currentHealth<=0){
            scoreUI.SetHighscore();
            alive=false;
            
            currentHealth=0;
        }
    }

    void OnTriggerEnter2D(Collider2D powerUp){                                              //POWER UPS 
        if (powerUp.tag == "BoostB"){
            currentBoost+=30;    
        }
        if (powerUp.tag == "BoostR"){
            currentBoost+=15;
        }
        if (powerUp.tag == "Health"){
            currentHealth+=20;
            alive=true;
            
        }
        if (currentBoost>maxBoost){
            currentBoost = maxBoost;
        }
        if (currentHealth>maxHealth){
            currentHealth=maxHealth;
        }
        boostBar.SetBoost(currentBoost);
        getInput=true;
        healthBar.SetHealth(currentHealth);
        Destroy(powerUp.gameObject);
    }
}