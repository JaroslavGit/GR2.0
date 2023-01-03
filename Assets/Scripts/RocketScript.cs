using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        barelSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveH();
        Fire();
       
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

    }

    //strelba
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
          {
            Debug.Log("Strilim");
            //vytvoøím strelu
            Instantiate(bullet, transform.position, Quaternion.identity);
            shotSound.Play();
          }

    }
}
