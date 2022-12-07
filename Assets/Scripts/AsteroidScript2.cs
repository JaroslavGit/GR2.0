using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript2 : MonoBehaviour
{
    [SerializeField]
    public float speed = 1f;
    [SerializeField]
    public int Damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, -1, 0f) * speed * Time.deltaTime;
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

    }
}
