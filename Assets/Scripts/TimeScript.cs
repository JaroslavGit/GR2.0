using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    float time = 120; // cas k planete
    
    public Text timeText;


    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("FinishText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime; // snizi cas
        timeText.text = "Remaining time: " + Mathf.Round(time) + "s"; // nastavi text v ui

        if (time < 0) // pokud vyprsi cas
        {
            SceneManager.LoadScene("PlanetScene"); // nastavi scenu na planetu
        }
    }
}
