using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates : MonoBehaviour
{
    public static bool IsOpen;
    public static bool IsClose;
    private Vector3 startPositionGates;
    // Start is called before the first frame update 
    void Start()
    {
        IsOpen = false;
        IsClose = true;
        startPositionGates = transform.position;
    }

    // Update is called once per frame 
    void Update()
    {
        if (!Menu.startGame)
        {
            return;
        }
        if (IsOpen && IsClose)
        {
            if (transform.position.z < 3.5f)
            {
                transform.Translate(Vector3.left * (Time.deltaTime * 0.8f));
            }
            else
            {
                IsOpen = false;
                IsClose = false;
            }
        }
        if (!IsClose)
        {
            if (transform.position.z > startPositionGates.z)
            {
                transform.Translate(Vector3.right * (Time.deltaTime*0.5f));
            }
            else
            {
                IsClose = true;
            }
        }
    }

}
