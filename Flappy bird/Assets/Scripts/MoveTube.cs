using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTube : MonoBehaviour
{
    public float MoveVelocity = 1;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird.activeGame)
        {
            transform.Translate(Vector2.left * MoveVelocity * slider.value * Time.deltaTime);
        }
       
    }

    
}
