using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Aoid;
    public float Rate = 0.01f;
    public GameObject AoidGold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0f, 1f) < Rate)
        {
            Spawn();
        }
        else if (Random.Range(0f, 1f) < Rate)
        {
            SpawnGold();


        }
    }

    void Spawn()
    {
        Instantiate(Aoid, new Vector3(Random.Range(-11.5f, 11.5f), 10, 0), Quaternion.identity);
    }

     void SpawnGold()
        {
            Instantiate(AoidGold, new Vector3(Random.Range(-11.5f, 11.5f), 10, 0), Quaternion.identity);
        }

    }
