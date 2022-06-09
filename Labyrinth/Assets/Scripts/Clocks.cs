using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clocks : MonoBehaviour
{
    public Text timeText;
    private float time;
    public static int seconds;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!Menu.startGame)
        {
            return;
        }
        time += Time.deltaTime;
        int h, m, s, d, t;
        t = (int)time;
        h = t / 3600;
        m = (t % 3600) / 60;
        s = (t % 60);
        d = (int)((time - t) * 10);
        timeText.text =
            ((h < 10) ? "0" : "") + h + ":" +
            ((m < 10) ? "0" : "") + m + ":" +
            ((s < 10) ? "0" : "") + s + "." + d;

        seconds = s;
    }
}
