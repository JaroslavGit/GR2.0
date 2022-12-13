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

    //pøístup k UI
    public Text ironText;
    public Text goldText;
    public Text smaragdText;
    public Text diaText;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Sebráno");
        if (collision.gameObject.tag == "IronDrop")
        {

            ironCount++;
            ironText.text = ironCount + "pcs";
            Destroy(collision.gameObject);
        }
    }


}
