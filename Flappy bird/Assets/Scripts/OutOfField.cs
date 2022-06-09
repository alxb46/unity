using UnityEngine;
using UnityEngine.UI;

public class OutOfField : MonoBehaviour
{
    private GameObject spawnPosition;

    public GameObject firstTUP;  // => first Tube Up Part
    public GameObject firstTDP;  // => first Tube Down Part

    public GameObject secondTUP; // => second Tube Up Part
    public GameObject secondTDP; // => second Tube Down Part

    public GameObject thirdTUP;  // => third Tube Up Part
    public GameObject thirdTDP;  // => third Tube Down Part

    private Vector3 positionFTUP;  // => position First Tube Up Part;
    private Vector3 positionFTDP;  // => position First Tube Down Part

    private Vector3 positionSTUP; // => position Second Tube Up Part;
    private Vector3 positionSTDP; // => position Second Tube Down Part;

    private Vector3 positionTTUP; // => position Third Tube Up Part
    private Vector3 positionTTDP; // => position Third Tube Down Part

    public Slider gapSlider;

    public static bool check = true;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = GameObject.Find("SpawnPosition");
        
        positionFTUP = firstTUP.transform.position;
        positionFTDP = firstTDP.transform.position;
        ///
        positionSTUP = secondTUP.transform.position;
        positionSTDP = secondTDP.transform.position;
        ///
        positionTTUP = thirdTUP.transform.position;
        positionTTDP = thirdTDP.transform.position;

        Debug.Log("FTUP " + positionFTUP);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (check)
        //{
        //    if (Bird.activeGame == false)
        //    {
        //        restartPlaceTube();
        //        check = false;
        //    }
        //}
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("position: " + spawnPosition.transform.position);
        collision.gameObject.transform.parent.parent.position = spawnPosition.transform.position;

        collision.gameObject.transform.parent.parent.Translate(Vector2.up * Random.Range(-2f, 2f));
    }

     public void OnValueChanched()
     {
        Debug.Log("Change tube");

        firstTUP.transform.position = new Vector3(
            firstTUP.transform.position.x,
            positionFTUP.y - (gapSlider.value / 2),
            firstTUP.transform.position.z
            );

        firstTDP.transform.position = new Vector3(
            firstTDP.transform.position.x,
            positionFTDP.y + (gapSlider.value / 2),
            firstTDP.transform.position.z
            );
        ///////////
        secondTUP.transform.position = new Vector3(
             secondTUP.transform.position.x,
             positionSTUP.y - (gapSlider.value / 2),
             secondTUP.transform.position.z
            );
        secondTDP.transform.position = new Vector3(
            secondTDP.transform.position.x,
            positionSTDP.y + (gapSlider.value / 2),
            secondTDP.transform.position.z
            );
        ///////////
        thirdTUP.transform.position = new Vector3(
            thirdTUP.transform.position.x,
            positionTTUP.y - (gapSlider.value / 2),
            thirdTUP.transform.position.z
            );
        thirdTDP.transform.position = new Vector3(
            thirdTDP.transform.position.x,
            positionTTDP.y + (gapSlider.value / 2),
            thirdTDP.transform.position.z
            );

        //Debug.Log(firstTubeDownPart.transform.position.ToString());
     }

     public void restartPlaceTube()
     {
        //firstTUP.transform.position = positionFTUP;
        //firstTDP.transform.position = positionFTDP;
        /////
        //secondTUP.transform.position = positionSTUP;
        //secondTDP.transform.position = positionSTDP;
        /////
        //thirdTUP.transform.position = positionTTUP;
        //thirdTDP.transform.position = positionTTDP;

        //firstTUP.transform.parent.position = positionFTUP; //new vector3(positionFTUP.x)?
        //secondTUP.transform.parent.position = positionSTUP;
        //thirdTUP.transform.parent.position = positionTTUP;

        firstTUP.transform.parent.position = new Vector3(positionFTUP.x, 0);
        secondTUP.transform.parent.position = new Vector3(positionSTUP.x, 0);
        thirdTUP.transform.parent.position = new Vector3(positionTTUP.x, 0);

        //Debug.Log("X: " + positionSTUP.x);
        //Debug.Log("Y: " + secondTUP.transform.parent.position.y);

        Debug.Log("FTUP " + positionFTUP);
    }
}
