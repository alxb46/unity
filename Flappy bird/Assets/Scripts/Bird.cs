using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float ForceMagnitude = 1000;
    public float ForceMagnitude2 = 380;
    private static Rigidbody2D rb;
    public static bool activeGame;
    public static byte lives = 3;
    private static Vector3 startVectorBird = new Vector3();

    public Text textButton;
    // Start is called before the first frame update
    public void Start()
    {
        activeGame = true;
        rb = GetComponent<Rigidbody2D>();
        startVectorBird = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeGame != false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up * ForceMagnitude * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * ForceMagnitude2);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Bird.lives > 0) { textButton.text = "Continue"; }

        
        //Debug.Log(collision.name);
        if (collision.name != "Money")
        {
            StartPlace();
            rb.bodyType = RigidbodyType2D.Static;
            activeGame = false;
            Debug.Log("end game");

        }
    }
        
    public static void StartPlace()
    {
        rb.position = startVectorBird;
        Debug.Log(rb.position);
    }

    public static void setDinamicBodyType()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    
}