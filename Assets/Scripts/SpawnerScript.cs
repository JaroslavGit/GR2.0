using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Aoid;
    public float Rate = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Random.Range(0f, 1f) < Rate) {
            Spawn();
        }
          

    }

    void Spawn()
    {
        Instantiate(Aoid, new Vector3(Random.Range(-13,13), 10, 0), Quaternion.identity);
    }

}
