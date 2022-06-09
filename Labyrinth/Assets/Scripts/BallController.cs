using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Threading;
using System.Threading.Tasks;

public class BallController : MonoBehaviour
{
    public float ForceFactor = 200;
    public Camera MainCamera;

    private Vector3 forceDirection;
    private Vector3 startPosition;
    private Rigidbody rb;
    private Vector3 selfieRod;

    public Image imageKey_1;
    public Image imageKey_2;
    public Image imageKey_3;
    private new GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("MainProgressBar");
        gameObject.SetActive(true);
        forceDirection = Vector3.zero;
        startPosition = transform.position;
        selfieRod = (MainCamera.transform.position - transform.position) / 2; // /2
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menu.startGame)
        {
            return;
        }
        forceDirection.x = Input.GetAxis("Horizontal");
        forceDirection.z = Input.GetAxis("Vertical");
        rb.AddForce(forceDirection * ForceFactor * Time.deltaTime);



        if (Timing.activeProgres == false)
        {
            if (Menu.sounds[1].isPlaying)
            {
                Menu.sounds[1].Stop();
            }
        }
    }

    private void LateUpdate()
    {
        if (transform.position.y < 0)
        {
            // Out of field
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        MainCamera.transform.position = selfieRod + transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag.Equals("CheckPoint"))
        {
            OpenGates.IsOpen = true;
            ProgressCircle(imageKey_1, other);
        }
        else if (other.gameObject.tag.Equals("CheckPoint2"))
        {
            OpenGates2.IsOpen = true;
            ProgressCircle(imageKey_2, other);
        }
        else if (other.gameObject.tag.Equals("CheckPoint3"))
        {
            HideGates.IsOpen = true;
            ProgressCircle(imageKey_3, other);
        }
        else if (other.gameObject.tag.Equals("Stone"))
        {
            if (!Menu.sounds[2].isPlaying)
            {
                Menu.sounds[2].Play();
            }
        }
        else if (other.gameObject.tag.Equals("Finish"))
        {
            if (Menu.sounds[0].isPlaying)
            {
                Menu.sounds[0].Stop();
            }
            if (!Menu.sounds[3].isPlaying)
            {
                Menu.sounds[3].Play();
            }
        }
    }

    private void ProgressCircle(Image image, Collider other)
    {
        other.gameObject.SetActive(true);

        if (!Menu.sounds[1].isPlaying)
        {
            Menu.sounds[1].Play();
        }

        image.color = Color.white;
        Timing.activeProgres = true;
        gameObject.SetActive(true);
        
    }

}
