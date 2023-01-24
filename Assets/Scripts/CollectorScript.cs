using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    private int ironCount;
    private int diaCount;
    private int smaragdCount;
    private int goldCount;

    //p��stup k UI
    [SerializeField]
    public Text ironText;
    public Text goldText;
    public Text smaragdText;
    public Text diaText;
    [SerializeField]
    public AudioSource barelSound;

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.tag == "IronDrop")
        {

            ironCount++;
            ironText.text = ironCount + "pcs";
            Destroy(collision.gameObject);
            barelSound.Play();
        }

        if (collision.gameObject.tag == "GoldDrop")
        {

            goldCount++;
            goldText.text = goldCount + "pcs";
            Destroy(collision.gameObject);
            barelSound.Play();
        }

        if(collision.gameObject.tag == "Energy")
        {
            if(GetComponent<RocketScript>().fuelAmount <= 90)
            {
                GetComponent<RocketScript>().fuelAmount += 25;
            }else{
                GetComponent<RocketScript>().fuelAmount += 100 - GetComponent<RocketScript>().fuelAmount;
            }
            
            Destroy(collision.gameObject);
        }
    }


}
