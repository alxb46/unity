using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGates : MonoBehaviour
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
            if (transform.position.y > -1.5f)
            {
                transform.Translate(Vector3.down * (Time.deltaTime * 0.5f));
            }
            else
            {
                IsOpen = false;
                IsClose = false;
            }
        }
        if (!IsClose)
        {
            if (transform.position.y < startPositionGates.y)
            {
                transform.Translate(Vector3.up * (Time.deltaTime * 0.2f));
            }
            else
            {
                IsClose = true;
            }
        }
    }
}
