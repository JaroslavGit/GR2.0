using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGoldScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 1f;
    [SerializeField]
    public int Damage = 20;
    [SerializeField]
    public float dropChance = 0.5f;  //50% šance
    public GameObject dropPrefab;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plasma")
        {
            if (Random.Range(0f, 1f) < dropChance)
            {
                Instantiate(dropPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
