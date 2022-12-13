using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, speed, 0f) * Time.deltaTime;   
    }
}
