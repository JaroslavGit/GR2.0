using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaScript : MonoBehaviour
{
    public float speed = 4;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     transform.position += new Vector3(0f, speed, 0f)  * Time.deltaTime;
      if(transform.position.y > 6.5f)
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //støet s asteroidem
        if (collision.gameObject.tag == "Asteroid")
        {
            Debug.Log("Kolize");
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject); //znicim asteroid
            Destroy(this.gameObject); //znicim sebe - kulku
        }    
    }
}
