using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.5f * Time.deltaTime);

        if (transform.position.y < -12)
        {
            transform.position = new Vector3(transform.position.x, 12f);
        }
    }
}
