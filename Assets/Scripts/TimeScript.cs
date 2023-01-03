using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    float time = 120;
    float lastTime = 120;

    [SerializeField]
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        int t = (int)(time * 10);
        float timeNow = (float)t / 10;
        if (timeNow < lastTime)
        {
            lastTime = timeNow;
            timeText.text = "Remaining time: " + lastTime + "s";
        }

        if (time < 0)
        {
            //konec
        }
    }
}