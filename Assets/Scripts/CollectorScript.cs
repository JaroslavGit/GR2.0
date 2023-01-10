using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    private int ironCount;
    private int diaCount;
    //private int smaragdCount;
    private int goldCount;

    //pøístup k UI
    [SerializeField]
    public Text ironText;
    public Text goldText;
  //  public Text smaragdText;
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
        
    }



}
