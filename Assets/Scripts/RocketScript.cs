using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 3.6f;
    public float inputMove;

    public GameObject bullet;
    public AudioSource shotSound;
    public AudioSource barelSound;
    public AudioSource bgSound;
    [SerializeField]
    public int maxHealth = 100;
    public int Health = 0;

    [SerializeField]
     public float fuelAmount;
     public Text fuelMeter;
     private bool canFly;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        barelSound = GetComponent<AudioSource>();
        bgSound.Play();
        fuelAmount = 100;
        canFly = true;
        Health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
       // Debug.Log(Screen.width + " x " + transform.position.x);
    }

    // Update is called once per frame
    void Update()
    { 
     if(fuelAmount > 0)
     {
        MoveH();
        Fire();
        canFly = false;
     } 
     fuelMeter.text = "Fuel: " + fuelAmount.ToString() + "%";    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
           // Debug.Log("HIT!!! --health "+Health);
            Health -= collision.gameObject.GetComponent<AsteroidScript2>().Damage;
            Destroy(collision.gameObject);
            healthBar.SetHealth(Health);
            if (Health <= 0)
            {
                SceneManager.LoadScene(0);
            }
         }
    }
    //poohyb horizontalne
    void MoveH()
    {
        if (transform.position.x <= 11 && transform.position.x >= -11)
        {
            inputMove = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(inputMove, 0f, 0f) * speed * Time.deltaTime;
        }
        else {
            transform.position += new Vector3(-1*(inputMove) * speed * Time.deltaTime, 0f, 0f);
             }
         StartCoroutine(BurnFuel());
        
    }

    //strelba
    void Fire()
    {
        if(fuelAmount >= 10)
        {
        if (Input.GetKeyDown(KeyCode.Space))
          {
            Debug.Log("Strilim");
            //vytvo��m strelu
            Instantiate(bullet, transform.position, Quaternion.identity);
            shotSound.Play();
            fuelAmount -= 10 ;
          }
        }
    }

    private IEnumerator BurnFuel()
    {
        if( canFly)
        {
               for(float i = fuelAmount; i >= 1; i--)
        {
            if(fuelAmount > 0)
            {
            fuelAmount -= 1f;
            yield return new WaitForSeconds(1);
            }else{
                fuelAmount -= 0f;
            }
        }
        }
    }

}
