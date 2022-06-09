using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates2 : MonoBehaviour
{
    public static bool IsOpen;
    public static bool IsClose;
    private Vector3 startPositionGates;

    // Start is called before the first frame update 
    private void Start()
    {
        IsOpen = false;
        IsClose = true;
        startPositionGates = transform.position;
    }

    // Update is called once per frame 
    private void Update()
    {
        if (!Menu.startGame)
        {
            return;
        }

        if (IsOpen && IsClose)
        {
            if (transform.position.x < -0.6f)
            {
                transform.Translate(Vector3.right * (Time.deltaTime * 0.5f));
            }
            else
            {
                IsOpen = false;
                IsClose = false;
            }
        }
        if (!IsClose)
        {
            if (transform.position.x > startPositionGates.x)
            {
                transform.Translate(Vector3.left * (Time.deltaTime * 0.2f));
            }
            else
            {
                IsClose = true;
            }
        }
    }
}
