using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text countText;
    private static int countTube = 0;
    public Slider sliderLevel;
    // Start is called before the first frame update
    void Start()
    {
        countText.text = "COUNT: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Money")
        {
            countTube += (int)sliderLevel.value;
            countText.text = "COUNT: " + countTube;
        }

            
    }

    public static void ResetCount()
    {
        countTube = 0;
    }
}
