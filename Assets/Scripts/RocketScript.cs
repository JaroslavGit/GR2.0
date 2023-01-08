using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 3.6f;
    public float inputMove;

    public GameObject bullet;
    public AudioSource shotSound;
    public AudioSource barelSound;

    [SerializeField]
    public int Health = 100;

     [SerializeField]
     public float fuelAmount;
     public Text fuelMeter;
    private bool canFly;


    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        barelSound = GetComponent<AudioSource>();
        fuelAmount = 100;
       canFly = true;
       
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
            Debug.Log("HIT!!! --health "+Health);
            Health -= collision.gameObject.GetComponent<AsteroidScript2>().Damage;
            Destroy(collision.gameObject);
     

        }
    }
    //poohyb horizontalne
    void MoveH()
    {
     

        inputMove = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(inputMove, 0f, 0f) * speed * Time.deltaTime;
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
